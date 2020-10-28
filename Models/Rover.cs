using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsImage.Models
{
    public class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }
    }
}
