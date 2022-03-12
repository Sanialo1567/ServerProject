using System;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class WebPortalViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public Guid CathegoryId { get; set; }


        public IList<UserViewModel> Users { get; set; }
        public IList<PostViewModel> Posts { get; set; }
    }
}
