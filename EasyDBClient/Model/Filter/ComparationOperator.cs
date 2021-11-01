using EasyDBDriver.Interface;
using System;
using System.Text;

namespace EasyDBDriver.Model
{
    internal class ComparationOperator : AOperator
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

        public override string Build(string s)
        {
            StringBuilder sb = new StringBuilder();

            // exmaple: { $gt: 1.99 }
            sb.Append("{");
            sb.Append("\"");
            sb.Append(_op);
            sb.Append("\":");
            PrintValue(sb);
            sb.Append("}");

            return base.Build(sb.ToString());
        }

        private void PrintValue(StringBuilder sb)
        {
            if (_val is bool)
            {
                sb.Append(_val.ToString().ToLower());
                return;
            }

            if (UseQuotas())
            {
                sb.Append("\"");
            }

            sb.Append(_val.ToString());

            if (UseQuotas())
            {
                sb.Append("\"");
            }
        }

        private bool UseQuotas()
        {
            return _val is string || _val is DateTime || _val is char;
        }
    }
}
