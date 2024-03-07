using HepsiApiProject.Application.Bases;
using HepsiApiProject.Application.Features.Auth.Exceptions;
using HepsiApiProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checjPassword)
        {
            if (user is null || !checjPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            
            return Task.CompletedTask;
        }
    }
}
