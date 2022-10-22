using Grpc.Core;
using Helloworld;
using System.Threading.Tasks;

namespace demoForGrpcSwagger.GrpcServices
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return base.SayHello(request, context);
        }
    }
}
