using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vnrt.Utilities
{
    public class Scene
    {
        public string Id { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundMusic { get; set; }
        public List<Instance> Instances { get; set; }

        public Scene()
        {

        }
    }
}
