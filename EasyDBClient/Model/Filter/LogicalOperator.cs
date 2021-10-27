using EasyDBDriver.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyDBDriver.Model
{

    /// <summary>
    /// Render for example { $and: [ /expresion1/, /expresion 2/ ]}
    /// </summary>
    internal class LogicalOperator : AOperator
    {
        private readonly string _op;
        private readonly IEnumerable<IOperator> _expresions;

        public LogicalOperator(string op, IEnumerable<IOperator> expresions)
        {
            _op = op;
            _expresions = expresions;
        }

        public override string Build(string s = null)
        {
            StringBuilder sb = new StringBuilder();

            // exmaple: { $and: [ ***** ,  ***** , ***** ] }
            sb.Append("{");
            sb.Append("\"");
            sb.Append(_op);
            sb.Append("\":");
            sb.Append("[");
            sb.AppendJoin(",", _expresions.Select(e => e.Build()));
            if (!string.IsNullOrEmpty(s))
            {
                sb.Append(",");
                sb.Append(s);
            }
            sb.Append("]");
            sb.Append("}");


            return base.Build(sb.ToString());
        }
    }
}
