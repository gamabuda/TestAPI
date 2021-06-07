using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Value
        {
            public int id { get; set; }
            public string joke { get; set; }
            public List<object> categories { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public List<Value> value { get; set; }
        }
}
