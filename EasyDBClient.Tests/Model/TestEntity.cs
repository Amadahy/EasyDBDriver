using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using EasyDBConnector.Interface;
using EasyDBConnector.Model;

namespace EasyDBConnector.Tests.Model
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
