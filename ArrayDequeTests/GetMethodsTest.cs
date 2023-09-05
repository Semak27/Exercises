using System.Net.Http.Headers;
using ArrayDeque;

namespace ArrayDequeTests
{
    [TestClass]
    public class GetMethodsTest
    {
        ArrayDeque <string> testDeque;

        public GetMethodsTest()
        {
            testDeque = new ArrayDeque<string>();
        }

        [TestMethod]
        public void PeekFirstTests()
        {
            //Peek when the first position is empty
            Assert.AreEqual(default(string), testDeque.PeekFirst(), "Error when trying to access an empty position");

            //Peek with a filled first position
            testDeque.Offer("a");
            testDeque.Offer("b");
            testDeque.Push("c");
            string actualResult = testDeque.PeekFirst();
            Assert.AreEqual("c", actualResult, "Error while reading the first element");
        }

        [TestMethod]
        public void PeekLastTests()
        {
            //Peek when the last position is empty
            Assert.AreEqual(default(string), testDeque.PeekLast(), "Error when trying to access an empty position");

            //Peek with a filled last position
            testDeque.Offer("a");
            testDeque.Offer("b");
            string actualResult = testDeque.PeekLast();
            Assert.AreEqual("b", actualResult, "Error while reading the last element");
        }

        [TestMethod]
        public void SizeTest()
        {
            testDeque.Offer("a");
            testDeque.Offer("b");
            testDeque.Offer("c");
            int expectedResult = 3;
            int actualResult = testDeque.Size();
            Assert.AreEqual(expectedResult, actualResult, "Error while calculating the size");
        }

        [TestMethod]
        public void CapacityTest()
        {
            testDeque.Offer("a");
            testDeque.Offer("b");
            testDeque.Offer("c");
            testDeque.Offer("d");
            testDeque.Offer("e");
            testDeque.Offer("f");
            testDeque.Offer("g");
            testDeque.Offer("h");
            testDeque.Offer("i");
            int expectedResult = 16;
            int actualResult = testDeque.Capacity();
            Assert.AreEqual(expectedResult, actualResult, "Error while calculating the capacity");
        }
    }
}