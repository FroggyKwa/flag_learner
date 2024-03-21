using System;
using System.Collections.Generic;

namespace FlagLearner.Database.Entities
{
    public partial class Line
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
