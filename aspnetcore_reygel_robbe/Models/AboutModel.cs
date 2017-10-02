using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_reygel_robbe.Models
{
    public class AboutModel
    {
        public String Name { get; set; }

        public DateTime Now => DateTime.Now;
        public double DaysUntilBirthDay { get; set; }
    }
}
