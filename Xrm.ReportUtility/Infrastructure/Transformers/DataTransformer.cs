using System.Collections.Generic;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class DataTransformer : IDataTransformer
    {
        private readonly IDataTransformer _next;

        public DataTransformer(IDataTransformer next)
        {
            _next = next;
        }
        
        //Реализованный паттерн: chain of responsibility.
        //В каждом классе-наследнике переопределен метод TransformData() 
        public static Report Transform(ReportConfig config, DataRow[] data)
        {
            var emptyReport =  new Report
            {
                Config = config,
                Data = data,
                Rows = new List<ReportRow>()
            };
            IDataTransformer transformer = new DataTransformer(null);
            transformer = new WithDataReportTransformer(transformer);
            transformer = new VolumeSumReportTransformer(transformer);
            transformer = new WeightSumReportTransfomer(transformer);
            transformer = new CostSumReportTransformer(transformer);
            transformer = new CountSumReportTransformer(transformer);

            return transformer.TransformData(emptyReport);
        }

        public virtual Report TransformData(Report report)
        {
            if (_next != null)
                return _next.TransformData(report);
            return report;
        }
    }
}
