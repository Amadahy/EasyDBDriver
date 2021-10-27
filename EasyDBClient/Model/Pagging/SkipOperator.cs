using EasyDBDriver.Interface;
using System.Text;

namespace EasyDBDriver.Model
{
    internal class SkipOperator : IQueryCriteria
    {
       private int _skip;

        public SkipOperator(int skip)
        {
            _skip = skip;
        }

        public string GetCriteria()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("skip=");
            sb.Append(_skip);

            return sb.ToString();
        }
    }
}