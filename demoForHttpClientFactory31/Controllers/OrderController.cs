using demoForHttpClientFactory31.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoForHttpClientFactory31.Controllers
{
    /// <summary>
    /// 订单服务
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderServiceClient _orderServiceClient;
        private readonly TeslaOrderHttpClient _teslaOrderHttpClient;
        private readonly TypedOrderHttpClient _typedOrderHttpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="orderServiceClient"></param>
        public OrderController(ILogger<OrderController> logger, OrderServiceClient orderServiceClient, TeslaOrderHttpClient teslaOrderHttpClient, TypedOrderHttpClient typedOrderHttpClient)
        {
            _logger = logger;
            _orderServiceClient = orderServiceClient;
            _teslaOrderHttpClient = teslaOrderHttpClient;
            _typedOrderHttpClient = typedOrderHttpClient;   
        }

        /// <summary>
        /// 获取接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Get()
        {
            return await _orderServiceClient.GetAsync();
        }

        /// <summary>
        /// 获取接口
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTeslaOrder")]
        public async Task<string> GetTeslaOrder()
        {
            return await _teslaOrderHttpClient.GetAsync();
        }

        /// <summary>
        /// 获取接口
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTypedOrder")]
        public async Task<string> GetTypedOrder()
        {
            return await _typedOrderHttpClient.GetAsync();
        }
    }
}
