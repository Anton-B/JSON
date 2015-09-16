namespace JSON
{
    abstract class JAbstractObject
    {
        public string Name { get; set; }
        public JAbstractObject Parent { get; set; }

        public abstract JAbstractObject this[object index] { get; }
    }
}
