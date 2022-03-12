using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class WebPortalEntityModel
    {
        public WebPortalEntityModel()
        {
            Subscritptions = new List<SubscritptionEntityModel>();
            Posts = new List<PostEntityModel>();
            Notifications = new List<NotificationEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public virtual UserEntityModel Owner { get; set; }

        [Required]
        public Guid CathegoryId { get; set; }
        public virtual CathegoryEntityModel Cathegory { get; set; }

        public virtual IList<SubscritptionEntityModel> Subscritptions { get; set; }
        public virtual IList<PostEntityModel> Posts { get; set; }
        public virtual IList<NotificationEntityModel> Notifications { get; set; }
    }
}
