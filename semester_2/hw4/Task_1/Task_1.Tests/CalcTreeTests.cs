using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Tests
{
    [TestClass]
    public class CalcTreeTests
    {
        private CalcTree tree = new CalcTree();

        [TestMethod]
        public void ExpressionTest1()
        {
            tree.Build("(* (+ 1 1) 2)");
            Assert.AreEqual(4, tree.CalculateTree());
        }

        [TestMethod]
        public void ExpressionTest2()
        {
            tree.Build("(* (- 2 1) (+ 1 1))");
            Assert.AreEqual(2, tree.CalculateTree());
        }

        [TestMethod]
        public void ExpressionTest3()
        {
            tree.Build("(/ (* (+ (* 7 3) 4) (- (* 2 3) 2)) (- 10 6))");
            Assert.AreEqual(25, tree.CalculateTree());
        }

        [TestMethod]
        public void ExpressionTest4()
        {
            tree.Build("5");
            Assert.AreEqual(5, tree.CalculateTree());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ExpressionTest5()
        {
            tree.Build("(/ 1 0)");
            tree.CalculateTree();
        }

        [TestMethod]
        public void PrintTest1()
        {
            tree.Build("(* (+ 1 1) 2)");
            Assert.AreEqual("( * ( + 1 1 ) 2 )", tree.PrintTree());
        }

        [TestMethod]
        public void PrintTest2()
        {
            tree.Build("(* (- 2 1) (+ 1 1))");
            Assert.AreEqual("( * ( - 2 1 ) ( + 1 1 ) )", tree.PrintTree());
        }

        [TestMethod]
        public void PrintTest3()
        {
            tree.Build("(/ (* (+ (* 7 3) 4) (- (* 2 3) 2)) (- 10 6))");
            Assert.AreEqual("( / ( * ( + ( * 7 3 ) 4 ) ( - ( * 2 3 ) 2 ) ) ( - 10 6 ) )", tree.PrintTree());
        }
    }
}
