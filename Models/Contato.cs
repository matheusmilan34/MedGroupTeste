using MedGroupTeste.Enumeradores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedGroupTeste.Models
{
    public class Contato
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public Sexo Sexo { get; set; }
        [JsonIgnore]
        public bool Ativo { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int Idade { get; set; }
    }
}
