using EasyDBDriver.Interface;
using System;
using System.Text;

namespace EasyDBDriver.Model.Query
{
    public class ComparationOperator : AOperator
    {
        private readonly string _op;
        private readonly object _val;

        public ComparationOperator(string op, object value)
        {
            _op = op;
            _val = value;
        }

        public ComparationOperator(string op, object value, IOperator parent) : base(parent)
        {
            _op = op;
            _val = value;
        }

        public override string Render(string s)
        {
            StringBuilder sb = new StringBuilder();

            // exmaple: { $gt: 1.99 }
            sb.Append("{");
            sb.Append("\"");
            sb.Append(_op);
            sb.Append("\":");
            if (UseQuotas())
            {
                sb.Append("\"");
            }
            sb.Append(_val.ToString());
            if (UseQuotas())
            {
                sb.Append("\"");
            }
            sb.Append("}");

            return base.Render(sb.ToString());
        }

        private bool UseQuotas()
        {
            return _val is string || _val is DateTime || _val is char;
        }
    }
}
