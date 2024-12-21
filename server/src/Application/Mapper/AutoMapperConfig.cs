using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Mapper
{
    public class AutoMapperConfig
    {
        public static void Configure(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
