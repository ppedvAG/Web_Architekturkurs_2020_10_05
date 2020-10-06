using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstSampleWithEFCore.Entities
{
    public class Club
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FoundingYear { get; set; }

        public long TransferBudget { get; set; }


        [Required] // Mithilfe von Data Annotations kann Datenbank-Spalten-Definitionen an Entity Objekte definieren. 
        [MaxLength(50)]
        public string ArenaName { get; set; }

        [Required]
        public int ArenaCapacity { get; set; }

    }
}
