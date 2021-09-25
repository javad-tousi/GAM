using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Modules
{
    public class QueryProperties : Dictionary<string, object>
    {
        public static QueryProperties Fill(Dictionary<string, object> dic)
        {
            QueryProperties list = new QueryProperties();
            foreach (var i in dic)
            {
                list.Add(i.Key, i.Value);
            }
            return list;
        }

        public string GetStrProperty(string name)
        {
           return this[name].ToString();
        }

        public object GetObjProperty(string name)
        {
            return this[name];
        }

    }
}
