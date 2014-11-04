using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Helper
{
    public class SessionHelper
    {
        public bool GrantAccess(string Username, string Password)
        {
            CSBlogDBEntities oDb = new CSBlogDBEntities();
            var user = (from authors 
                            in oDb.Authors 
                        where authors.Email == Username && authors.HPassword == Password 
                        select authors).First<Author>();
            return (user != null);
        }
    }
}