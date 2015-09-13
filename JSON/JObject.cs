﻿using System;
using System.Collections.Generic;

namespace JSON
{
    class JObject : JAbstractObject
    {
        public Dictionary<string, JAbstractObject> objectDict = new Dictionary<string, JAbstractObject>();

        public override JAbstractObject this[object key]
        {
            get
            {
                var stringKey = key as string;
                if (stringKey == null)
                    throw new ArgumentException();
                return this[stringKey];
            }
        }

        public JAbstractObject this[string str]
        {
            get
            {
                JAbstractObject val;
                objectDict.TryGetValue(str, out val);
                return val;
            }
        }
    }
}
