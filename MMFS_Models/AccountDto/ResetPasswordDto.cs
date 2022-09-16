using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Models.AccountDto
{
    public class ResetPasswordDto
    {
        public string UserId { get; set; }
        public int? VarificationCode { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
