using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JValue : JAbstractObject
    {
        public string Name { get; set; } = null;
        public JAbstractObject Type { get; set; } = null;

        public virtual void Add(JValue obj)
        {
            obj.Parent = this;
            Array.Resize<JValue>(ref this.values, this.values.Length + 1);
            this.values[this.values.Length - 1] = obj;
        }
    }
}
