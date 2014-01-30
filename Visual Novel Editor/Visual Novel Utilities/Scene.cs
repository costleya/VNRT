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
        [XmlAttribute]
        public string Id { get; set; }
        public String BackgroundImage { get; set; }
        public String BackgroundMusic { get; set; }
        [XmlArray("Instances")]
        public List<Instance> Instances { get; set; }

        public Scene()
        {

        }
    }
}
