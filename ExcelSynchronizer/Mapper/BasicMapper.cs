using ExcelDataReader;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelHelper.Mapper
{
    abstract class BasicMapper<ExcelModel> : IMapper where ExcelModel: class 
    {
        private ConcurrentBag<ExcelModel> _results = new ConcurrentBag<ExcelModel>();

        protected abstract ExcelModel GetRowData(IExcelDataReader xlsReader);
        
        protected virtual void ReadFile(string fileName)//maybe csv will be needed
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var xlsReader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (xlsReader.Read())//next row
                        {
                            var rowData = GetRowData(xlsReader);
                            _results.Add(rowData);
                        }
                    }
                    while (xlsReader.NextResult());//next page
                }
            }

            
        }

        public IEnumerable<ExcelModel> ReadAll(ConcurrentBag<string> exFiles)
        {
            //var fileReaders = new List<Task>();//[exFiles.Count()];
            //foreach (var fileName in exFiles)
            //{
            //    var readerTask = new Task(() => ReadFile(fileName));
            //    fileReaders.Add(readerTask);
            //    readerTask.Start();
            //}

            //Task.WaitAll(fileReaders.ToArray());
            Task[] fileReaders = new Task[exFiles.Count()];
            for (int i = 0; i < exFiles.Count; i++)
            {
                fileReaders[i] = Task.Factory.StartNew(() =>
                {
                    string fileName;
                    bool shoulRead = exFiles.TryTake(out fileName);
                    if (shoulRead)
                        ReadFile(fileName);
                });
            }

            Task.WaitAll(fileReaders);
            return _results;
        }
    }
}
