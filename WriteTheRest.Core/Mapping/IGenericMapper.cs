using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Mapping
{
    public interface IGenericMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        void Map<TSource, TDestination>(TSource source, TDestination destination);
        List<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
