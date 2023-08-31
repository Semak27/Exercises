﻿using System;

namespace KeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValueStore keyValueStore = new KeyValueStore(6);
            keyValueStore.NewKVP("1", "Test");
            Console.WriteLine(keyValueStore.GetKVP("1"));
        }
    }
}