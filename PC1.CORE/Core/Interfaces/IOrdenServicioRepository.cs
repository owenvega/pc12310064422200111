using PC1.CORE.Core.Entities;

namespace PC1.CORE.Core.Interfaces
{
    public interface IOrdenServicioRepository
    {
        Task<OrdenServicio> createOrdenServicio(OrdenServicio ordenServicio);
        Task<bool> deleteOrdenServicio(int id);
        Task<IEnumerable<OrdenServicio>> getOrdenServicio();
        Task<OrdenServicio> getOrdenServicioById(int id);
        Task<OrdenServicio> updateOrdenServicio(OrdenServicio ordenServicio);
    }
}