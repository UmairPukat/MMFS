using MMFS_Common;
using MMFS_POCO.UserManagement;
using MMFS_POCO.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_POCO
{
    public class Religion : BASECLASS
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonalProfile> PersonalProfile { get; set; }
    }
}
