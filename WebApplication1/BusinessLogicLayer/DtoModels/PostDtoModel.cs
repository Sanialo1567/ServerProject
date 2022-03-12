using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class PostDtoModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid WebPortalId { get; set; }
    }
}
