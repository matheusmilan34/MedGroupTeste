using MedGroupTeste.Data;
using MedGroupTeste.Interfaces.Business;

namespace MedGroupTeste.Business
{
    /// <summary>
    /// Implementações dos Métodos de Negocio Relativos a Entidade Contato
    /// </summary>
    public class ContatoBusiness : IContatoBusiness
    {
        private readonly DataContext _dataContext;
        /// <summary>
        /// Construtor Para Injeção de Dependencia
        /// </summary>
        public ContatoBusiness(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Aplica a Regra Para um Novo Cadastro de Usuario
        /// </summary>
        /// <param name="dataNascimento"></param>
        /// <returns></returns>
        public void ValidadorCadastroUsuario(DateTime dataNascimento)
        {
            if (dataNascimento >= DateTime.Now)
                throw new Exception("Data Invalida : Data maior ou igual a Data Atual");
            if (ProcessarIdadeUsuario(dataNascimento) < 18)
                throw new Exception("Usuario Menor de Idade Não Permitido");
        }
        /// <summary>
        /// Processa a Idade do Usuario Baseado em Sua Data de Nascimento e a Retorna
        /// </summary>
        /// <param name="dataNascimento"></param>
        /// <returns></returns>
        public int ProcessarIdadeUsuario(DateTime dataNascimento)
        {
            int idade;
            DateTime dataAtual = DateTime.Now;
            idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual.Month < dataNascimento.Month || (dataAtual.Month == dataNascimento.Month && dataAtual.Day < dataNascimento.Day))
            {
                idade--;
            }
            return (idade < 0) ? 0 : idade;
        }
    }
}
