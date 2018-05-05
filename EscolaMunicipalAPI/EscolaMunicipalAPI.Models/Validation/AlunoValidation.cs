using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EscolaMunicipalAPI.Models.Validation
{
    public class AlunoValidation
    {
        
        public bool DateIsValid(DateTime datetime)
        {
            var date = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
          
            DateTime dt;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ValidationReadXML(List<EscolaMunicipalAPI.Models.Aluno.Aluno> alunos)
        {
            int linha = 1;

            foreach(var aluno in alunos) {
                if (String.IsNullOrEmpty(aluno.CPF))
                {
                    throw new Exception("Erro no registro: " + linha + ". CPF é obrigatório!");
                }
                if (String.IsNullOrEmpty(aluno.NomeAluno))
                {
                    throw new Exception("Erro no registro: " + linha + ". Nome do aluno é obrigatório!");
                }
                if (aluno.DataNascimento == null)
                {
                    throw new Exception("Erro no registro: " + linha + ". Data de nascimento é obrigatório!");
                }
                if (!DateIsValid(aluno.DataNascimento.HasValue ? aluno.DataNascimento.Value : DateTime.Now))
                {
                    throw new Exception("Erro no registro: " + linha + ". Data de nascimento é deve estar no formato yyyy-MM-dd!");
                }
                if (String.IsNullOrEmpty(aluno.NomeMae))
                {
                    throw new Exception("Erro no registro: " + linha + ". Nome da mãe é obrigatório!");
                }
                if (String.IsNullOrEmpty(aluno.Endereco))
                {
                    throw new Exception("Erro no registro: " + linha + ". Endereço é obrigatório!");
                }

                linha++;
                
            }

         

        }
    }
}