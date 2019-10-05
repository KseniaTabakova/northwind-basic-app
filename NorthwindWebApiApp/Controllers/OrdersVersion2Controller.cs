using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApiApp.Models;
using NorthwindWebApiApp.Services;
using System.Threading.Tasks;

namespace NorthwindWebApiApp.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersVersion2Controller : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BriefOrderVersion2Model>>> GetOrders()
        {                     
                var result = await this.orderService.GetExtendedOrdersAsync();
                return this.Ok(this.mapper.Map<BriefOrderVersion2Model[]>(result));
            
        }
    }
}
