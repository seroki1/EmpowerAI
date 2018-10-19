using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityCore.Library
{
    public class MyIdentityRole<T> : IdentityRole<string>
    {

        public MyIdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public MyIdentityRole(string name) : this()
        {
            Name = name;
        }

        public MyIdentityRole(string name, string id)
        {
            Name = name;
            Id = id;
        }
        public new string Description { get; internal set; }
    }
}
