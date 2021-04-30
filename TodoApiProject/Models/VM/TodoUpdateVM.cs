using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApiProject.Models.VM
{
    public class TodoUpdateVM
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime? updateDate { get; set; } = DateTime.Now;
    }
}
