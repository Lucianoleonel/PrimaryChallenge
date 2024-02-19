using Primary.Application.Abstractions;
using Primary.Domain.DTO;
using Primary.Infrastructure.Abstractions;
using Project.Shared;

namespace Primary.Application.Implementations
{
    public class MonedaCotizacionService : IMonedaCotizacionService
    {
        private readonly IMonedaCotizacionRepository _monedaCotizacionRepository;

        public MonedaCotizacionService(IMonedaCotizacionRepository monedaCotizacionRepository)
        {
            _monedaCotizacionRepository = monedaCotizacionRepository;
        }

        #region Implementations IMonedaService
        /// <summary>
        /// Get all the moneys from External Service
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<List<MonedaCotizacionDTO>> GetAllCotizacionMonedaAsync()
        {
            //return await _monedaRepository
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the money by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<MonedaCotizacionDTO> GetCotizacionMonedaByIdAsync(int id)
        {
            var rro = _monedaCotizacionRepository.GetMonedaCotizacionByIdAsync(id);
            throw new NotImplementedException();
        }

        #endregion
    }


}
