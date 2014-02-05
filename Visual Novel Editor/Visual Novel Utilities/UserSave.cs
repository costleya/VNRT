using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnrt.Utilities
{
    public class UserSave
    {
        public DateTime SaveDate { get; set; }
        public string CurrentSceneId { get; set; }
        public string Name { get; set; }

        //ID log for history and choice
        public List<string> SceneIDHistory { get; set; }
    }
}
