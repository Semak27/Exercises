﻿using System;

namespace KeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValueStore keyValueStore = new KeyValueStore(6);
            keyValueStore.NewKVP("1", "Test");
            keyValueStore.GetKVP("1");
            Console.WriteLine(keyValueStore.GetKVP("1"));
        }
    }
}