using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollerBall.Extensions
{
    public static class Extensions
    {
        public static int StringLen(this string str)
        {
            int len = 0;
            foreach (char ch in str)
            {
                len ++;
            }
            return len;
        }
        public static int IntElementCount(this List<int> list, int element) // Метод-расширение для поиска количества чисел в инт листе
        {
            int count = 0;
            foreach (int el in list)
                if (el.Equals(element))
                    count += 1;
            return count;
        }
        public static int CommonListElementCount<T>(this List<T> list, object element) // Метод-расширение для поиска в обобщённой коллекции
        {
            int count = 0;
            foreach (T el in list)
                if (el.Equals(element))
                    count += 1;
            return count;
        }

        public static int CommonListElementCountLinq<T>(this List<T> list, object element) // Метод-расширение для поиска в обобщённой коллекции
        {
            var equalsList = list.Count(e => e.Equals(element));
            return equalsList;
        }
    }

}
