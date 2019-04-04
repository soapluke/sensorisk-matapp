using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Organisation : IEntity
    {
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        public bool Friendly { get; set; }
        public byte[] Picture { get; set; }
        public virtual ICollection<Survey> Survey { get; set; }
    }
}
