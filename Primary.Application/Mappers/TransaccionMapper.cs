using Primary.Domain.Entities;
using Project.Shared;
using Project.Shared.Domain;

namespace Primary.Application.Mappers
{
    public static class TransaccionMapper
    {
        /// <summary>
        /// Mapeo de Transaccion a TransaccionDTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TransaccionDTO Map(Transaccion entity)
        {
            return new TransaccionDTO()
            {
                Id = entity.Id,
                ClienteId = entity.ClienteId,
                Fecha = entity.Fecha,
                MonedaId = entity.MonedaId,
                MontoOperado = entity.MontoOperado,
                TipoOperacion = entity.TipoOperacion,
                TipoCambio = entity.TipoCambio,
                TipoCambioDescripcion = entity.TipoCambioDescripcion,
            };
        }

        /// <summary>
        /// Mapeo de TransaccionDTO a Transaccion 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Transaccion Map(TransaccionDTO dto)
        {
            return new Transaccion()
            {
                Id = dto.Id ?? 0,
                ClienteId = dto.ClienteId,
                Fecha = dto.Fecha,
                MonedaId = dto.MonedaId,
                MontoOperado = dto.MontoOperado,
                TipoOperacion = dto.TipoOperacion,
                TipoCambio = dto.TipoCambio,
                TipoCambioDescripcion = dto.TipoCambioDescripcion,
            };
        }
    }
}
