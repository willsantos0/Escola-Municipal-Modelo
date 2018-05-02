using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EscolaMunicipalAPI.Models.Aluno
{
    [Table("Aluno")]
    public class Aluno
    {
        public long Id { get; set; }

        
        [StringLength(15)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deverá estar no formato 00000000000")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string CPF { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Nome do Aluno é obrigatório")]
        public string NomeAluno { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Nome da mãe é obrigatório")]
        public string NomeMae { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }
    }
}