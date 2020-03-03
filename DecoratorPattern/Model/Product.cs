﻿using System;
namespace DecoratorPattern.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int Merchant_id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;

        public Merchant Merchant { get; set; }
    }
}
