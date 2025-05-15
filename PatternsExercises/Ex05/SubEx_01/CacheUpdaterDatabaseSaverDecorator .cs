using Patterns.Ex05.ExternalLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Ex05.SubEx_01
{
    public class CacheUpdaterDatabaseSaverDecorator : IDatabaseSaver
    {
        private DatabaseSaver _databaseSaver = new DatabaseSaver();
        private readonly CacheUpdater _cacheUpdater = new CacheUpdater();

        public CacheUpdaterDatabaseSaverDecorator(IDatabaseSaver wrappedSaver)
        {
        }
        public void SaveData(object data)
        {
            _databaseSaver.SaveData(data);
            _cacheUpdater.UpdateCache();
        }
    }
}
