using AutoMapper;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.Mapper
{
    public class AutomapperConfig
    {
        public MapperConfiguration Configuration
        {
            get
            {
                return new MapperConfiguration(config =>
                {
                    config.CreateMap<DomainModel.ValueObjects.EditHistory, EditHistory>();

                    config.CreateMap<DomainModel.Entities.Employee, EmployeeCreateResponse>();

                    config.CreateMap<EmployeeManipulate, DomainModel.Entities.Employee>();

                    config.CreateMap<DomainModel.Entities.Employee, EmployeeQueryDetailed>();

                    config.CreateMap<DomainModel.Entities.Employee, EmployeeQuerySimplified>();
                });
            }
        }
    }
}
