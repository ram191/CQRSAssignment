using System;
using System.Collections.Generic;

namespace DecoratorPattern.Model
{
    public class RequestData<T>
    {
        public Data<T> Data { get; set; }
    }

    public class Data<T>
    {
        public T Attributes { get; set; }
    }
}
