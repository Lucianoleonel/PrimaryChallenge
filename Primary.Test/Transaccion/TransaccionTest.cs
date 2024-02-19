using Primary.Domain.Exceptions;
using Primary.Domain.Validations;
using Project.Shared;

namespace Primary.Test.Transaccion
{
    [TestClass]
    public class TransaccionTest
    {
        public TransaccionTest()
        {

        }

        [TestMethod]
        public void IsValidTest()
        {
            TransaccionDTO transaccion = new TransaccionDTO()
            {
                ClienteId = 1,
                MonedaId = 1,
                MontoOperado = 100,
                TipoCambio = 1515,
                Fecha = DateTime.Now,
                TipoOperacion = "Compra"
            };
            TransaccionValidation.IsValidModel(transaccion);
            Assert.AreEqual(transaccion, transaccion);
        }

        [TestMethod]
        public void IsInvalid_ClienteTest()
        {
            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.IsValidModel(TransaccionDTORequest.IsInvalid_Cliente);
            });
        }


        [TestMethod]
        public void MontoOperadoInvalidTest()
        {
            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.IsValidModel(TransaccionDTORequest.MontoOperadoInvalid);
            });
        }

        [TestMethod]
        public void TipoCambioInvalidTest()
        {
            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.IsValidModel(TransaccionDTORequest.TipoCambioInvalid);
            });
        }


        [TestMethod]
        public void EsFinDeSemanaTest()
        {

            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.EsFinDeSemana(TransaccionDTORequest.EsFinDeSemana.Fecha);
            });
        }

        [TestMethod]
        public void TipoInvalidTest()
        {
            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.IsValidModel(TransaccionDTORequest.TipoInvalid);
            });
        }

        [TestMethod]
        public void Compramayor200USDInvalidoTest()
        {
            Assert.ThrowsException<InvalidTransactionException>(() =>
            {
                TransaccionValidation.IsValidModel(TransaccionDTORequest.Compramayor200USDInvalido);
            });
        }


    }
}
