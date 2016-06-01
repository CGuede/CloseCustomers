using System.Collections.Generic;

namespace CloseCustomers.Core
{
    public static class ArrayHelper
    {
        public static int[] GetIntegerArray(object[] input)
        {
            var output = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i].GetType() == typeof(int))
                    output.Add((int)input[i]);
                else

                    if (input[i].GetType() == typeof(object[]))
                        output.AddRange(GetIntegerArray((object[])input[i]));
            }

            return output.ToArray();
        }
    }
}
