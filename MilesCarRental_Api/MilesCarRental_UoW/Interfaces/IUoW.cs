namespace MilesCarRental_UoW.Interfaces
{
    /// <summary>
    /// Interfaz que define una Unidad de Trabajo (Unit of Work).
    /// </summary>
    public interface IUoW
    {
        /// <summary>
        /// Crea y devuelve un adaptador (Adapter) para la Unidad de Trabajo.
        /// </summary>
        /// <returns>Instancia de IUoWAdapter asociada a esta Unidad de Trabajo.</returns>
        IUoWAdapter Create();
    }
}
