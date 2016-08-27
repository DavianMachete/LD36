using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Project.Scripts
{
    public static class IenumerableExtensions
    {
        public static IEnumerable<T> TakeEvery<T>(this IEnumerable<T> enumerable, int number)
        {
            int index = 0;
            foreach (var item in enumerable)
            {
                index++;
                if (index == number)
                {
                    yield return item;
                    index = 0;
                }
            }
        }

        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);
        }
    }
}
