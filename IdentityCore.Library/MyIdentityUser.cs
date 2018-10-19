using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityCore.Library
{
    public class MyIdentityUser : IdentityUser
    {

        public MyIdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
