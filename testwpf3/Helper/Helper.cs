using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace testwpf3 {
    class Helper {
        public static void Show ( Object object1 ) {
            MessageBox.Show(JsonConvert.SerializeObject(object1, Formatting.Indented,
                new JsonSerializerSettings {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }
    }
}
