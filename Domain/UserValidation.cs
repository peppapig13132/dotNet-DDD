using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Domain
{
    public class UserValidation :AbstractValidator<UserDTO>    
    {
        public UserValidation() 
        {
            RuleFor(x => x.name).Length(0, 5);
            RuleFor(x => x.email).EmailAddress();
            RuleFor(x => x.gender).NotEmpty();
            RuleFor(x => x.age).NotEmpty();
        }
    }
}
