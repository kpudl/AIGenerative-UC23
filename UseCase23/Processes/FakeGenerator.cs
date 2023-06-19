using Bogus;
using Nager.Country;
using UseCase23.Models;

namespace UseCase23.Processes
{
    internal class FakeGenerator
    {
        private readonly Faker _faker = new Faker();
        private readonly Dictionary<string, string> _alpha2ToAlpha3;

        // this normally would be registered so it would be called only once
        public FakeGenerator()
        {
            var countryProvider = new CountryProvider();
            _alpha2ToAlpha3 = new Dictionary<string, string>();

            foreach (var country in countryProvider.GetCountries())
            {
                _alpha2ToAlpha3[country.Alpha2Code.ToString()] = country.Alpha3Code.ToString();
            }
        }

        public List<Titles> GenerateTitles()
        {
            var titles = new List<Titles>();

            var positiveTitleRules = new Faker<Titles>()
                .RuleFor(t => t.Id, f => Math.Abs(f.Random.Int()))
                .RuleFor(t => t.Title, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(t => t.Description, f => f.Lorem.Sentence(f.Random.Number(5, 15)))
                .RuleFor(t => t.AgeCertification, f => f.PickRandom<AgeCertification>())
                .RuleFor(t => t.Runtime, f => f.Random.Int(85, 340))
                .RuleFor(t => t.ProductionCountry, f => _alpha2ToAlpha3[f.Address.CountryCode()])
                .RuleFor(t => t.Seasons, f => f.Random.Int(0, 10))
                .RuleFor(t => t.Genres, f => Enum.GetNames(typeof(Genres)).OrderBy(x => f.Random.Int()).Take(f.Random.Int(1, 4)).ToList())
                .RuleFor(t => t.ReleaseYear, f => f.Date.Past(85).Year);

            titles.AddRange(positiveTitleRules.Generate(80));

            var edgeTitleRules = positiveTitleRules
                //Rule for earliest year
                .RuleFor(m => m.ReleaseYear, f => DateTime.MinValue.Year)
                //Rule for wrongly set country
                .RuleFor(t => t.ProductionCountry, f => f.Address.CountryCode())
                //Rule for long title
                .RuleFor(t => t.Title, f => f.Lorem.Sentence(15))
                 // Rule for small Runtime
                 .RuleFor(t => t.Runtime, f => f.Random.Int(0, 25));

            titles.AddRange(edgeTitleRules.Generate(10));

            var negativeGenresTitleRules = positiveTitleRules
                 // Rule for missing Genres
                 .RuleFor(t => t.Genres, f => null);

            titles.AddRange(negativeGenresTitleRules.Generate(5));

            var negativeTitleRules = positiveTitleRules
                 // Rule for missing Title
                 .RuleFor(t => t.Title, f => null);

            titles.AddRange(negativeTitleRules.Generate(5));
            return titles.OrderBy(x => _faker.Random.Int()).ToList();
        }

        public List<Credit> GenerateCredits(IEnumerable<Titles> titles)
        {
            var credits = new List<Credit>();

            var positiveCreditsRules = new Faker<Credit>()
                .RuleFor(c => c.Id, f => Math.Abs(f.Random.Int()))
                .RuleFor(c => c.Role, f => f.PickRandom<Role>())
                .RuleFor(c => c.CharacterName, f => f.Name.FirstName())
                .RuleFor(c => c.RealName, f => f.Name.FullName())
                .RuleFor(c => c.TitleId, f => f.PickRandom(titles).Id);

            credits.AddRange(positiveCreditsRules.Generate(80));

            var edgeCreditRules = positiveCreditsRules
                //Rule for long RealName
                .RuleFor(t => t.RealName, f => f.Lorem.Sentence(5))
                //Rule for long CharacterName
                .RuleFor(t => t.CharacterName, f => f.Lorem.Sentence(8));
            credits.AddRange(edgeCreditRules.Generate(10));

            var negativeCreditRules = positiveCreditsRules
                //Rule for missing TitleId
                .RuleFor(t => t.TitleId, f => Math.Abs(f.Random.Int()))
                //Rule for missing RealName
                .RuleFor(t => t.RealName, f => null);
            credits.AddRange(negativeCreditRules.Generate(5));

            var negativeCharacterRules = positiveCreditsRules
                //Rule for missing CharacterName
                .RuleFor(t => t.CharacterName, f => null);
            credits.AddRange(negativeCharacterRules.Generate(5));
            return credits.OrderBy(x => _faker.Random.Int()).ToList();
        }
    }
}
