using AutoMapper;
using AutoMapper.Internal;


namespace HepsiApiProject.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();

        private IMapper MapperContainer;
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        protected void Config<TDestination, TSource>(int dept = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(x => x.DestinationType == typePair.DestinationType && x.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg => {
                foreach(var item  in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(dept).ForMember(ignore, x=> x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(dept).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}
