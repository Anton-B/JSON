using System.Collections;
using System.Collections.Generic;

namespace JSON
{
    class JArray : JValuesContainer
    {
        private List<JAbstractObject> arrayList = new List<JAbstractObject>();

        public override JAbstractObject this[object index]
        {
            get
            {
                return arrayList[(int)index];
            }
        }

        public override void AddValue(JAbstractObject value)
        {
            arrayList.Add(value);
            base.AddValue(value);
        }

        public override IEnumerator<JAbstractObject> GetEnumerator()
        {
            return arrayList.GetEnumerator();
        }
    }
}