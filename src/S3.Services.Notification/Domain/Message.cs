using S3.Common.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace S3.Services.Notification.Domain
{
    public class Message : BaseEntity
    {
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
    }
}
