using EasyDBDriver.Interface;
using System.Text;

namespace EasyDBDriver.Model
{
    /// <summary>
    /// Render { $not:  /child/ }
    /// </summary>
    internal class NotOperator : AOperator
    {
        private readonly string _op = "$not";

        public NotOperator(IOperator parent) : base(parent)
        {

        }

        public override string Build(string s = null)
        {
            StringBuilder sb = new StringBuilder();

            // exmaple: { $not: { $gt: 1.99 } }
            sb.Append("{");
            sb.Append("\"");
            sb.Append(_op);
            sb.Append("\":");
            sb.Append(s);
            sb.Append("}");

            return base.Build(sb.ToString());
        }
    }
}
