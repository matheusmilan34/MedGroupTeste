using MedGroupTeste.Data;
using MedGroupTeste.Interfaces.Business;
using MedGroupTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedGroupTeste.Controllers
{
    /// <summary>
    /// Controller da ApiContato
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ApiContato : ControllerBase
    {
        private readonly IContatoBusiness _iContatoBusiness;
        private readonly DataContext _dataContext;
        /// <summary>
        /// Construtor Para Injeção de Dependencia
        /// </summary>
        public ApiContato(IContatoBusiness iContatoBusiness,
            DataContext dataContext)
        {
            _iContatoBusiness = iContatoBusiness;
            _dataContext = dataContext;
        }

        /// <summary>
        /// Adiciona um Novo Contato ao Banco de Dados
        /// </summary>
        /// <param name="contato"></param>
        [HttpPost]
        [Route("NovoContato")]
        public void NovoContato(Contato contato)
        {
            _iContatoBusiness.ValidadorCadastroUsuario(contato.DataNascimento);
            contato.Ativo = true;
            _dataContext.Contatos.Add(contato);
            _dataContext.SaveChanges();
        }
        /// <summary>
        /// Lista todos os Contatos Ativos no Banco
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarContatos")]
        public Dictionary<string, object> ListarContatos()
        {
            var listaContatos = _dataContext.Contatos.Where(x => x.Ativo == true).ToList();
            foreach (var item in listaContatos)
            {
                var dic = new Dictionary<string, object>()
                {
                {"Nome:",item.Nome},
                {"Data Nascimento:",item.DataNascimento},
                {"Idade:",_iContatoBusiness.ProcessarIdadeUsuario(item.DataNascimento)},
                {"Sexo:",item.Sexo.ToString()},
                };
                return dic;
            }
            return null;
        }
        /// <summary>
        /// Visualizar Todas as Informações de Um Contato Via Id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [Route("VisualizarDetalheContato")]
        public Dictionary<string, object> VisualizarDetalheContato(int id)
        {
            var contato = _dataContext.Contatos.Where(x => x.Ativo == true && x.Id == id).First();
            if (contato != null)
            {
                var dic = new Dictionary<string, object>()
                {
                {"Nome:",contato.Nome},
                {"Data Nascimento:",contato.DataNascimento},
                {"Idade:",_iContatoBusiness.ProcessarIdadeUsuario(contato.DataNascimento)},
                {"Sexo:",contato.Sexo.ToString()},
                };
                return dic;
            }
            return null;
        }
        /// <summary>
        /// Desativa o contato via Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("DesativarContato")]
        public void DesativarContato(int id)
        {
            var contato = _dataContext.Contatos.Where(x => x.Id == id).First();
            contato.Ativo = false;
            _dataContext.Update(contato);
            _dataContext.SaveChanges();
        }
        /// <summary>
        /// Exclui o contato via Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("ExcluirContato")]
        public void ExcluirContato(int id)
        {
            var contato = _dataContext.Contatos.Where(x => x.Id == id).First();
            _dataContext.Contatos.Remove(contato);
            _dataContext.SaveChanges();
        }
    }
}
