using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValueStore
{
    class KeyValueStore
    {
        KeyValuePair keyValuePair;
        public KeyValueStore(int size)
        {
            keyValuePair = new KeyValuePair(size);
        }

        //Insert new Key-Value-Pair
        public void NewKVP(string key, string value)
        { 
            CheckForNull(key, value);
            IsKeyAlreadyTaken(key);
            int position = SearchKeyInList(null);
            keyValuePair.KeyValueArray[position, 0] = key;
            keyValuePair.KeyValueArray[position, 1] = value;
        }

        //Get value from key
        public string GetKVP(string key)
        {
            CheckForNull(key);
            int position = SearchKeyInList(key);
            return keyValuePair.KeyValueArray[position, 1];
        }

        //Update value from key with newValue
        public void UpdateKVP(string key, string newValue)
        {
            CheckForNull(key, newValue);
            int position = SearchKeyInList(key);
            keyValuePair.KeyValueArray[position, 1] = newValue;
        }

        //Delete Key-Value-Pair
        public void DeleteKVP(string key)
        {
            CheckForNull(key);
            int position = SearchKeyInList(key);
            keyValuePair.KeyValueArray[position, 1] = null;
            keyValuePair.KeyValueArray[position, 0] = null;
        }

        //Search if a key is in the array (get/update/delete)
        private int SearchKeyInList(string key)
        {
            for(int i = 0; i < keyValuePair.KeyValueArray.GetLength(0); i++)
            {
                if(keyValuePair.KeyValueArray[i, 0] == key)
                {
                    return i;
                }
            }
            throw new ArgumentException("Key was not found!");
        }

        //Check if null is handed over for two parameters
        private void CheckForNull(string key, string value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentException("Key and Value are not allowed to be null");
            }
        }





        //Check if null is handed over for one parameters
        private void CheckForNull(string key)
        {
            if (key == null)
            {
                throw new ArgumentException("Key is not allowed to be null");
            }
        }

        //Check if a key is already taken in the array (new)
        private void IsKeyAlreadyTaken(string key)
        {
            for (int i = 0; i < keyValuePair.KeyValueArray.GetLength(0); i++)
            {
                if (keyValuePair.KeyValueArray[i, 0] == key)
                {
                    throw new ArgumentException("Key is already taken!");
                }
            }
        }
    }
}
