using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using APIDashboard.Models;
using System.Threading.Tasks;

namespace APIDashboard.Services
{
    public class AutoMap 
    {
       

        public U MapperConvert<T, U>(T DtSource)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(T), typeof(U));
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<T, U>(DtSource);

            return (destination);
        }

        public List<U> MapperConvertList<T, U>(List<T> DtSource)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(T), typeof(U));
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<List<T>, List<U>>(DtSource);

            return (destination);
        }

    }
}
