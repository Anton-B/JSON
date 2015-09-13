using System.Collections.Generic;

namespace JSON
{
    class JArray : JAbstractObject
    {
        public List<JAbstractObject> arrayList = new List<JAbstractObject>();

        public override JAbstractObject this[object index]
        {
            get
            {
                return arrayList[(int)index];
            }
        }
    }
}