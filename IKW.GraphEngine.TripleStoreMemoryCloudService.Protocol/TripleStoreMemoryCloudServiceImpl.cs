using System;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using Trinity;
using Trinity.Diagnostics;
using Trinity.DynamicCluster.Storage;

namespace IKW.GraphEngine.TripleStoreMemoryCloudService.Protocol
{
    public class TripleStoreMemoryCloudServiceImpl : TripleStoreMemoryCloudServiceModuleBase
    {
        public override string GetModuleName() => "TripleStoreMemoryCloudServiceImpl";

        public override void StoreTripleHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response)
        {
            var memoryCloud = Global.CloudStorage as DynamicMemoryCloud;

            Log.WriteLine("Write Triple to MemoryCloud - Testing Only");
        }
    }
}
