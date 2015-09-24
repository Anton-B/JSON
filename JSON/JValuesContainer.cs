using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSON
{
    public abstract class JValuesContainer: JAbstractObject, IEnumerable<JAbstractObject>
    {
        public void AddValue<T>(T value, string name = null)
        {
            AddValue((JAbstractObject)new JValue<T>(value, name));
        }

        public virtual void AddValue(JAbstractObject value)
        {
            value.Parent = this;
        }

        public abstract IEnumerator<JAbstractObject> GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
