// See https://aka.ms/new-console-template for more information
using CsvHelper;
using System.Globalization;
using UseCase23.Converters.Mappings;
using UseCase23.Processes;

var fakeGenerator = new FakeGenerator();

var titles = fakeGenerator.GenerateTitles();

using (var writer = new StreamWriter("titles.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<TitleMap>();
    csv.WriteRecords(titles);
}

using (var writer = new StreamWriter("credits.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(fakeGenerator.GenerateCredits(titles));
}