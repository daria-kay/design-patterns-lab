using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WithDataReportTransformer : DataTransformer
    {
        public WithDataReportTransformer(IDataTransformer reportService) : base(reportService) { }

        public override Report TransformData(Report report)
        {
            if (!report.Config.WithData)
            {
                report.Data = new DataRow[0];
            }

            return base.TransformData(report);
        }
    }
}
