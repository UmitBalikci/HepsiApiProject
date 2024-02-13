using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApiProject.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
    }
}
