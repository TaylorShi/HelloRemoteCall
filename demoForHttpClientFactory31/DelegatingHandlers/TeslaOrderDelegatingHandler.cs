using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace demoForHttpClientFactory31.DelegatingHandlers
{
    /// <summary>
    /// 特斯拉订单管道处理程序
    /// </summary>
    public class TeslaOrderDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("t-Guid", Guid.NewGuid().ToString());
            var result = await base.SendAsync(request, cancellationToken);
            return result;
        }
    }
}
