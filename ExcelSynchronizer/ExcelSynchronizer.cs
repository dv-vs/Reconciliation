using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelHelper
{
    public class ExcelSynchronizer
    {
        private ConcurrentBag<string> _fileNames;

        public ExcelSynchronizer(IEnumerable<string> fileNames)
        {
            _fileNames = new ConcurrentBag<string>(fileNames);
        }

        public void Execute()
        { }
    }
}
