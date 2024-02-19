using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Domain.Helpers
{
    public static class EnumsHelpers
    {
        public enum TipoTransaccion
        {
            Compra,
            Venta
        }

        public enum Monedas
        {
            Pesos = 1,
            Dolar = 2
        }
        
    }

}
