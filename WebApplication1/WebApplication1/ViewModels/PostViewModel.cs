using System;

namespace WebApplication1.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid WebPortalId { get; set; }
    }
}
