using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IEnumerator=System.Collections.IEnumerator;

namespace Windsor.Commons.Core
{
    public static class IQueryableExtensions
    {
        public static Type GetDataItemType(this IQueryable DataSource)
        {
            Type dataSourceType = DataSource.GetType();
            Type dataItemType = typeof(object);

            if (dataSourceType.HasElementType)
            {
                dataItemType = dataSourceType.GetElementType();
            }
            else if (dataSourceType.IsGenericType)
            {
                dataItemType = dataSourceType.GetGenericArguments()[0];
            }
            else if (DataSource is IEnumerable)
            {
                IEnumerator dataEnumerator = DataSource.GetEnumerator();

                if (dataEnumerator.MoveNext() && dataEnumerator.Current != null)
                {
                    dataItemType = dataEnumerator.Current.GetType();
                }
            }

            return dataItemType;
        }

        public static int GetTotalRowCount(this IQueryable Source)
        {
            Type dataSourceType = Source.GetType();
            Type dataItemType = GetDataItemType(Source);

            Type rowCounterType = typeof(IQueryableUtil<>).MakeGenericType(dataItemType);

            return (int)rowCounterType.GetMethod("Count", new Type[] { dataSourceType })
                            .Invoke(null, new object[] { Source });
        }

        public static IQueryable Contains(this IQueryable Source, string PropertyName, string SearchClause)
        {
            Type dataSourceType = Source.GetType();
            Type dataItemType = GetDataItemType(Source);
            Type propertyType = dataItemType.GetProperty(PropertyName).PropertyType;

            Type containsType = typeof(IQueryableUtil<,>).MakeGenericType(dataItemType, propertyType);

            return (IQueryable)containsType.GetMethod("Contains", new Type[] { dataSourceType, typeof(string), typeof(string) })
                            .Invoke(null, new object[] { Source, PropertyName, SearchClause });
        }

        public static IQueryable Page(this IQueryable Source, int PageSize, int CurrentPage)
        {
            Type dataSourceType = Source.GetType();
            Type dataItemType = GetDataItemType(Source);

            Type containsType = typeof(IQueryableUtil<>).MakeGenericType(dataItemType);

            IQueryable query =  (IQueryable)containsType.GetMethod("Page", new Type[] { dataSourceType, typeof(int), typeof(int) })
                            .Invoke(null, new object[] { Source, PageSize, CurrentPage });
            return query;
        }

        public static IQueryable Sort(this IQueryable Source, string PropertyName, bool Ascending)
        {
            Type dataSourceType = Source.GetType();
            Type dataItemType = GetDataItemType(Source);
            Type propertyType = dataItemType.GetProperty(PropertyName).PropertyType;

            Type sorterType = typeof(IQueryableUtil<,>).MakeGenericType(dataItemType, propertyType);

            return (IQueryable)sorterType.GetMethod("Sort", new Type[] { dataSourceType, typeof(string), typeof(bool) })
                        .Invoke(null, new object[] { Source, PropertyName, Ascending });
  
        }


        internal static class IQueryableUtil<T>
        {
           
            public static int Count(IQueryable Source)
            {
                return Source.OfType<T>().AsQueryable<T>().Count<T>();
            }

            public static IQueryable Page(IQueryable Source, int PageSize, int PageIndex)
            {
                IQueryable query = Source.OfType<T>().AsQueryable<T>().Skip<T>(PageSize * (PageIndex - 1)).Take<T>(PageSize);
                return query;
            }
        }

        internal static class IQueryableUtil<T,PT>
        {
            public static IQueryable Sort(IQueryable source, string sortExpression, bool Ascending)
            {
                var param = Expression.Parameter(typeof(T), "item");

                var sortLambda = Expression.Lambda<Func<T, PT>>(Expression.Convert(Expression.Property(param, sortExpression), typeof(PT)), param);

                if (Ascending)
                {
                    // (o=> 0.sortExpression)
                    return source.OfType<T>().AsQueryable<T>().OrderBy<T, PT>(sortLambda);
                }
                else
                {
                    return source.OfType<T>().AsQueryable<T>().OrderByDescending<T, PT>(sortLambda);
                    
                }
            }

            public static IQueryable Contains(IQueryable Source, string PropertyName, string SearchClause)
            {
                var entityParam = Expression.Parameter(typeof(T), "item");

                //var containsLambda = Expression.Lambda<Func<T, PT>>(Expression.Convert(Expression.Property(param, PropertyName), typeof(PT)), param);

                MemberExpression memberExpression = Expression.Property(entityParam, PropertyName);
                Expression convertExpression = Expression.Convert(memberExpression, typeof(object));
                ConstantExpression searchClauseParam = Expression.Constant(SearchClause, typeof(string));


                MethodCallExpression containsExpression = Expression.Call(memberExpression, "Contains", new Type[] { }, new Expression[] { searchClauseParam });


         

                var containsLambda = Expression.Lambda<Func<T, bool>>(containsExpression, entityParam);


                return Source.OfType<T>().AsQueryable<T>().Where<T>(containsLambda);
            }
        }


    }
}