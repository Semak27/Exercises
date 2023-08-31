using KeyValueStore;
namespace KeyValueStoreTests
{
    [TestClass]
    public class KeyValueStoreTests
    {
        [TestMethod]
        public void InsertingKeysAndValues()
        {
            string key  = "key";
            string value = "value";

            KeyValueStore.KeyValueStore keyValueStore = new KeyValueStore.KeyValueStore(6);
            keyValueStore.NewKVP(key, value);

            string expectedResultValue = "value";
            string actualResultvalue = keyValueStore.GetKVP(key);

            Assert.AreEqual(expectedResultValue, actualResultvalue, "Fehler beim Einfügen des Key-Value-Pairs");
        }



        [TestMethod]
        public void ArgumentExceptionWhenTryingToInsertNull()
        {
            string inputKey = "key";
            string? inputKeyNull = null;
            string inputValue = "value";
            string? inputValueNull = null;

            KeyValueStore.KeyValueStore keyValueStore = new KeyValueStore.KeyValueStore(6);

            //Insert Null in NewKVP()
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.NewKVP(inputKey, inputValueNull));
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.NewKVP(inputKeyNull, inputValue));
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.NewKVP(inputKeyNull, inputValueNull));

            //Insert Null in GetKVP()
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.GetKVP(inputKeyNull));

            //Insert Null in UpdateKVP
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.UpdateKVP(inputKey, inputValueNull));
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.UpdateKVP(inputKeyNull, inputValue));
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.UpdateKVP(inputKeyNull, inputValueNull));

            //Insert Null in DeleteKVP()
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.DeleteKVP(inputKeyNull));
        }

        [TestMethod]
        public void ArgumentExceptionWhenTryingToInsertTheSameKeyTwice()
        {
            string inputKey1 = "key";
            string inputValue1 = "value1";
            string inputKey2 = inputKey1;
            string inputValue2 = "value2";

            KeyValueStore.KeyValueStore keyValueStore = new KeyValueStore.KeyValueStore(6);

            keyValueStore.NewKVP(inputKey1, inputValue1);
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.NewKVP(inputKey2, inputValue2));
        }

        [TestMethod]
        public void ArgumentExceptionWhenTryingToInsertIntoAFullArray()
        {
            string inputKey1 = "key1";
            string inputValue1 = "value1";
            string inputKey2 = "key2";
            string inputValue2 = "value2";

            KeyValueStore.KeyValueStore keyValueStore = new KeyValueStore.KeyValueStore(1);

            keyValueStore.NewKVP(inputKey1, inputValue1);
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.NewKVP(inputKey2, inputValue2));
        }

        [TestMethod]
        public void ArgumentExceptionWhenTryingToRetrieveValuesWithAnInvalidKey()
        {
            string inputKey = "key";
            string inputValue = "value";
            string falseKey = "falseKey";

            KeyValueStore.KeyValueStore keyValueStore = new KeyValueStore.KeyValueStore(6);
            keyValueStore.NewKVP(inputKey, inputValue);
            Assert.ThrowsException<System.ArgumentException>(() => keyValueStore.GetKVP(falseKey));
        }
    }
}