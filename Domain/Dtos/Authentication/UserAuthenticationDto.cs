using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Authentication
{
    public class UserAuthenticationDto
    {       
        public string UserName { get; set; }        
        public string Password { get; set; }
    }
}
