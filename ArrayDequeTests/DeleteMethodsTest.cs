using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayDeque;

namespace ArrayDequeTests
{
    [TestClass]
    public class DeleteMethodsTest
    {
        ArrayDeque<string> testDeque;

        public DeleteMethodsTest()
        {
            testDeque = new ArrayDeque<string>();
        }

        [TestMethod]
        public void PollFirstTests()
        {
            //Try to poll first item when the deque is empty
            Assert.AreEqual(testDeque.Poll(), null, "Error when trying to delete from an empty deque");

            //Poll first item from a filled deque
            testDeque.Offer("a");
            testDeque.Offer("b");
            testDeque.Push("c");
            string expectedResult = null;
            testDeque.Poll();
            string actualResult = testDeque.PeekFirst();
            Assert.AreEqual(actualResult, expectedResult, "Error while deleting the first element");
        }

        [TestMethod]
        public void PollLastTests()
        {
            //Try to poll last item when the deque is empty
            Assert.AreEqual(testDeque.PollLast(), null, "Error when trying to delete from an empty deque");

            //Poll last item from a filled deque
            testDeque.Offer("a");
            testDeque.Offer("b");
            testDeque.Push("c");
            string expectedResult = null;
            testDeque.PollLast();
            string actualResult = testDeque.PeekLast();
            Assert.AreEqual(actualResult, expectedResult, "Error while deleting the last element");
        }
    }
}
