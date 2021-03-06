using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_login.Models
{
    public class ServerContext
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string Token { get; set; }
        public object Value { get; set; }

        public T ParseObject<T>()
        {
            return ((Newtonsoft.Json.Linq.JObject)Value).ToObject<T>();
        }
        public List<T> ParseArray<T>()
        {
            var lst = new List<T>();
            foreach (var e in ((Newtonsoft.Json.Linq.JArray)Value))
            {
                lst.Add(e.ToObject<T>());
            }
            return lst;
        }
    }
}
