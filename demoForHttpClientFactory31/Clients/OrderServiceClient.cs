using System.Net.Http;
using System.Threading.Tasks;

namespace demoForHttpClientFactory31.Clients
{
    /// <summary>
    /// 订单服务请求(工厂构造模式)
    /// </summary>
    public class OrderServiceClient
    {
        readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public OrderServiceClient(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // 使用Client发起Http请求
            return await client.GetStringAsync("https://localhost:5003/order");
        }
    }
}
