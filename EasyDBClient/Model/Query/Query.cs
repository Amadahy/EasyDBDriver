using EasyDBDriver.Interface;
using System.Collections.Generic;
using System.Linq;

namespace EasyDBDriver.Model
{
    public class Query : IQuery
    {
        private List<IQueryCriteria> parameters = new List<IQueryCriteria>();

        public void Filter(IOperator op)
        {
            parameters.Add(new FilterOperator(op));
        }

        public void Sort(params SortDefinition[] definitions)
        {
            parameters.Add(new SortOperator(definitions));
        }

        public void Limit(int limit)
        {
            parameters.Add(new LimitOperator(limit));
        }

        public void Skip(int limit)
        {
            parameters.Add(new SkipOperator(limit));
        }

        public string BuildQuery()
        {
            if (!parameters.Any())
            {
                return string.Empty;
            }

            return string.Join("&", parameters);
        }
    }
}
