using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PC1.CORE.Core.Entities;
using PC1.CORE.Core.DTOs;
using PC1.CORE.Core.Interfaces;

namespace PC1.CORE.Core.Services
{
    public class OrdenServicioService
    {

        private readonly IOrdenServicioRepository _repository;

        public OrdenServicioService(IOrdenServicioRepository repository)
        {
            _repository = repository;
        }
    }
}
