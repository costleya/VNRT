using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace Vnrt.Utilities
{
    public class Game
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public List<Scene> Scenes { get; set; }

        public Game()
        {

        }
    }
}
