using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValueStore
{
    public class KeyValueStore
    {
        KeyValuePair[] keyValueArray;
        public KeyValueStore(int size)
        {
            keyValueArray = new KeyValuePair[size];
        }

        //Insert new Key-Value-Pair
        public void NewKVP(string key, string value)
        {
            CheckForNull(key, value);
            IsKeyAlreadyTaken(key);
            int position = GetInsertPosition();
            KeyValuePair keyValuePair = new KeyValuePair(key, value);
            keyValueArray[position] = keyValuePair;
        }

        //Get value from key
        public string GetKVP(string key)
        {
            CheckForNull(key);
            int position = SearchKeyInList(key);
            return keyValueArray[position].Value;
        }

        ////Update value from key with newValue
        public void UpdateKVP(string key, string newValue)
        {
            CheckForNull(key, newValue);
            int position = SearchKeyInList(key);
            keyValueArray[position].Value = newValue;
        }

        ////Delete Key-Value-Pair
        public void DeleteKVP(string key)
        {
            CheckForNull(key);
            int position = SearchKeyInList(key);
            keyValueArray[position] = null;
        }

        //Search if a key is in the array (get/update/delete)
        private int SearchKeyInList(string key)
        {
            int positionOfKey = 0;

            foreach (KeyValuePair item in keyValueArray)
            {
                if (item != null && item.Key == key)
                {
                    return positionOfKey;
                }
                positionOfKey++;
            }


            throw new ArgumentException("Key was not found!");
        }

        //Getting the next free position in the array to insert
        private int GetInsertPosition()
        {
            int positionOfKey = 0;

            foreach (KeyValuePair item in keyValueArray)
            {
                if (item == null)
                {
                    return positionOfKey;
                }
                positionOfKey++;
            }


            throw new ArgumentException("Array is too small or already full");
        }

        //Check if null is handed over for two parameters
        private void CheckForNull(string key, string value)
        {
            if (key == null || value == null)
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
            foreach (KeyValuePair item in keyValueArray)
            {
                if (item != null && item.Key == key)
                {
                    throw new ArgumentException("Key is already taken!");
                }
            }

        }
    }
}