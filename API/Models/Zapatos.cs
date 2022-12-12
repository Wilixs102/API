namespace API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Zapatos
    {
        [Key]
        public int IdZapatos { get; set; }

        public int? IdUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string Marca { get; set; }

        [Required]
        [StringLength(15)]
        public string Modelo { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Fecha { get; set; }

        [Required]
        public byte[] Imagen { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
