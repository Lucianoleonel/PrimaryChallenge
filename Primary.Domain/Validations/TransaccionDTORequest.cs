using Project.Shared;

namespace Primary.Domain.Validations
{
    public static class TransaccionDTORequest
    {
        public static TransaccionDTO DefaultValid => new TransaccionDTO()
        {
            ClienteId = 1,
            MonedaId = 1,
            MontoOperado = 100,
            TipoCambio = 1515,
            Fecha = DateTime.Now,
            TipoOperacion = "Compra"
        };

        public static TransaccionDTO IsInvalid_Cliente => new TransaccionDTO()
        {
            ClienteId = 0,
            MonedaId = 1,
            MontoOperado = 100,
            TipoCambio = 1515,
            Fecha = DateTime.Now,
            TipoOperacion = "Compra"
        };

        public static TransaccionDTO EsFinDeSemana => new TransaccionDTO()
        {
            ClienteId = 0,
            MonedaId = 1,
            MontoOperado = 100,
            TipoCambio = 1515,
            Fecha = new DateTime(2024, 2, 18),
            TipoOperacion = "Compra"
        };

        public static TransaccionDTO MontoOperadoInvalid => new TransaccionDTO()
        {
            ClienteId = 0,
            MonedaId = 1,
            MontoOperado = 0,
            TipoCambio = 1515,
            Fecha = new DateTime(2024, 2, 18),
            TipoOperacion = "Compra"
        };

        public static TransaccionDTO TipoCambioInvalid => new TransaccionDTO()
        {
            ClienteId = 0,
            MonedaId = 1,
            MontoOperado = 1515,
            TipoCambio = 0,
            Fecha = new DateTime(2024, 2, 18),
            TipoOperacion = "Compra"
        };

        public static TransaccionDTO TipoInvalid => new TransaccionDTO()
        {
            ClienteId = 0,
            MonedaId = 1,
            MontoOperado = 1515,
            TipoCambio = 0,
            Fecha = new DateTime(2024, 2, 18),
            TipoOperacion = "Otro"
        };

        public static TransaccionDTO Compramayor200USDInvalido => new TransaccionDTO()
        {
            ClienteId = 1,
            MonedaId = 2,
            MontoOperado = 201,
            TipoCambio = 0,
            Fecha = new DateTime(2024, 2, 18),
            TipoOperacion = "Compra"
        };
    }
}
