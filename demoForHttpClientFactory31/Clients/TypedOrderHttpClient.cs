using System.Net.Http;
using System.Threading.Tasks;

namespace demoForHttpClientFactory31.Clients
{
    /// <summary>
    /// 类型订单客户端
    /// </summary>
    public class TypedOrderHttpClient
    {
        readonly HttpClient _httpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpClient"></param>
        public TypedOrderHttpClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<string> GetAsync()
        {
            // 使用Client发起Http请求
            return await _httpClient.GetStringAsync("/order");
        }
    }
}
