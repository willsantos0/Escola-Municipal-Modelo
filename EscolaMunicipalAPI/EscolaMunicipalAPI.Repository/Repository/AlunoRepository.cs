using EscolaMunicipalAPI.DataAccess;
using EscolaMunicipalAPI.Models.Aluno;
using EscolaMunicipalAPI.Models.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EscolaMunicipalAPI.Repository
{
    public class AlunoRepository : IRepository<Aluno>
    {

        private Context _context;
        private AlunoValidation _alunoValidation;

        public AlunoRepository()
        {
            _context = new Context();
            _alunoValidation = new AlunoValidation();
        }

        public Aluno Insert(Aluno aluno)
        {   
            _context.Alunos.Add(aluno);
            
            if (_context.SaveChanges() == 1)
                return aluno;
            else
                return null;
        }

        public void InsertList(List<Aluno> alunos)
        {

            _alunoValidation.ValidationReadXML(alunos);

            foreach(var aluno in alunos)
            {
                var alunoTemp = GetByCPF(aluno.CPF);

                if (alunoTemp == null)
                {
                    Insert(aluno);
                }
                else
                {
                    alunoTemp.NomeAluno = aluno.NomeAluno;
                    alunoTemp.DataNascimento = aluno.DataNascimento;
                    alunoTemp.NomeMae = aluno.NomeMae;
                    alunoTemp.Endereco = aluno.Endereco;

                    Update(alunoTemp);
                }
         
            }
  
        }

        public Aluno Update(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
              
            if (_context.SaveChanges() == 1)
                return aluno;
            else
                return null;
        }

        public void Delete(long id)
        {
            var aluno = _context.Alunos.Find(id);

            if (aluno == null)
                throw new Exception("Aluno não econtrado para excluir!");

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        
        public Aluno GetById(long id)
        {  
            return _context.Alunos.FirstOrDefault(a => a.Id == id); ;
        }

        public IEnumerable<Aluno> GetAll()
        {
            return _context.Alunos.ToList().OrderBy(a => a.NomeAluno);
        }

        /// <summary>
        /// Busca aluno por cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Aluno GetByCPF(string cpf)
        {               
            var aluno = _context.Alunos.FirstOrDefault(a => a.CPF == cpf);
            
            return aluno;
        }
    }
}
