//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Author
    {
        public Author()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public System.Guid id { get; set; }
        [Display(Name = "Email", Description = "Inserisci la tua email.")]
        public string email { get; set; }
        [Display(Name = "Password", Description = "Inserisci la tua password.")]
        public string hpassword { get; set; }
        public string hsalt { get; set; }
        public System.DateTime createdAt { get; set; }
    
        public virtual ICollection<Post> Posts { get; set; }
    }
}
