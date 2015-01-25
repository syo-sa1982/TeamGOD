using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class PatternData
    {
        public string name { get; set; }
        public string[, ,] PaternArray { get; set; }
        public bool OneCheck { get; set; }
        public int x { get; set; }
        public int y{ get; set; }
        public int z{ get; set; }
        public GameObject nextObject { get; set; }
    }
}
