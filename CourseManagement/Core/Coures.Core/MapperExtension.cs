using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coures.Core
{
    public static class MapperExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="From"></typeparam>
        /// <typeparam name="To"></typeparam>
        /// <param name="config"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static To ConvertModel<From, To>(this MapperConfiguration config, From source)
        {
            IMapper mapper = config.CreateMapper();
            return mapper.Map<From, To>(source);
        }
    }
}
