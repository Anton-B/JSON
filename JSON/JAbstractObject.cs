namespace JSON
{
    abstract class JAbstractObject
    {
        public string Name { get; set; }
        public JAbstractObject Parent { get; protected internal set; }

        public abstract JAbstractObject this[object index] { get; }
    }
}
