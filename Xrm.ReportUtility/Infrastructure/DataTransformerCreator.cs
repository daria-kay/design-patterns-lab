using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        //Паттерн декоратор.
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            //Инициализация базового (по функционалу) объекта DataTransformer 
            IDataTransformer service = new DataTransformer(config);

            //В строках 17-40 "оборачивание" этого объекта в декраторы, содержащий дополнительный функционал, 
            //в зависимости от значения полей конфигурационного объекта
            if (config.WithData)
            {
                service = new WithDataReportTransformer(service);
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service);
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service);
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service);
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service);
            }

            return service;
        }
    }
}