using EasyDBDriver.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDBDriver.Model
{
    public class SortOperator : IQueryCriteria
    {
        private IEnumerable<SortDefinition> _definitions;

        public SortOperator(IEnumerable<SortDefinition> definitions)
        {
            _definitions = definitions;
        }

        public SortOperator(SortDefinition definition)
        {
            _definitions = new SortDefinition[] { definition };
        }

        public string GetCriteria()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("sort={");
            var ordres = _definitions.Select(e => e.Field.Build(e.Order == OrderBy.Descending ? "-1" : "1"));
            sb.Append(string.Join(",", ordres));
            sb.Append("}");

            return sb.ToString();
        }
    }

}