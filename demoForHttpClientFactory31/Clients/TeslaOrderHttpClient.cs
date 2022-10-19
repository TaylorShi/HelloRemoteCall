using System.Net.Http;
using System.Threading.Tasks;

namespace demoForHttpClientFactory31.Clients
{
    /// <summary>
    /// 特斯拉订单网络请求
    /// </summary>
    public class TeslaOrderHttpClient
    {
        readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 客户端名称
        /// </summary>
        readonly string _clientName = "TeslaOrderHttpClient";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public TeslaOrderHttpClient(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAsync()
        {
            // 根据客户端的名称来获取客户端
            var client = _httpClientFactory.CreateClient(_clientName);

            // 使用Client发起Http请求
            return await client.GetStringAsync("/order");
        }
    }
}
