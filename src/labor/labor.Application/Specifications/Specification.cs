using labor.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace labor.Application.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria => throw new NotImplementedException();

        public List<Expression<Func<T, object>>> Includes => throw new NotImplementedException();

        public List<string> IncludeStrings => throw new NotImplementedException();

        public Expression<Func<T, object>> OrderBy => throw new NotImplementedException();

        public Expression<Func<T, object>> OrderByDescending => throw new NotImplementedException();

        public Expression<Func<T, object>> GroupBy => throw new NotImplementedException();

        public int Take => throw new NotImplementedException();

        public int Skip => throw new NotImplementedException();

        public bool IsPagingEnabled => throw new NotImplementedException();
    }
}
