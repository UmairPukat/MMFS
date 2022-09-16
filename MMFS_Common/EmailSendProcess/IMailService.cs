using MMFS_Models.EmailSendDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFS_Common.EmailSendProcess
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
