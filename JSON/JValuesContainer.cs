namespace JSON
{
    abstract class JValuesContainer: JAbstractObject
    {
        public void AddValue<T>(T value, string name = null)
        {
            AddValue((JAbstractObject)new JValue<T>(value, name));
        }

        public virtual void AddValue(JAbstractObject value)
        {
            value.Parent = this;
        }
    }
}
