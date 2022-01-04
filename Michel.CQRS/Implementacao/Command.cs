using CQRS.Interfaces;

namespace CQRS.Implementacao
{
    /// <summary>
    /// Recebe os parâmetros de entrada do comando e faz a validação
    /// </summary>
    public abstract class Command : Notifiable, ICommand
    {
        /// <summary>
        /// Valida os parâmetros de entrada
        /// </summary>
        public abstract void Validate();
    }
}
