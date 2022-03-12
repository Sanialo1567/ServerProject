using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class PostEntityModel
    {
        [Key]
        public Guid Id { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public Guid WebPortalId { get; set; }
        public virtual WebPortalEntityModel WebPortal { get; set; }
    }
}
