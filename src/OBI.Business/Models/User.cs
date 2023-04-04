using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBI.Business.Models
{
    public class User : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
