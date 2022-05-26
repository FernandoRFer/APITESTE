namespace APIMussicCipher.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MusicaCompleta")]
    public partial class MusicaCompleta
    {
        public int Id { get; set; }

        public string NomeMusica { get; set; }

        public string Cifra { get; set; }

        [StringLength(50)]
        public string Artista { get; set; }
    }
}
