using System.IO;
using System.Linq;
using CsvHelper;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class CsvReportService : ReportService
    {
        public CsvReportService(ReportConfig reportConfig) : base(reportConfig){}

        protected override DataRow[] GetDataRows(string text)
        {
            using (TextReader textReader = new StringReader(text))
            {
                var csvReader = new CsvReader(textReader);

                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.RegisterClassMap<RowDataMapper>();

                return csvReader.GetRecords<DataRow>().ToArray();
            }
        }
    }
}