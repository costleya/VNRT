using System;
using System.Collections.Generic;

namespace Vnrt.Runtime.SaveData
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
