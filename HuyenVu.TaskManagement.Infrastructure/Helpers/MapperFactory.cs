using AutoMapper;

namespace HuyenVu.TaskManagement.Infrastructure.Helpers
{
    // Can make to dependency injection
    public static class MapperFactory
    {
        public static IMapper GetMapper<T, TDestination>()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<T, TDestination>());
            return new Mapper(config);
        }

        public static IMapper GetMapper(MapperConfiguration config)
        {
            return new Mapper(config);
        }
    }
}