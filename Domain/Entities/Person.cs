using Domain.Common;

namespace Domain.Entities
{
    public class Person:BaseEntity
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
