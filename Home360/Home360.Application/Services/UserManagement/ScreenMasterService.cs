using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    internal class ScreenMasterService : IScreenMasterService
    {
        private readonly IScreenMasterRepository _screenMasterRepository;
        private readonly IMapper _mapper;

        public ScreenMasterService(IScreenMasterRepository screenMasterRepository, IMapper mapper)
        {
            _screenMasterRepository = screenMasterRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterScreenAsync(ScreenMasterRequest screenRequest)
        {
            var screenCodeExists = await _screenMasterRepository.ScreenCodeExistsAsync(screenRequest.ScreenCode);
            if (screenCodeExists) return "Screen Code already exists!";

            var screen = _mapper.Map<ScreenMaster>(screenRequest);

            bool screenAdded = await _screenMasterRepository.RegisterScreenAsync(screen);
            return screenAdded ? "Screen Added Successfully" : "Screen failed to add!";
        }

        public async Task<List<ScreenMasterResponse>> GetAllScreensAsync()
        {
            // Add Cache as Data will not change Frequently
            return _mapper.Map<List<ScreenMasterResponse>>(await _screenMasterRepository.GetAllScreensAsync());
        }
    }
}
