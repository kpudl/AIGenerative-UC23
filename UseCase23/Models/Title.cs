using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase23.Models
{
    internal class Titles
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public AgeCertification AgeCertification { get; set; }

        public int Runtime { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public string ProductionCountry { get; set; }

        public int Seasons { get; set; }
    }
}
