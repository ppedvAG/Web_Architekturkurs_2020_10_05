using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPageSample.Models
{
    public partial class Clubs
    {
        public int Id { get; set; }



        [Required (ErrorMessage ="Bitte geben einen Vereinsnamen ein?")]
        public string Name { get; set; }

        [Required]
        public DateTime FoundingYear { get; set; }


        [DisplayName("Transfer Budget")]
        public long TransferBudget { get; set; }

        public int ArenaCapacity { get; set; }


        [DisplayName("Area Name")]
        public string ArenaName { get; set; }
    }
}
