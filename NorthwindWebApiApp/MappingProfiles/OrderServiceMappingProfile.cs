using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApiApp.MappingProfiles
{
    public class OrderServiceMappingProfile : Profile
    {
        public OrderServiceMappingProfile()
        {
            Console.WriteLine("OrderServiceMappingProfile");

            this.CreateMap<BriefOrderDescription, BriefOrderModel>();
            this.CreateMap<BriefOrderVersion2Description, BriefOrderVersion2Model>();
            this.CreateMap<FullOrderDescription, FullOrderModel>();
        }    
    }
}
