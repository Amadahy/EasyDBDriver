using EasyDBDriver.Interface;
using System.Text;

namespace EasyDBDriver.Model
{
    /// <summary>
    /// Render { $not:  /child/ }
    /// </summary>
    public class FilterOperator : IQueryCriteria
    {
        private IOperator _op;

        public FilterOperator(IOperator op)
        {
            _op = op;
        }

        public string GetCriteria()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("query=");
            sb.Append(_op.Build());

            return sb.ToString();
        }
    }
}
