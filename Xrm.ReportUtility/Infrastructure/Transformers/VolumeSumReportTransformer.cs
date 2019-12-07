using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class VolumeSumReportTransformer : DataTransformer
    {
        public VolumeSumReportTransformer(IDataTransformer next) : base(next) { }
        public override Report TransformData(Report report)
        {
            if (report.Config.VolumeSum)
            {
                report.Rows.Add(new ReportRow
                {
                    Name = "Суммарный объём",
                    Value = report.Data.Sum(i => i.Volume * i.Count)
                });
            }
            return base.TransformData(report);
        }
    }
}
