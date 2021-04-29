using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeQueryDetailed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<EditHistory> EditHistories { get; set; }
    }
}
