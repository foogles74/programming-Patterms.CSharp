namespace Patterns.Ex00
{
    public class LogImporterBase
    {

        public void ImportLogs(string source)
        {
            var file = _reader.ReadLogFile(source);
            // Do smth
        }
    }
}