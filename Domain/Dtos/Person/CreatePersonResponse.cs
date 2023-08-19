using System;

namespace Domain.Dtos.Person
{
    public class CreatePersonResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }    
}
