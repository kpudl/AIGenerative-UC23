using CsvHelper.Configuration;
using UseCase23.Models;

namespace UseCase23.Converters.Mappings
{
    internal class TitleMap:ClassMap<Titles>
    {
        public TitleMap() 
        {
            Map(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.ReleaseYear);
            Map(x => x.AgeCertification).TypeConverter<EnumDescriptorConverter<AgeCertification>>();
            Map(x => x.Runtime);
            Map(x => x.ProductionCountry);
            Map(x => x.Seasons);
            Map(x => x.Genres).Convert(row => string.Join(",", row.Value?.Genres ?? new List<string>()));
        }
    }
}
