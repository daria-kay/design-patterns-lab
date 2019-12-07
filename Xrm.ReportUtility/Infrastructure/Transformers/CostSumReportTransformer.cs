using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CostSumReportTransformer : DataTransformer
    {
        public CostSumReportTransformer(IDataTransformer next) : base(next) { }
        public override Report TransformData(Report report)
        {
            if (report.Config.CostSum)
            {
                report.Rows.Add(new ReportRow
                {
                    Name = "Суммарная стоимость",
                    Value = report.Data.Sum(i => i.Cost * i.Count)
                });
            }

            return base.TransformData(report);
        }
    }
}
