using System;
using System.Linq.Expressions;

namespace EasyDBDriver.Model.Query
{
    public static class Filter<T>
    {
        public static FieldDefiniton Field<TProp>(Expression<Func<T, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Input parameter 'expression' should be a member of class");
            }
            return new FieldDefiniton(body.Member.Name);
        }
    }
}
