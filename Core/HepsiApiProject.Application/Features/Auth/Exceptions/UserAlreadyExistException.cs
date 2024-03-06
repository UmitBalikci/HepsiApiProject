using HepsiApiProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() : base("This user already exist!!") { }
    }
}
