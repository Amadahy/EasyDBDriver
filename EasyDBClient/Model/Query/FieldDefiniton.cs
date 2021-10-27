using EasyDBDriver.Interface;
using System.Text;

namespace EasyDBDriver.Model
{

    /// <summary>
    ///  { price: ****** }
    /// </summary>
    internal class FieldDefiniton : AOperator, IFieldOperator
    {
        private readonly string _name;

        public FieldDefiniton(string name)
        {
            _name = name;
        }

        public FieldDefiniton(string name, IOperator parent) : base(parent)
        {
            _name = name;
        }

        public override string Build(string s = null)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"");
            sb.Append(_name);
            sb.Append("\":");
            sb.Append(s);
            sb.Append("}");

            return base.Build(sb.ToString());
        }
    }
}
