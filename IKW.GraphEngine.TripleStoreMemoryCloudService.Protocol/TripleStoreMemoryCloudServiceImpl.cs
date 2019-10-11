using System;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using Trinity.Diagnostics;

namespace IKW.GraphEngine.TripleStoreMemoryCloudService.Protocol
{
    public class TripleStoreMemoryCloudServiceImpl : TripleStoreMemoryCloudServiceModuleBase
    {
        public override string GetModuleName() => "TripleStoreMemoryCloudServiceImpl";

        public override void StoreTripleHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response)
        {
            throw new NotImplementedException();
        }
    }
}
