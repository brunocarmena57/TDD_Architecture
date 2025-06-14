﻿using TDD_Architecture.Application.Mappings;

namespace TDD_Architecture.Config.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                    typeof(ViewModelToDomainMappingProfile));
        }
    }
}
