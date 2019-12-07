using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CountSumReportTransformer : DataTransformer
    {
        public CountSumReportTransformer(IDataTransformer next) : base(next) { }
        public override Report TransformData(Report report)
        {
            if (report.Config.CountSum)
            {
                report.Rows.Add(new ReportRow
                {
                    Name = "Суммарное количество",
                    Value = report.Data.Sum(i => i.Count)
                });
            }
            return base.TransformData(report);
        }
    }
}
