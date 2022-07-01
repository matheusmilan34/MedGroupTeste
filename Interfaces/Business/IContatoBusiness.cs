namespace MedGroupTeste.Interfaces.Business
{
    /// <summary>
    /// Implementações dos Métodos de Negocio Relativos a Entidade Contato
    /// </summary>
    public interface IContatoBusiness
    {
        /// <summary>
        /// Aplica a Regra Para um Novo Cadastro de Usuario
        /// </summary>
        /// <param name="dataNascimento"></param>
        /// <returns></returns>
        void ValidadorCadastroUsuario(DateTime dataNascimento);
        /// <summary>
        /// Processa a Idade do Usuario Baseado em Sua Data de Nascimento e a Retorna
        /// </summary>
        /// <param name="dataNascimento"></param>
        /// <returns></returns>
        int ProcessarIdadeUsuario(DateTime dataNascimento);

    }
}
