using System;
using System.Collections;
using System.Collections.Generic;

namespace JSON
{
    public class JObject : JValuesContainer
    {
        private Dictionary<string, JAbstractObject> objectDict = new Dictionary<string, JAbstractObject>();

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

        public override void AddValue(JAbstractObject value)
        {
            objectDict.Add(value.Name, value);
            base.AddValue(value);
        }

        public override IEnumerator<JAbstractObject> GetEnumerator()
        {
            return objectDict.Values.GetEnumerator();
        }
    }
}
