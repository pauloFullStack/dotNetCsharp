using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class NotificationsDTO
    {
        public string? Message { get; set; }
        public string? Status { get; set; }

        public NotificationsDTO() { }

        public NotificationsDTO(string message, string status)
        {
            Message = message;
            Status = status;
        }

    }
}
