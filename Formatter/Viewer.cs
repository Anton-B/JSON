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
            int ind = 0;
            var obj = abstrObj as JValuesContainer;
            if (obj != null)
                foreach (JAbstractObject jao in obj)
                {
                    treeItem.Items.Add(AddToTree(jao, ind));
                    ind++;
                }
            treeItem.Header = GetHeader(abstrObj, index);
            return treeItem;
        }

        private static string GetHeader(JAbstractObject abstrObj, int ind)
        {
            string s = (abstrObj.Parent is JArray) ? "[" + ind + "]" : abstrObj.Name;
            var arr = abstrObj as JArray;
            if (arr != null)
                return String.Format("{0} [{1}]", (abstrObj.Parent == null) ? "JSON" : s, arr.Count());
            var obj = abstrObj as JObject;
            if (obj != null)
                return String.Format("{0} {{ }}", (abstrObj.Parent == null) ? "JSON" : s);
            var val = abstrObj as JValue;
            var str = val.Data as string;
            if (str != null)
                return String.Format("{0}: \"{1}\"", s, val.Data);
            if (val.Data is bool)
                return String.Format("{0}: {1}", s, val.Data.ToString().ToLower());
            else if (val.Data == null)
                return String.Format("{0}: null", s);
            return String.Format("{0}: {1}", s, val.Data);
        }
    }
}
