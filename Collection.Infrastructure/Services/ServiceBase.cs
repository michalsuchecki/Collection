using AutoMapper;

namespace Collection.Infrastructure.Services
{
    public abstract class ServiceBase : IServices
    {
        private readonly IMapper _mapper;

        public ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}