using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class NotificationModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Sender { get; set; }

        public bool IsRead {  get; set; }=false;
        public string Receiver { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
