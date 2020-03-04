using System;
using System.Collections.Generic;

namespace DecoratorPattern.Model
{
    public abstract class BaseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
