using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase23.Models
{
    internal class Credit
    {
        public int Id { get; set; }

        public int TitleId { get; set; }

        public string RealName { get; set; }

        public string CharacterName { get; set; }

        public Role Role { get; set; }
    }
}
