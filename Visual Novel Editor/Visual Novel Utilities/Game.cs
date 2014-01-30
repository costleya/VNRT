using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace Vnrt.Utilities
{
    [XmlRoot]
    public class Game
    {
        public String Name { get; set; }
        public String Author { get; set; }
        [XmlArray(ElementName = "Scenes")]
        public List<Scene> Scenes { get; set; }

        public Game()
        {

        }
    }
}
