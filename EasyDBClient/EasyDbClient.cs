using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyDBDriver.Interface;
using EasyDBDriver.Model;

namespace EasyDBDriver
{
    public class EasyDbClient<T> : IEasyDbClient<T> where T : EasyDbElement
    {

        private readonly string _token;
        private readonly HttpClient _httpClient;
        private readonly string _urlToServer;
        private readonly string _collection;

        private string Url { get { return $"{_urlToServer}/api/{_collection}"; } }

        public EasyDbClient(string urlToServer, string token, string collection)
        {
            _urlToServer = urlToServer;
            _collection = collection;
            _token = token;
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<T>> GetCollectionAsync(IQuery query)
        {
            var queryString = query.BuildQuery();
            if (string.IsNullOrEmpty(queryString))
            {
                return await GetCollectionAsync();
            }

            var response = await DoRequestAsync(HttpMethod.Get, $"{Url}?{queryString}");
            return await DeserializeAsync<IList<T>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<IEnumerable<T>> GetCollectionAsync()
        {
            var response = await DoRequestAsync(HttpMethod.Get, Url);
            var r = await response.Content.ReadAsStringAsync();
            return await DeserializeAsync<IList<T>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<T> GetAsync(string id)
        {
            var response = await DoRequestAsync(HttpMethod.Get, GetUrlWithId(id));
            return await DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<string> AddAsync(T element)
        {
            var response = await DoRequestAsync(HttpMethod.Post, Url);

            element.Id = (await response.Content.ReadAsStringAsync()).Replace("\"", "");

            await UpdateAsync(element);

            return element.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            await DoRequestAsync(HttpMethod.Put, GetUrlWithId(entity), entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await DeleteAsync(entity.Id);
        }

        public async Task DeleteAsync(string id)
        {
            await DoRequestAsync(HttpMethod.Delete, GetUrlWithId(id));
        }

        public async Task<byte[]> GetFileAsync(FileModel fileModel)
        {
            return await GetFileAsync(fileModel.Url);
        }

        public async Task<byte[]> GetFileAsync(string url)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{url}");

            if (!string.IsNullOrEmpty(_token))
            {
                request.Headers.Add("Easy-DB-Token", _token);
            }

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"HttpMethod.Get {url} {response.ToString()}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        private string GetUrlWithId(T entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                throw new ArgumentNullException(nameof(entity), "Id is null");
            }

            return GetUrlWithId(entity.Id);
        }

        private string GetUrlWithId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Id is null");
            }

            return $"{Url}/{id}";
        }

        private async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, string url, T entity)
        {
            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            return await DoRequestAsync(method, url, content);
        }

        private async Task<HttpResponseMessage> DoRequestAsync(HttpMethod method, string url, HttpContent content = null)
        {
            using var request = new HttpRequestMessage(method, url);
            if (!string.IsNullOrEmpty(_token))
            {
                request.Headers.Add("Easy-DB-Token", _token);
            }

            if (content != null)
            {
                request.Content = content;
            }
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"{method} {url} {response.ToString()}");
            }

            return response;
        }

        private async Task<C> DeserializeAsync<C>(Stream stream)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var result = await JsonSerializer.DeserializeAsync<C>(stream, options);
            return result;
        }
    }
}
