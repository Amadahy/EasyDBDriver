using EasyDBDriver.Interface;
using System.Collections.Generic;

namespace EasyDBDriver.Model
{
    public static class Filter
    {
        /// <summary>
        /// Joins query clauses with a logical AND returns all documents that match the conditions of both clauses.
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static IOperator And(IEnumerable<IOperator> expressions)
        {
            return new LogicalOperator("$and", expressions);
        }

        /// <summary>
        /// Joins query clauses with a logical OR returns all documents that match the conditions of either clause.
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static IOperator Or(IEnumerable<IOperator> expressions)
        {
            return new LogicalOperator("$or", expressions);
        }

        /// <summary>
        /// Joins query clauses with a logical NOR returns all documents that fail to match both clauses.
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static IOperator Nor(IEnumerable<IOperator> expressions)
        {
            return new LogicalOperator("$nor", expressions);
        }

        /// <summary>
        /// Inverts the effect of a query expression and returns documents that do not match the query expression.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static IOperator Not(this IOperator p)
        {
            return new NotOperator(p);
        }

        /// <summary>
        /// Matches values that are equal to a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator Equal(this IOperator p, object value)
        {
            return new ComparationOperator("$eq", value, p);
        }

        /// <summary>
        /// Matches values that are greater than a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator Greater(this IOperator p, object value)
        {
            return new ComparationOperator("$gt", value, p);
        }

        /// <summary>
        /// Matches values that are greater than or equal to a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator GreaterOrEqual(this IOperator p, object value)
        {
            return new ComparationOperator("$gte", value, p);
        }

        /// <summary>
        /// Matches values that are less than a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator Less(this IOperator p, object value)
        {
            return new ComparationOperator("$lt", value, p);
        }

        /// <summary>
        /// Matches values that are less than or equal to a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator LessOrEqual(this IOperator p, object value)
        {
            return new ComparationOperator("$lte", value, p);
        }

        /// <summary>
        /// Matches values that are less than or equal to a specified value.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IOperator NotEqual(this IOperator p, object value)
        {
            return new ComparationOperator("$ne", value, p);
        }
    }
}
