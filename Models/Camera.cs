using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MarsImage.Models
{
    public class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }
    }
}
