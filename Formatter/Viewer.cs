using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSON;
using System.Windows.Controls;

namespace JSON_Formatter
{
    class Viewer
    {
        public static TreeViewItem BuildTree(string jsonString)
        {
            var json = JDocument.Load(jsonString);
            return AddToTree(json.Root, 0);
        }

        private static TreeViewItem AddToTree(JAbstractObject abstrObj, int index)
        {
            TreeViewItem treeItem = new TreeViewItem();
            StringBuilder header = new StringBuilder();
            if (abstrObj.Parent is JArray)
                header.Append("[" + index + "]: ");
            else if (abstrObj.Parent == null)
                header.Append("JSON");
            else
                header.Append(abstrObj.Name);
            if (abstrObj is JObject)
            {
                foreach (JAbstractObject jao in (JObject)abstrObj)
                    treeItem.Items.Add(AddToTree(jao, 0));
                header.Append(" { }");
            }
            else if (abstrObj is JArray)
            {
                int ind = 0;
                foreach (JAbstractObject jao in (JArray)abstrObj)
                {
                    treeItem.Items.Add(AddToTree(jao, ind));
                    ind++;
                }
                header.Append(" [" + ind + "]");
            }
            else
            {
                if (!(abstrObj.Parent is JArray))
                    header.Append(": ");
                if (abstrObj is JValue<string>)
                    header.Append("\"" + ((JValue<string>)abstrObj).Value.ToString() + "\"");
                else if (abstrObj is JValue<int>)
                    header.Append(((JValue<int>)abstrObj).Value.ToString());
                else if (abstrObj is JValue<double>)
                    header.Append(((JValue<double>)abstrObj).Value.ToString());
                else if (abstrObj is JValue<bool>)
                    header.Append(((JValue<bool>)abstrObj).Value.ToString().ToLower());
                else if (abstrObj is JValue<object>)
                    header.Append("null");
                treeItem.Header = header.ToString();
            }
            treeItem.Header = header;
            return treeItem;
        }
    }
}
