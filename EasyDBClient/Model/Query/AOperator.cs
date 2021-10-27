using EasyDBDriver.Interface;

namespace EasyDBDriver.Model
{
    internal abstract class AOperator : IOperator
    {
        protected IOperator _parent;

        public AOperator()
        { }

        public AOperator(IOperator parent)
        {
            _parent = parent;
        }

        public virtual string Build(string s = null)
        {
            if (_parent == null)
                return s;

            return _parent.Build(s);
        }
    }
}
