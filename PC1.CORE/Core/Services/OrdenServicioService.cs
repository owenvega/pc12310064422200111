using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PC1.CORE.Core.Entities;
using PC1.CORE.Core.DTOs;
using PC1.CORE.Core.Interfaces;
using Microsoft.Identity.Client;
using PC1.CORE.Infrastructure.Data;

namespace PC1.CORE.Core.Services
{
    public class OrdenServicioService : IOrdenServicioService
    {
        // Inyección de dependencias del repositorio
        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioService(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrdenServicioListDTO>> GetAll()
        {
            var ordenes = await _repository.getOrdenServicio();
            return ordenes.Select(os => new OrdenServicioListDTO
            {
                Id = os.Id,
                FechaIngreso = os.FechaIngreso,
                DescripcionProblema = os.DescripcionProblema,
                CostoEstimado = os.CostoEstimado,
                Estado = os.Estado,
                VehiculoId = os.VehiculoId,
                TipoServicioId = os.TipoServicioId,
                TipoServicioNombre = os.TipoServicio.Nombre,
                VehiculoPlaca = os.Vehiculo.Placa
            });
        }

        public async Task<OrdenServicioDTO> GetById(int id)
        {
            var os = await _repository.getOrdenServicioById(id);
            if (os == null) return null;
            return new OrdenServicioDTO
            {
                Id = os.Id,
                FechaIngreso = os.FechaIngreso,
                DescripcionProblema = os.DescripcionProblema,
                CostoEstimado = os.CostoEstimado,
                Estado = os.Estado,
                VehiculoId = os.VehiculoId,
                TipoServicioId = os.TipoServicioId
            };
        }

        public async Task<OrdenServicioDTO> Create(CreateOrdenServicioDTO dto)
        {
            var os = new OrdenServicio
            {
                FechaIngreso = dto.FechaIngreso,
                DescripcionProblema = dto.DescripcionProblema,
                CostoEstimado = dto.CostoEstimado,
                Estado = dto.Estado,
                VehiculoId = dto.VehiculoId,
                TipoServicioId = dto.TipoServicioId
            };
            var created = await _repository.createOrdenServicio(os);
            return new OrdenServicioDTO
            {
                Id = created.Id,
                FechaIngreso = created.FechaIngreso,
                DescripcionProblema = created.DescripcionProblema,
                CostoEstimado = created.CostoEstimado,
                Estado = created.Estado,
                VehiculoId = created.VehiculoId,
                TipoServicioId = created.TipoServicioId
            };


        }

        public async Task<OrdenServicioDTO> Update(int id, UpdateOrdenServicioDTO dto)
        {
            var os = await _repository.getOrdenServicioById(id);
            if (os == null) return null;
            os.FechaIngreso = dto.FechaIngreso;
            os.DescripcionProblema = dto.DescripcionProblema;
            os.CostoEstimado = dto.CostoEstimado;
            os.Estado = dto.Estado;
            os.VehiculoId = dto.VehiculoId;
            os.TipoServicioId = dto.TipoServicioId;
            var updated = await _repository.updateOrdenServicio(os);
            return new OrdenServicioDTO
            {
                Id = updated.Id,
                FechaIngreso = updated.FechaIngreso,
                DescripcionProblema = updated.DescripcionProblema,
                CostoEstimado = updated.CostoEstimado,
                Estado = updated.Estado,
                VehiculoId = updated.VehiculoId,
                TipoServicioId = updated.TipoServicioId
            };
        }


        public async Task<bool> Delete(int id)
        {
            return await _repository.deleteOrdenServicio(id);
        }
    }
}