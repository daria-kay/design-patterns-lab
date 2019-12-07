using System.Collections.Generic;

namespace Xrm.ReportUtility.Models
{
    public class ReportConfig
    {
        private ReportConfig(bool withIndex, bool withData, bool withTotalVolume, bool withTotalWeight, bool volumeSum,
            bool weightSum, bool costSum, bool countSum, string fileName)
        {
            WithIndex = withIndex;
            WithData = withData;
            WithTotalVolume = withTotalVolume;
            WithTotalWeight = withTotalWeight;
            VolumeSum = volumeSum;
            WeightSum = weightSum;
            CostSum = costSum;
            CountSum = countSum;
            FileName = fileName;
        }

        public bool WithData { get; }

        public bool WithIndex { get; }
        public bool WithTotalVolume { get;}
        public bool WithTotalWeight { get; }

        public bool VolumeSum { get; }
        public bool WeightSum { get;}
        public bool CostSum { get; }
        public bool CountSum { get; }
        
        public string FileName { get; }
        
        //Реализованный паттерн: билдер
        //Инкапсулирует в себе всю логику конструирования объекта внешнего класса,
        //тем самым избегая огромных конструкторов и сохраняя немутабельность целевого объекта.
        public class Builder
        {
            public static ReportConfig BuildConfig(string[] args)
            {
                IList<string> listOfArgs = new List<string>(args);
                var fileName = listOfArgs[0];
                return new ReportConfig
                (
                    listOfArgs.Contains("-withIndex"),
                   listOfArgs.Contains("-data"),

                    
                    listOfArgs.Contains("-withTotalVolume"),
                    listOfArgs.Contains("-withTotalWeight"),

                    listOfArgs.Contains("-volumeSum"),
                    listOfArgs.Contains("-weightSum"),
                     listOfArgs.Contains("-costSum"),
                    listOfArgs.Contains("-countSum"),
                    fileName
                    );
            }
        }
    }
}
