using Primary.Application.Abstractions;
using Primary.Application.Mappers;
using Primary.Domain.DTO;
using Primary.Infrastructure.Abstractions;

namespace Primary.Application.Implementations
{
    public class MonedaService : IMonedaService
    {
        private readonly IMonedaRepository _monedaRepository;

        public MonedaService(IMonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }

        #region Implementations IMonedaService
        public async Task<List<MonedaDTO>> GetAllMonedasAsync()
        {
            var ListMonedas = await _monedaRepository.GetAllMonedaAsync();
            return ListMonedas.Select(MonedaMapper.Map).ToList();
        }

        public async Task<MonedaDTO> GetMonedaByIdAsync(int id)
            => MonedaMapper.Map(await _monedaRepository.GetMonedaByIdAsync(id) ?? new Domain.Moneda());
        
        #endregion
    }


}
