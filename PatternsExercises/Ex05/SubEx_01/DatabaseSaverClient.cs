using Patterns.Ex05.ExternalLibs;

namespace Patterns.Ex05.SubEx_01
{
    public class DatabaseSaverClient
    {
        public void Main(bool b)
        {
            var databaseSaver = new DatabaseSaver();

            IDatabaseSaver saverWithMail = new MailSenderDatabaseSaverDecorator(databaseSaver, "meow");
            IDatabaseSaver cacheSaver = new CacheUpdaterDatabaseSaverDecorator(saverWithMail);
            
            DoSmth(saverWithMail);
        }

        private void DoSmth(IDatabaseSaver saver)
        {
            saver.SaveData(null);
        }
    }
}