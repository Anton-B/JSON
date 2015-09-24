using System;

namespace JSON
{
    public class JValue<T> : JAbstractObject
    {
        public T Value { get; set; }

        public JValue(T value, string name)
        {
            Value = value;
            Name = name;
        }

        public override JAbstractObject this[object index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return "value: " + Value;
        }
    }
}
