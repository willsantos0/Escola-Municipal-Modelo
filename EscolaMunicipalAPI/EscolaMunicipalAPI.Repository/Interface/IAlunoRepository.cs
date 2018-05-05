using EscolaMunicipalAPI.Models.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaMunicipalAPI.Repository.Interface
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        void InsertList(List<Aluno> alunos);
        Aluno GetByCPF(string cpf);
    }
}
