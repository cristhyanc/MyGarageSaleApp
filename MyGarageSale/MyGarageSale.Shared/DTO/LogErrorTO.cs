using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
    public class LogErrorTO
    {
        [PrimaryKey, AutoIncrement]
        public int LogId { get; set; }
        public DateTime QueuedData { get; set; }      
        public string Details { get; set; }
        public bool Sent { get; set; }
    }
}
