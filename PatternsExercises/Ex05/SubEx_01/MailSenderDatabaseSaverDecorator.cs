using Patterns.Ex05.ExternalLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex05.SubEx_01
{
    internal class MailSenderDatabaseSaverDecorator : IDatabaseSaver
    {
        private readonly MailSender _mailSender = new MailSender();
        private readonly string _emailToSend;
        private DatabaseSaver _databaseSaver= new DatabaseSaver();

        public MailSenderDatabaseSaverDecorator(IDatabaseSaver wrappedSaver, string emailToSend)
        {
            _emailToSend = emailToSend;
        }

        public void SaveData(object data)
        {
            _databaseSaver.SaveData(data);
            _mailSender.Send(_emailToSend);
        }
    }
}
