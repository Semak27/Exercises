using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValueStore
{
    public class KeyValuePair
    {
        public KeyValuePair(int arraySize)
        {
            KeyValueArray = new string[arraySize, 2];
        }

        //array to save the Key-Value-Pairs
        public string[,] KeyValueArray { get; set; }
    }
}
