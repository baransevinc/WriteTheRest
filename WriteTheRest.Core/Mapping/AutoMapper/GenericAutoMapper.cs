using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Mapping.AutoMapper
{
    public class GenericAutoMapper : IGenericMapper
    {
        private readonly IMapper _mapper;

        public GenericAutoMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            _mapper.Map(source, destination);
        }

        public List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.Select(item => _mapper.Map<TDestination>(item)).ToList();
        }
    }
}
