using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class NotificationEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

        [Required]
        public Guid WebPortalId  { get; set; }
        public virtual WebPortalEntityModel WebPortal { get; set; }

        [Required]
        public Guid PostId { get; set; }
        public virtual PostEntityModel Post { get; set; }

        [Required]
        public Status Status { get; set; }
    }

    public enum Status
    {
        Watched,
        Unwatched
    }
}
