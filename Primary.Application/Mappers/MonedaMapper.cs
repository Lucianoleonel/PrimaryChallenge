using Primary.Domain;
using Primary.Domain.DTO;

namespace Primary.Application.Mappers
{
    public static class MonedaMapper
    {

        public static MonedaDTO Map(Moneda entity)
        {
            return new MonedaDTO(entity.Simbolo, entity.Iso, entity.Codigo, entity.Descripcion);
        }


        public static Moneda Map(MonedaDTO dto)
        {
            return new Moneda()
            {
                Simbolo = dto.Simbolo,
                Iso = dto.Iso,
                Descripcion = dto.Descripcion,
                Codigo = dto.Codigo.Value
            };
        }
    }
}
