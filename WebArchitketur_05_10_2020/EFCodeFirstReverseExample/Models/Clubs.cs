﻿using System;
using System.Collections.Generic;

namespace EFCodeFirstReverseExample.Models
{
    public partial class Clubs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundingYear { get; set; }
        public long TransferBudget { get; set; }
        public int ArenaCapacity { get; set; }
        public string ArenaName { get; set; }

        public string ClubColors { get; set; }
    }
}
