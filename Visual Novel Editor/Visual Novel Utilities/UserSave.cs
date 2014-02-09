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
        public Guid SceneId { get; set; }
        public Guid InstanceId { get; set; }
        public string Name { get; set; }

        //ID log for history and choice
        public List<string> DialogHistory { get; set; }
        public List<Guid> InstanceHistory { get; set; }
    }
}
