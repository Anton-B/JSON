using System;

namespace JSON
{
    public abstract class JValue : JAbstractObject
    {
        public object Data { get; set; }

        public JValue() { }

        public JValue(object value)
        {
            Data = value;
        }

        public override JAbstractObject this[object index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public class JValue<T>: JValue
    {
        public T Value { get { return (T)Data; } set { Data = value; } }

        public JValue(T value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return Name + ": \"" + Value + "\"";
        }
    }
}
