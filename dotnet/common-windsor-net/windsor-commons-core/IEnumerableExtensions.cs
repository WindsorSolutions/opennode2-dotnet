using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windsor.Commons.Core
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> items, string propertyName)
        {
            return items.OrderBy(propertyName, true);
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> items, string propertyName, bool ascending)
        {
            if (!string.IsNullOrEmpty(propertyName))
                items = ascending
                            ? items.OrderBy(i => i.ValueOfPropertyByName(propertyName))
                            : items.OrderByDescending(i => i.ValueOfPropertyByName(propertyName));

            return items;
        }

        public static IEnumerable<T> FilterBy<T>(this IEnumerable<T> items, string filterProperty, object value)
        {
            if (string.IsNullOrEmpty(filterProperty))
                return items;

            var filterIdString = value.ToString();
            var idArray = value as IEnumerable<string>;
            filterIdString = idArray != null ? idArray.First() : filterIdString;

            int filterIdInt;
            if (int.TryParse(filterIdString, out filterIdInt))
                items = items.Where(i => Equals(i.ValueOfPropertyByName(filterProperty), filterIdInt));
            else
                items = items.Where(i => Equals(i.ValueOfPropertyByName(filterProperty), filterIdString));

            return items;
        }

        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> items, int? pageSize, int? pageNumber)
        {
            if (pageSize.HasValue && pageSize < 0)
                throw new ArgumentOutOfRangeException("pageSize", "pageSize cannot be less than 0 (and even 0 is a bit ridiculous, but we'll take it)");
            if (pageNumber.HasValue && pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", "pageNumber is 1-based");

            var rc = items;
            //subtract one from page, because page 1 should start at skipping 0 items.
            if (pageSize.HasValue && pageNumber.HasValue)
                rc = rc.Skip((pageNumber.Value - 1) * pageSize.Value);

            return pageSize.HasValue ? rc.Take(pageSize.Value) : rc;
        }

        public static List<T> ForEachEx<T>(this List<T> items, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach (var item in items)
            {
                action(item);
            }
            return items;
        }
    }
}
