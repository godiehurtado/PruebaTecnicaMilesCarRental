namespace MilesCarRental_UoW.Interfaces
{
    /// <summary>
    /// Interfaz que define un adaptador (Adapter) para la Unidad de Trabajo (Unit of Work).
    /// </summary>
    public interface IUoWAdapter : IDisposable
    {
        /// <summary>
        /// Obtiene el conjunto de repositorios asociados a esta adaptación.
        /// </summary>
        IUoWRepository Repositories { get; }

        /// <summary>
        /// Confirma y guarda los cambios realizados en la transacción.
        /// </summary>
        void SaveChange();
    }
}
