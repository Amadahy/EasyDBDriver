using EasyDBDriver.Interface;
using System.Text;

namespace EasyDBDriver.Model
{
    internal class LimitOperator : IQueryCriteria
    {
       private int _limit;

        public LimitOperator(int limit)
        {
            _limit = limit;
        }

        public string GetCriteria()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("limit=");
            sb.Append(_limit);

            return sb.ToString();
        }
    }
}