using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> tree;

        [TestInitialize]
        public void Initialize()
        {
            tree = new BinarySearchTree<int>();
        }

        [TestMethod]
        public void AddOneValueTest()
        {
            tree.AddValue(0);
        }

        [TestMethod]
        public void AddSomeValueTest()
        {
            BuildTree();
        }

        [TestMethod]
        [ExpectedException(typeof(AddContainedValueException))]
        public void AddContainedValueTest()
        {
            BuildTree();
            tree.AddValue(5);
        }

        [TestMethod]
        public void IsContainedInEmptyTreeTest()
        {
            Assert.IsFalse(tree.IsContained(0));
        }

        [TestMethod]
        public void IsContainedTest1()
        {
            BuildTree();

            for (var i = 1; i <= 10; ++i)
            {
                Assert.IsTrue(tree.IsContained(i));
            }
        }

        [TestMethod]
        public void IsContainedTest2()
        {
            BuildTree();

            for (var i = 1; i <= 5; ++i)
            {
                tree.RemoveValue(i);
            }

            for (var i = 1; i <= 10; ++i)
            {
                if (i <= 5)
                {
                    Assert.IsFalse(tree.IsContained(i));
                }
                else
                {
                    Assert.IsTrue(tree.IsContained(i));
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotExistedValueException))]
        public void RemoveNotExistedValueTest()
        {
            BuildTree();
            tree.RemoveValue(-1);
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            BuildTree();
            var count = 0;

            foreach (var element in tree)
            {
                ++count;
            }

            Assert.AreEqual(10, count);
        }

        /// <summary>
        /// Building good tree of ten nodes
        /// </summary>
        private void BuildTree()
        {
            tree.AddValue(6);
            tree.AddValue(3);
            tree.AddValue(8);
            tree.AddValue(2);
            tree.AddValue(4);
            tree.AddValue(1);
            tree.AddValue(5);
            tree.AddValue(7);
            tree.AddValue(10);
            tree.AddValue(9);
        }
    }
}
