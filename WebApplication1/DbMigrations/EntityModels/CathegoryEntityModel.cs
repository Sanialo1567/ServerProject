using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CathegoryEntityModel
    {
        public CathegoryEntityModel()
        {
            WebPortals = new List<WebPortalEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual IList<WebPortalEntityModel> WebPortals { get; set; }
    }
}
