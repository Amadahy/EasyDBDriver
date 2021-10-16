using EasyDBConnector.Interface;

namespace EasyDBConnector
{
    public class EasyDbFactory
    {
        private readonly string _url;
        private readonly string _token;

        public EasyDbFactory(string urlToServer, string token)
        {
            _url = urlToServer;
            _token = token;
        }

        public IEasyDbClient<T> GetConnector<T>(string collection) where T : EasyDbElement
        {
            return new EasyDbClient<T>(_url, _token, collection);
        }
    }
}
