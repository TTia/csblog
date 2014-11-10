using Coypu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Features.Steps
{
    public class Page
    {
        Dictionary<string, ElementScope> dictionary;
        public Page() {
            dictionary = new Dictionary<string, ElementScope>();
        }
    }
}