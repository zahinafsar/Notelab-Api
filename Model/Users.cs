using System;
using System.Collections.Generic;

namespace notelab.app.Model
{
    public class Users
    {
        public int Id {get; init;}
        public string Username {get; init;}
        public string Password {get; init;}
        public virtual ICollection<Notes> Notes {get; init;}
    }
}
