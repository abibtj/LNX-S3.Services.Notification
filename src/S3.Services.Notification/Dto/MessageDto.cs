using System;
using System.ComponentModel.DataAnnotations;

namespace S3.Services.Notification.Dto
{
    public class MessageDto : BaseDto
    {
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
    }
}
