using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloseCustomers.Core;
using System.Linq;

namespace CloseCustomers.Test
{
    [TestClass]
    public class ArrayHelperTest
    {
        #region GetIntegerArray Method

        [TestMethod]
        public void EmptyArray()
        {
            object[] input = { };

            int[] expectedOutput = { };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        [TestMethod]
        public void NoIntegerArray()
        {
            object[] input = {'a','b',"test", new object[] {} };

            int[] expectedOutput = { };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        [TestMethod]
        public void EqualArray()
        {
            object[] input = { 1,2,3};

            int[] expectedOutput = { 1, 2, 3 };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        [TestMethod]
        public void MamushkaArray()
        {
            object[] input = { new object[] { new object[] { new object[] { new object[] { 1 } } } } };

            int[] expectedOutput = { 1 };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        [TestMethod]
        public void NestedIntegerArray()
        {
            object[] input = { 1, 2, 3, 4, 5, new object[] { 6, 7, new object[] { 8, 9 } }, new object[] { 10 } };

            int[] expectedOutput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        [TestMethod]
        public void MixedArray()
        {
            object[] input = { 1, 2, 4, new object[] { 6, 7, new object[] { 9 } }, new object[] { 'a', "b" } };

            int[] expectedOutput = { 1, 2, 4, 6, 7, 9 };

            var ouput = ArrayHelper.GetIntegerArray(input);

            Assert.IsTrue(expectedOutput.SequenceEqual(ouput));
        }

        #endregion GetIntegerArray Method
    }
}
