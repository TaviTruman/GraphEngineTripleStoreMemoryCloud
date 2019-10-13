﻿using System;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using Trinity;
using Trinity.Diagnostics;

namespace IKW.GraphEngine.TripleStoreMemoryCloudService.Protocol
{
    public class TripleStoreMemoryCloudServiceImpl : TripleStoreMemoryCloudServiceModuleBase
    {
        public override string GetModuleName() => "TripleStoreMemoryCloudServiceImpl";

        public override void StoreTripleHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response)
        {
            Log.WriteLine("Hello world from GE-SF integration!");

        }
    }
}
