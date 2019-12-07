using System;
using System.IO;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportService : IReportService
    {
        private ReportConfig _reportConfig;

        protected ReportService(ReportConfig reportConfig)
        {
            _reportConfig = reportConfig;
        }

        //Паттерн шаблонный метод.
        //Этот метод содержит базовый алгоритм создания отчета, где обязанность по извлечению записей из файла
        //делегируется классам-наследникам
        public Report CreateReport()
        {
            var dataTransformer = DataTransformerCreator.CreateTransformer(_reportConfig);

            var text = File.ReadAllText(_reportConfig.FileName); 
            
            //Метод GetDataRows() реализован в каждом классе-наследнике, согласно формату обрабатываемого файла
            var data = GetDataRows(text);
            
            return dataTransformer.TransformData(data);
        }
        

        protected abstract DataRow[] GetDataRows(string text);

        //Реализованный паттерн: статический фабричный метод
        //В зависимости от входных аргументов метод создает объект класса-наследника
        public static ReportService GetInstance(string[] args)
        {
            var config = ReportConfig.Builder.BuildConfig(args);
            var filename = config.FileName;
            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(config);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(config);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(config);
            }

            throw new NotSupportedException("this extension not supported");
        }
    }
}