using EasyDBDriver.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace EasyDBDriver.Model
{
    public static class Field<T>
    {
        public static IFieldOperator Define<TProp>(Expression<Func<T, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Input parameter 'expression' should be a member of class");
            }

            if (body.Member.CustomAttributes != null)
            {
                var attribute = body.Member.CustomAttributes.FirstOrDefault(e => e.AttributeType == typeof(JsonPropertyNameAttribute));
                if (attribute != null)
                {
                    var arg = attribute.ConstructorArguments.FirstOrDefault();
                    if (arg.Value != null)
                    {
                        return new FieldDefiniton(arg.Value.ToString());
                    }
                }
            }

            return new FieldDefiniton(body.Member.Name);
        }
    }
}
