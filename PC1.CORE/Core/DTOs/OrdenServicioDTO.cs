using System;
using System.Collections.Generic;
using System.Text;

namespace PC1.CORE.Core.DTOs
{
    
    public class OrdenServicioDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }


    public class CreateOrdenServicioDTO
    {
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }

    public class UpdateOrdenServicioDTO
    {
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
    }

    public class OrdenServicioListDTO
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string DescripcionProblema { get; set; } = null!;
        public decimal CostoEstimado { get; set; }
        public string Estado { get; set; } = null!;
        public int VehiculoId { get; set; }
        public int TipoServicioId { get; set; }
        public string TipoServicioNombre { get; set; } = null!;
        public string VehiculoPlaca { get; set; } = null!;
    }

    public class OrdenServicioDeleteDTO
    {
        public int Id { get; set; }
    }
}
