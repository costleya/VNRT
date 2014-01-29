﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Vnrt.Utilities
{
    public class Instance
    {
        public Dialog Dialog { get; set; }
        [XmlArray(ElementName = "Characters")]
        public List<Character> Characters { get; set; }

        public Instance()
        {
            Characters = new List<Character>();
        }

    }
}
