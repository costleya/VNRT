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
        private readonly List<Scene> mSceneList = new List<Scene>();
        private String mName;
        private String mAuthor;

        public List<Scene> SceneList
        {
            get
            {
                return mSceneList;
            }
        }
        public String Name
        {
            get
            {
                return mName;
            }
            set
            {
                if (value != null)
                {
                    mName = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        public String Author
        {
            get
            {
                return mAuthor;
            }
            set
            {
                if (value != null)
                {
                    mAuthor = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public Game()
        {

        }
    }
}
