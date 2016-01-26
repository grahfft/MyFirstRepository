using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAlgorithms
{
    [TestClass]
    public class RecursiveBinarySearchTests
    {
        [TestMethod]
        public void TestAdd()
        {
            RecursiveBinarySearchTree<int> tree = new RecursiveBinarySearchTree<int>();

            TreeNode<int> node1 = new TreeNode<int>(1);
            TreeNode<int> node2 = new TreeNode<int>(2);
            TreeNode<int> node3 = new TreeNode<int>(3);
            TreeNode<int> node4 = new TreeNode<int>(4);

            tree.Add(node4.Value);
            tree.Add(node2.Value);
            tree.Add(node3.Value);
            tree.Add(node1.Value);

            TreeNode<int> node5 = new TreeNode<int>(5);
            TreeNode<int> node6 = new TreeNode<int>(6);
            TreeNode<int> node7 = new TreeNode<int>(7);
            TreeNode<int> node8 = new TreeNode<int>(8);

            tree.Add(node6.Value);
            tree.Add(node5.Value);
            tree.Add(node8.Value);
            tree.Add(node7.Value);

            TreeNode<int> testNode = tree.FindNode(node2.Value);

            Assert.IsNotNull(testNode, "Couldn't find test node");
            Assert.AreEqual(testNode.Value.CompareTo(node2.Value), 0, "Test node does not match value");
            Assert.IsNotNull(testNode.LeftNode, "LeftNode is null");
            Assert.IsNotNull(testNode.RightNode, "Right node is null");
           
            TreeNode<int> leftNode = testNode.LeftNode;
            TreeNode<int> rightNode = testNode.RightNode;

            Assert.AreEqual(leftNode.Value.CompareTo(node1.Value), 0, "left node does not match expected value");
            Assert.AreEqual(rightNode.Value.CompareTo(node3.Value), 0, "right node does not match expected value");

            Assert.AreEqual(leftNode.ParentNode.Value.CompareTo(node2.Value), 0);
            Assert.AreEqual(rightNode.ParentNode.Value.CompareTo(node2.Value), 0);

            testNode = tree.FindNode(node6.Value);

            Assert.IsNotNull(testNode, "Couldn't find test node");
            Assert.AreEqual(testNode.Value.CompareTo(node6.Value), 0, "Test node does not match value");
            Assert.IsNotNull(testNode.LeftNode, "LeftNode is null");
            Assert.IsNotNull(testNode.RightNode, "Right node is null");

            leftNode = testNode.LeftNode;
            rightNode = testNode.RightNode;

            Assert.AreEqual(leftNode.Value.CompareTo(node5.Value), 0, "left node does not match expected value");
            Assert.AreEqual(rightNode.Value.CompareTo(node8.Value), 0, "right node does not match expected value");

            Assert.AreEqual(leftNode.ParentNode.Value.CompareTo(node6.Value), 0);
            Assert.AreEqual(rightNode.ParentNode.Value.CompareTo(node6.Value), 0);
        }

        [TestMethod]
        public void RemoveALeaf()
        {
            const int removeValue = 1;
            const int expectedParentValue = 2;

            RecursiveBinarySearchTree<int> tree = this.ConstructTree();

            tree.Remove(removeValue);

            TreeNode<int> testNode = tree.FindNode(removeValue);
            Assert.IsNull(testNode);

            testNode = tree.FindNode(expectedParentValue);
            Assert.IsNotNull(testNode);
            Assert.AreEqual(testNode.Value.CompareTo(expectedParentValue), 0);
            Assert.IsNull(testNode.LeftNode);
        }

        /// <summary>
        /// Remove a node with only a left child
        /// </summary>
        [TestMethod]
        public void RemoveCaseOne()
        {
            const int removeValue = 2;
            const int expectedParentValue = 4;
            const int expectedLeftNodeValue = 1;

            RecursiveBinarySearchTree<int> tree = this.ConstructTree();

            TreeNode<int> testNode = tree.FindNode(removeValue);

            tree.Remove(testNode.RightNode.Value);
            tree.Remove(removeValue);

            testNode = tree.FindNode(expectedParentValue);
            Assert.IsNotNull(testNode);
            Assert.IsNotNull(testNode.LeftNode);
            Assert.AreEqual(testNode.LeftNode.Value.CompareTo(expectedLeftNodeValue), 0);
        }

        /// <summary>
        /// Removes a node with a right child; Right child has no left child itself
        /// </summary>
        [TestMethod]
        public void RemoveCaseTwo()
        {
            const int removeValue = 2;
            const int expectedParentValue = 4;
            const int expectedLeftNodeValue = 3;

            RecursiveBinarySearchTree<int> tree = this.ConstructTree();

            tree.Remove(removeValue);

            TreeNode<int> testNode = tree.FindNode(expectedParentValue);
            Assert.IsNotNull(testNode);
            Assert.IsNotNull(testNode.LeftNode);
            Assert.AreEqual(testNode.LeftNode.Value.CompareTo(expectedLeftNodeValue), 0);
        }

        /// <summary>
        /// Removes a node with a right child; Right child has no left child itself
        /// </summary>
        [TestMethod]
        public void RemoveCaseThree()
        {
            const int removeValue = 6;
            const int expectedParentValue = 4;
            const int expectedRightNodeValue = 7;

            RecursiveBinarySearchTree<int> tree = this.ConstructTree();

            TreeNode<int> expectedLeafNode = tree.FindNode(expectedRightNodeValue).ParentNode;

            tree.Remove(removeValue);

            TreeNode<int> testNode = tree.FindNode(expectedParentValue);
            Assert.IsNotNull(testNode);
            Assert.IsNotNull(testNode.RightNode);
            Assert.AreEqual(testNode.RightNode.Value.CompareTo(expectedRightNodeValue), 0);

            testNode = tree.FindNode(expectedLeafNode.Value);
            Assert.IsNotNull(testNode);
            Assert.IsNull(testNode.LeftNode);
            Assert.IsNull(testNode.RightNode);
            Assert.AreEqual(testNode.ParentNode.Value.CompareTo(expectedRightNodeValue), 0);
        }

        private RecursiveBinarySearchTree<int> ConstructTree()
        {
            RecursiveBinarySearchTree<int> tree = new RecursiveBinarySearchTree<int>();

            TreeNode<int> node1 = new TreeNode<int>(1);
            TreeNode<int> node2 = new TreeNode<int>(2);
            TreeNode<int> node3 = new TreeNode<int>(3);
            TreeNode<int> node4 = new TreeNode<int>(4);

            tree.Add(node4.Value);
            tree.Add(node2.Value);
            tree.Add(node3.Value);
            tree.Add(node1.Value);

            TreeNode<int> node5 = new TreeNode<int>(5);
            TreeNode<int> node6 = new TreeNode<int>(6);
            TreeNode<int> node7 = new TreeNode<int>(7);
            TreeNode<int> node8 = new TreeNode<int>(8);

            tree.Add(node6.Value);
            tree.Add(node5.Value);
            tree.Add(node8.Value);
            tree.Add(node7.Value);

            return tree;
        }
    }
}
