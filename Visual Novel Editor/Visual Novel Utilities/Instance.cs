using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnrt.Utilities
{
    public class Instance
    {
        private readonly List<Character> mCharacters = new List<Character>();
        private Dialog mDialog;

        public List<Character> Characters
        {
            get
            {
                return mCharacters;
            }
        }
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
