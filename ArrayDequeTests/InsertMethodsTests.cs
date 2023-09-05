using ArrayDeque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDequeTests
{
    [TestClass]
    public class InsertMethodsTests
    {
        ArrayDeque<string> testDeque;
        ArrayDeque<string> filledDeque;
        public InsertMethodsTests()
        {
            testDeque = new ArrayDeque<string>();
            filledDeque = new ArrayDeque<string>();
            filledDeque.Offer("a");
            filledDeque.Offer("b");
            filledDeque.Offer("c");
            filledDeque.Offer("d");
            filledDeque.Offer("e");
            filledDeque.Offer("f");
            filledDeque.Offer("g");
            filledDeque.Offer("h");
        }

        [TestMethod]
        public void OfferInAnEmptyArrayTest()
        {
            testDeque.Offer("a");
            Assert.AreEqual(testDeque.PeekFirst(), testDeque.PeekLast(), "Error on offering into the deque");
        }

        [TestMethod]
        public void PushIntoAnEmptyArrayTest()
        {
            testDeque.Push("a");
            Assert.AreEqual(testDeque.PeekFirst(), testDeque.PeekLast(), "Error on offering into the deque");
        }

        [TestMethod]
        public void WrapAroundForOfferTest()
        {
            //Wrap Around for offer
            filledDeque.Poll();
            filledDeque.Offer("i");
            string expectedPeekFirst = "b";
            string expectedPeekLast = "i";

            //Testing that both indices and values are adapted correctly
            Assert.AreEqual(expectedPeekFirst, filledDeque.PeekFirst(), "Error with head index while performing wrap around for offer-method");
            Assert.AreEqual(expectedPeekLast, filledDeque.PeekLast(), "Error with tail index while performing wrap around for offer-method");
        }

        [TestMethod]
        public void WrapAroundForPush()
        {
            //Wrap Around for Push
            testDeque.Push("a");
            testDeque.Push("b");
            string expectedPeekFirst = "b";
            string expectedPeekLast = "a";

            //Testing that both indices and values are adapted correctly
            Assert.AreEqual(expectedPeekFirst, testDeque.PeekFirst(), "Error with head index while performing wrap around for push-method");
            Assert.AreEqual(expectedPeekLast, testDeque.PeekLast(), "Error with tail index while performing wrap around for push-method");
        }

        [TestMethod]
        public void ResizeForOffer()
        {
            //Resizig when the array is full and the method "offer" is used
            int initialCapacity = filledDeque.Capacity();
            int expectedCapacity = 2 * initialCapacity;

            filledDeque.Offer("X");
            int newCapacity = filledDeque.Capacity();

            //Testing if the capacity is correctly adapted
            Assert.AreEqual(expectedCapacity, newCapacity, "Error while resizing the array for the Push-Method");

            //Testing if the order of the resized array is correct
            Assert.AreEqual(filledDeque.PeekLast(), "X", "Error with sorting the new array");
        }

        [TestMethod]
        public void ResizeForPush()
        {
            //Resizig when the array is full and the method "push" is used
            int initialCapacity = filledDeque.Capacity();
            int expectedCapacity = 2 * initialCapacity;

            filledDeque.Push("X");
            int newCapacity = filledDeque.Capacity();

            //Testing if the capacity is correctly adapted
            Assert.AreEqual(expectedCapacity, newCapacity, "Error while resizing the array for the Push-Method");

            //Testing if the order of the resized array is correct
            Assert.AreEqual(filledDeque.PeekFirst(), "X", "Error with sorting the new array");
        }
    }
}
