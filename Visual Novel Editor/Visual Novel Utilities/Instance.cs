using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Vnrt.Utilities
{
    public class Instance
    {
        private readonly List<Character> mCharacters = new List<Character>();
        private Dialog mDialog;

        [XmlArray(ElementName="Characters",IsNullable=true)]
        public List<Character> Characters
        {
            get
            {
                return mCharacters;
            }
        }
        [XmlElement(IsNullable=true)]
        public Dialog Dialog
        {
            get
            {
                return mDialog;
            }
            set
            {
                if (value != null)
                {
                    mDialog = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

    }
}
