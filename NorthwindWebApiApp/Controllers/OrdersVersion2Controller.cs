using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApiApp.Models;
using NorthwindWebApiApp.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace NorthwindWebApiApp.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersVersion2Controller : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;
        private readonly ILogger<OrdersController> logger;

        public OrdersVersion2Controller(IOrderService orderService, ILogger<OrdersController> logger)
        {
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BriefOrderVersion2Model>>> GetOrders()
        {
            this.logger.LogInformation("Calling BriefOrderVersion2Model.GetOrders");
            try
            {
                var result = await orderService.GetExtendedOrdersAsync();
                return this.Ok(this.mapper.Map<BriefOrderVersion2Model[]>(result));
            }
            catch (Exception e)
            {
                this.logger.LogError(e, "Exception in BriefOrderVersion2Model.GetOrders.");
                throw;
            }
        }
    }
}
