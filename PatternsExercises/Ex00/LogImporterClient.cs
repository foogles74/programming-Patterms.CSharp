using Patterns.Ex00.ExternalLibs;

namespace Patterns.Ex00
{
    public class FtpLogReaderAdapter : ILogReader
    {
        private FtpClient ftpClient;
        private string login;
        private string password;

        public FtpLogReaderAdapter(string login, string password)
        {
            ftpClient = new FtpClient();
        }

        public string ReadLogFile(string source)
        {
            return ftpClient.ReadFile(login, password, source);
        }
    }
    public class LogImporterClient
    {
        /// <summary>
        /// TODO: Изменения нужно вносить в этом методе
        /// Добавил адаптер
        /// </summary>
        public void DoMethod()
        {
            ILogReader reader = new FtpLogReaderAdapter("login", "password");
            LogImporter importer = new LogImporter(reader);
            importer.ImportLogs("ftp://log.txt");
        }

    }
}