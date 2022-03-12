using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class NotificationDtoModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid WebPortalId { get; set; }

        public Guid PostId { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Watched,
        Unwatched
    }
}
