using System;

namespace JSON
{
    class JValue<T> : JAbstractObject
    {
        public T Value { get; set; }

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
