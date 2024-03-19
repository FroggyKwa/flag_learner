using System;
using System.Collections.Generic;

namespace FlagLearner.Database.Entities
{
    public partial class Line
    {
        public long Id { get; set; }
        public string Line1 { get; set; } = null!;
        public long? CountryId { get; set; }

        public virtual Country? Country { get; set; }
    }
}
