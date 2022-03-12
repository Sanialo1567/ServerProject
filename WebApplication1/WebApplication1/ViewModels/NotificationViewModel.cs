using System;

namespace WebApplication1.ViewModels
{
    public class NotificationViewModel
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
