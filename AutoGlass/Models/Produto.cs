using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoGlass.Data
{



    public class Produto
    {
        [Key]
        [Required(ErrorMessage = "O código é obrigatório")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(100, ErrorMessage ="Este campo deve conter no máximo 100 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A situação é obrigatória (A-Ativo ou I-Inativo)")]
        [MaxLength(1, ErrorMessage = "Este campo deve conter no máximo 1 caracteres")]
        public string Situacao { get; set; }

        
        public DateTime DataFabricacao { get; set; }

        public DateTime DataValidade { get; set; }

        public int CodigoDoFornecedor {get; set; }
        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo 100 caracteres")]
        public string DescricaoDoFornecedor { get; set; }

        [MaxLength(18, ErrorMessage = "Este campo deve conter no máximo 18 caracteres")]
        public string CnpjDoFornecedor { get; set; }
    }
}
