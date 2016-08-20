using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = {0,  1,  2,  3,  4,  5,  6,  7,  8, 9,
                            10, 11, 12, 13, 14, 15, 16, 17, 18};
            int pivotIndex = QuickSort.Utils.ReturnPivotIndex(array, 0, array.Length - 1);
            Assert.AreEqual(9, pivotIndex);
        }
    }
}
