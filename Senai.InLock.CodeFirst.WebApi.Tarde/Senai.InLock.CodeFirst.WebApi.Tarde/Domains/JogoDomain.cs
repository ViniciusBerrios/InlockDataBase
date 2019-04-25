using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    [Table ("Jogos")]
    public class JogoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogoId { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string NomeJogo { get; set; }

        [Column(TypeName = "Text")]
        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataLancamento { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public Decimal Valor { get; set; }

        [Required]
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        public EstudioDomain Estudio { get; set; }
    }
}
