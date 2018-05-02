using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EscolaMunicipalAPI.Models.Aluno;
using EscolaMunicipalAPI.Repository;

namespace EscolaMunicipalAPI.Controllers
{
    /// <summary>
    /// API com todos as funcionalidades do aluno
    /// </summary>
    [RoutePrefix("api/alunos")]
    public class AlunoController : ApiController
    {
        private IRepository<Aluno> _alunoRepository;

        
        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }

        /// <summary>
        /// API que busca todos os alunos cadastrados
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IHttpActionResult GetAlunos()
        {
            try
            {
                return Ok(_alunoRepository.GetAll());

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            } 
           
           
        }

        /// <summary>
        ///  API que busca o aluno pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:long}")]
        public IHttpActionResult GetAluno(long id)
        {
            try
            {
                Aluno aluno = _alunoRepository.GetById(id);

                if (aluno == null)
                {
                    return NotFound();
                }

                return Ok(aluno);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        /// <summary>
        /// API que busca aluno por CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [Route("GetByCPF/{cpf}")]
        public IHttpActionResult GetAlunoByCPF(string cpf)
        {

            try
            {
                Aluno aluno = _alunoRepository.GetByCPF(cpf);

                if (aluno == null)
                {
                    return NotFound();
                }

                return Ok(aluno);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// API que cadastra um novo aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _alunoRepository.Insert(aluno);

                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// API que edita as informações do aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:long}")]
        public IHttpActionResult UpdateAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _alunoRepository.Update(aluno);

                return Ok(result);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        /// <summary>
        /// API que insere uma lista de alunos
        /// </summary>
        /// <param name="alunos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertList")]
        public IHttpActionResult InsertListAlunos(List<Aluno> alunos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _alunoRepository.InsertList(alunos);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// API que exclui o cadastro do aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult DeleteAluno(long id)
        {
            try
            {
                _alunoRepository.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }
              
    }
}