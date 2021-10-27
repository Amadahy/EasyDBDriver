using EasyDBDriver.Interface;

namespace EasyDBDriver.Model
{
    public class SortDefinition 
    {
        public IOperator Field { get; private set; }
        public OrderBy Order { get; private set; }

        public SortDefinition(IFieldOperator field,OrderBy orderBy)
        {
            Field = field;
            Order = orderBy;
        }
    }
}