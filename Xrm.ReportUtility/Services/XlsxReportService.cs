using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class XlsxReportService : ReportService
    {
        public XlsxReportService(ReportConfig reportConfig) : base(reportConfig) { }
        protected override DataRow[] GetDataRows(string text)
        {
            return new DataRow[0];
        }
    }
}