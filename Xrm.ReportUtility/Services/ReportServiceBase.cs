using System.IO;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private readonly string[] _args;

        protected ReportServiceBase(string[] args)
        {
            _args = args;
        }

        //Паттерн шаблонный метод.
        //Этот метод содержит базовый алгоритм создания отчета, где обязанность по извлечению записей из файла
        //делегируется классам-наследникам
        public Report CreateReport()
        {
            var config = ParseConfig();
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = _args[0];
            var text = File.ReadAllText(fileName); 
            
            //Метод GetDataRows() реализован в каждом классе-наследнике, согласно формату обрабатываемого файла
            var data = GetDataRows(text);
            
            return dataTransformer.TransformData(data);
        }

        private ReportConfig ParseConfig()
        {
            return new ReportConfig
            {
                WithData = _args.Contains("-data"),

                WithIndex = _args.Contains("-withIndex"),
                WithTotalVolume = _args.Contains("-withTotalVolume"),
                WithTotalWeight = _args.Contains("-withTotalWeight"),

                VolumeSum = _args.Contains("-volumeSum"),
                WeightSum = _args.Contains("-weightSum"),
                CostSum = _args.Contains("-costSum"),
                CountSum = _args.Contains("-countSum")
            };
        }

        protected abstract DataRow[] GetDataRows(string text);
    }
}