using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
    [Index("Email")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime BannedUntil { get; set; }
    }
}
