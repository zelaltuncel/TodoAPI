using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApiProject.Models.VM
{
    public class TodoListVM
    {
        public int id { get; set; }

        public string name { get; set; }
        public DateTime addDate { get; set; } = DateTime.Now;

        public DateTime? updateDate { get; set; } = DateTime.Now;
    }
}
