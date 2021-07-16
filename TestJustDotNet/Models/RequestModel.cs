using System;
namespace TestJustDotNet.Models
{
    public class RequestModel
    {
        public object Source { get; set; }
        public object Transformer { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
