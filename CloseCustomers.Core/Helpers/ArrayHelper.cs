using System.Collections.Generic;

namespace CloseCustomers.Core
{
    public static class ArrayHelper
    {
        public static int[] GetFlatIntegerArray(object[] nestedArray)
        {
            var flatArray = new List<int>();

            for (var i = 0; i < nestedArray.Length; i++)
            {
                if (nestedArray[i].GetType() == typeof(int))
                    flatArray.Add((int)nestedArray[i]);
                else

                    if (nestedArray[i].GetType() == typeof(object[]))
                        flatArray.AddRange(GetFlatIntegerArray((object[])nestedArray[i]));
            }

            return flatArray.ToArray();
        }
    }
}
