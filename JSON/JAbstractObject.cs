using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    abstract class JAbstractObject
    {
        public JValue Parent { get; set; } = null;
        public string Value { get; set; }
        public JValue[] values = new JValue[0];

        public JAbstractObject this[string str]
        {
            get
            {
               return Find(this, str);
            }
        }

        public JAbstractObject Find(JAbstractObject abstrObj, string name)
        {
            for (int i = 0; i < abstrObj.values.Length; i++)
            {
                if (abstrObj.values[i].Name == name)
                    return abstrObj.values[i];
                else
                {
                    JAbstractObject obj = Find(abstrObj.values[i], name);
                    if (obj != null)
                        return obj;
                }     
            }
            return null;
        }
    }
}
