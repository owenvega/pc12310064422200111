using PC1.CORE.Core.DTOs;

namespace PC1.CORE.Core.Interfaces
{
    public interface IOrdenServicioService
    {
        Task<OrdenServicioDTO> Create(CreateOrdenServicioDTO dto);
        Task<bool> Delete(int id);
        Task<IEnumerable<OrdenServicioListDTO>> GetAll();
        Task<OrdenServicioDTO> GetById(int id);
        Task<OrdenServicioDTO> Update(int id, UpdateOrdenServicioDTO dto);
    }
}