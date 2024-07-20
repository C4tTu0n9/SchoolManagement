using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Report
    {
        public int stt { get; set; }
        public string nameClass { get; set; }
        public int tt { get; set; }
        public int pass { get; set; }
        public double scale { get; set; }

        public Report()
        {
            stt = tt = pass = 0;
            scale = 0;
            nameClass = "";
        }
    }
}
