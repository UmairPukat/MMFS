using MMFS_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO
{
    public class AccessingComponent: BASECLASS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icons { get; set; }
        public string URL { get; set; }
        public ICollection<Permission> Permission { get; set; }
    }
}
