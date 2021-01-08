namespace BazaDateModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Angajati")]
    public partial class Angajati
    {
        [Key]
        public int AngId { get; set; }

        [StringLength(10)]
        public string Nume { get; set; }

        [StringLength(10)]
        public string Prenume { get; set; }

        [StringLength(10)]
        public string Functia { get; set; }

        public decimal? Varsta { get; set; }

        [Column("Data angajarii", TypeName = "date")]
        public DateTime? Data_angajarii { get; set; }

        [Column("Salariu brut RON")]
        public decimal? Salariu_brut_RON { get; set; }
    }
}
