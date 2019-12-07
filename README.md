### Итоговая лабораторная работа по СК "Паттерны проектирования"

Исходный код проекта перенесен на платформу .net core 3.1.100 для возможности выполнить лабораторку на диструбутиве linux

#### Найденные паттерны:
1. [Декоратор](https://github.com/daria-kay/design-patterns-lab/blob/7f463b14c9414ff12fe201fce2ef89c9c13de186/Xrm.ReportUtility/Infrastructure/DataTransformerCreator.cs)
1. [Шаблонный метод](https://github.com/daria-kay/design-patterns-lab/blob/master/Xrm.ReportUtility/Services/ReportServiceBase.cs)

#### Имплементированные паттерны:

1. [Builder](https://github.com/daria-kay/design-patterns-lab/blob/master/Xrm.ReportUtility/Models/ReportConfig.cs)
2. [Factory method](https://github.com/daria-kay/design-patterns-lab/blob/master/Xrm.ReportUtility/Services/ReportService.cs)
3. Паттерн Декоратор заменен на [Chain of responsibility](https://github.com/daria-kay/design-patterns-lab/blob/master/Xrm.ReportUtility/Infrastructure/Transformers/DataTransformer.cs), так как планируется дальнейшее добавление агрегирующих функций.


