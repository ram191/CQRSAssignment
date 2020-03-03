using System;
namespace DecoratorPattern.Model
{
    public class RequestData
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public Attribute Attributes { get; set; }
    }

    public class Attribute
    {
        public Customer Customer { get; set; }
    }
}
