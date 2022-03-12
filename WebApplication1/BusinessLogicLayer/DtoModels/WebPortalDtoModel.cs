using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class WebPortalDtoModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public Guid CathegoryId { get; set; }
    }
}
