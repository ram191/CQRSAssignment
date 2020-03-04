using System;
namespace DecoratorPattern.Application.UseCases.Product.Models
{
    public enum Gender { male, female }
    public class CustomerData
    {
        public string Full_name { get; set; }
        public string Username { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public Gender Sex { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; } = DateTime.Now;
    }
}
