using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PersonStatus
    {
        [Key]
        public int ID { set; get; }
        public string Value { set; get; }

    }
}
