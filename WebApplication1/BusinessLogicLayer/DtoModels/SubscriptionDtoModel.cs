using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class SubscriptionDtoModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid WebPortalId { get; set; }
    }
}
