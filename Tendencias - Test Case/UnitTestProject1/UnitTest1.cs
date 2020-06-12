using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.ContainsRange("[2,7)", "[3,5]"));
        }
        [TestMethod]
        public void Test2()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.ContainsRange("[2,7)", "[6,6]"));
        }
        [TestMethod]
        public void Test3()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.ContainsRange("[2,7)", "[8,12]"));
        }
        [TestMethod]
        public void Test4()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.ContainsRange("[2,4)", "{7,1,5]"));
        }
        [TestMethod]
        public void Test5()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.ContainsRange("[2,4)", "{10,-2,7]"));
        }
        [TestMethod]
        public void Test6()
        {
            KataRange.Range range = new KataRange.Range();
            CollectionAssert.AreEqual(range.endPoints("[5, 11]"), range.endPoints("[5, 11]"));
        }
        [TestMethod]
        public void Test7()
        {
            KataRange.Range range = new KataRange.Range();
            CollectionAssert.AreEqual(range.endPoints("[7, 10]"), range.endPoints("[7, 10]"));
        }
        [TestMethod]
        public void Test8()
        {
            KataRange.Range range = new KataRange.Range();
            CollectionAssert.AreNotEqual(range.endPoints("[5, 1]"), range.endPoints("[1, 2]"));
        }
        [TestMethod]
        public void Test9()
        {
            KataRange.Range range = new KataRange.Range();
            int[] arr = { 2, 3, 4, 5, 6, 7, 8, 9 };
            CollectionAssert.AreEqual(range.getAllPoints("[2, 10)"), arr);
        }
        [TestMethod]
        public void Test10()
        {
            KataRange.Range range = new KataRange.Range();
            int[] arr = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 
                12, 13, 14, 15, 16, 17, 18, 19 };
            CollectionAssert.AreEqual(range.getAllPoints("[2, 20)"), arr);
        }
        [TestMethod]
        public void Test11()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.overlapsRange("[2,10)", "[1,8]"));
        }
        [TestMethod]
        public void Test12()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.overlapsRange("[2,10)", "[1,5]"));
        }
        [TestMethod]
        public void Test13()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.overlapsRange("[2,10)", "[1,2]"));
        }
        [TestMethod]
        public void Test14()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.equals("[5,11)","[5,11)"));
        }
        [TestMethod]
        public void Test15()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.equals("[6,11)", "[6,11)"));
        }
        [TestMethod]
        public void Test16()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.equals("[5,11)", "[7,5)"));
        }
        [TestMethod]
        public void Test17()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.equals("[10,25)", "[10,22)"));
        }
        [TestMethod]
        public void Test18()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsFalse(range.notEquals("[10,25)", "[10,22)"));
        }
        [TestMethod]
        public void Test19()
        {
            KataRange.Range range = new KataRange.Range();
            Assert.IsTrue(range.notEquals("[10,25)", "[10,25)"));
        }
    }
}
