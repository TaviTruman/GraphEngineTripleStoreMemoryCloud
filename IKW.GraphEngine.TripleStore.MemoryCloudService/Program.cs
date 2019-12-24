using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using FanoutSearch;
using IKW.GraphEngine.TripleStoreMemoryCloudService.Protocol;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using Trinity;
using Trinity.Diagnostics;
using Trinity.DynamicCluster.Storage;
using Trinity.ServiceFabric;
using Trinity.ServiceFabric.Remoting;
using static Trinity.Core.Lib.CellIdFactory;

namespace IKW.GraphEngine.TripleStore.MemoryCloudService
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        // Workaround: extension assembly will be removed by the
        // compiler if it is not explicitly used in the code.
        //[UseExtension(typeof(BlobStoragePersistentStorage))]
        [UseExtension(typeof(ITrinityOverRemotingService))]
        [UseExtension(typeof(FanoutSearchModule))]
        [UseExtension(typeof(TripleStoreMemoryCloudServiceImpl))]
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                // When StartService returns, it is guaranteed that Global.CloudStorage
                // is fully operational, and Global.CommunicationInstance is successfully
                // started.

                // Trinity-GraphEngine Azure Service Fabric initialization Step 1: 

                GraphEngineService.StartServiceAsync("IKW.GraphEngine.TripleStore.MemoryCloudServiceType").GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(GraphEngineService).Name);

                Log.WriteLine("Hello world from GE-SF integration!");


                var dynamicMemoryCloud = Global.CloudStorage as DynamicMemoryCloud;

                var myTriple =
                    new Triple()
                    {
                        GraphInstance = NewCellId(),
                        HashCode = Trinity.Core.Lib.HashHelper.HashString2Int64($"IKW.GraphEngine.TripleStore.MemoryCloudServiceType"),
                        Nodes = new System.Collections.Generic.List<INode>()
                        {
                            new INode()
                            {
                                GraphParent = 0,
                                GraphUri    = "http://www.inknowworks.semanticweb.ontology/persongraph",
                                HashCode    = Trinity.Core.Lib.HashHelper.HashString2Int64($"IKW.GraphEngine.TripleStore.MemoryCloudServiceType"),
                                TypeOfNode  = NodeType.GraphLiteral
                            }
                        }
                    };

                var tripleCollection = new List<Triple> { myTriple };

                Graph myGraph = new Graph()
                {
                    BaseUri = "http://www.inknowworks.semanticweb.ontology/",
                    CellId  = NewCellId(),
                    TripleCollection = tripleCollection
                };

                //dynamicMemoryCloud?.SaveGraph(myGraph);

                // Trinity-GraphEngine Azure Service Fabric initialization Step 2: I'm not sure this is right?!!! TT @ 01/10/2019



                // Also, pay attention that, only *master replicas of the partitions* reach here.
                // When the cluster is shutting down, it is possible that the secondary replicas
                // become the master. However, these "transient" masters will be blocked, and
                // do not reach this point.


                // This is the stock-original text-book API Azure.SDK for .NET call 

                // Step 1:

                //ServiceRuntime.RegisterServiceAsync("IKW.GraphEngine.TripleStore.MemoryCloudServiceType",
                //    context => new MemoryCloudService(context)).GetAwaiter().GetResult();

                // Step 2:

                //ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(MemoryCloudService).Name);

                // Prevents this host process from terminating so services keep running.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
