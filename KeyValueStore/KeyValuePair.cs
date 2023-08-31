﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValueStore
{
    public class KeyValuePair
    {
        public KeyValuePair(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}