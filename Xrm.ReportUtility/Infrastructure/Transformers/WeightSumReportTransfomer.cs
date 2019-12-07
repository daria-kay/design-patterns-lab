using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class WeightSumReportTransfomer : DataTransformer
    {

        public WeightSumReportTransfomer(IDataTransformer next) : base(next) { }
        public override Report TransformData(Report report)
        {
            if (report.Config.WeightSum)
            {
                report.Rows.Add(new ReportRow
                {
                    Name = "Суммарный вес",
                    Value = report.Data.Sum(i => i.Weight * i.Count)
                });
            }
            return base.TransformData(report);
        }
    }
}
