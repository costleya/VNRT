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
        private readonly List<Instance> mInstanceList = new List<Instance>();
        private String mBground;
        private String mBsound;

        public List<Instance> InstanceList
        {
            get
            {
                return mInstanceList;
            }
        }
        public String Bground
        {
            get
            {
                return mBground;
            }
            set
            {
                if (value != null)
                {
                    mBground = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public String Bsound
        {
            get
            {
                return mBsound;
            }
            set
            {
                if (value != null)
                {
                    mBsound = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}
