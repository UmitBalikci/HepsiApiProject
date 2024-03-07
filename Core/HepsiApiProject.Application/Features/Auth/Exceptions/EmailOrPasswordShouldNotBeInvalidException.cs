using HepsiApiProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseExceptions
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Username or Password wrong!!"){}
    }
}
