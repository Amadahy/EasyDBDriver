using EasyDBDriver.Model;
using System.Collections.Generic;

namespace EasyDBDriver.Tests.Model
{
    public class TestEntity:EasyDbElement
    {
        public string StringItem { get; set; }
        public int IntItem { get; set; }
        public double DoubleItem { get; set; }
        public IList<string> ListStringItem { get; set; } 
        public FileModel File { get; set; }
    }
}
