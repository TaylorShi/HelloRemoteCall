using Grpc.Core;
using GrpcServices;
using System.Threading.Tasks;

namespace demoForGitSubmodule.GrpcServices
{
    /// <summary>
    /// 订单服务(基于Grpc)
    /// </summary>
    public class OrderService : OrderGrpc.OrderGrpcBase
    {
        /// <summary>
        /// 重写创建订单
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<CreateOrderResult> CreateOrder(CreateOrderCommand request, ServerCallContext context)
        {
            //throw new System.Exception("我是一个gRPC异常");

            // 可替换成真实的创建订单服务的业务代码
            return Task.FromResult(new CreateOrderResult { OrderId = 11 });
        }
    }
}
