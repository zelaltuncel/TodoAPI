using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApiProject.Models.Entities
{
    public class Work
    {
        public int ID { get; set; }

        public string Name { get; set; }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }
            set
            {
                _isDeleted = value;
            }
        }
    
        public string AddDate { get; set; } = DateTime.Now.ToShortDateString();

        public string UpdateDate { get; set; } 



    }
}
