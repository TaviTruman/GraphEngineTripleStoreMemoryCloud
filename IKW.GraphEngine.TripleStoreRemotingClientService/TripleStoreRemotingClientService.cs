using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Query;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IKW.GraphEngine.TripleStoreMemoryCloudService.Protocol;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL;
using InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TripleStoreMemoryCloudServiceModule;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Trinity;
using Trinity.Client;
using Trinity.Client.TrinityClientModule;
using Trinity.Diagnostics;
using StatelessService = Microsoft.ServiceFabric.Services.Runtime.StatelessService;

namespace IKW.GraphEngine.TripleStoreRemotingClientService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class TripleStoreRemotingClientService : StatelessService
    {
        private TrinityClient m_tripleStoreRemotingClient;
        private TripleStoreMemoryCloudServiceImpl m_trinityClient = null; 
        public TripleStoreRemotingClientService(StatelessServiceContext context)
            : base(context)
        {
            m_tripleStoreRemotingClient = new TrinityClient("fabric:/GraphEngineTripleStoreMemoryCloudSFApp/IKW.GraphEngine.TripleStore.MemoryCloudService");
            m_tripleStoreRemotingClient.RegisterCommunicationModule<TripleStoreMemoryCloudServiceImpl>();
            m_tripleStoreRemotingClient.Start();

            var clientModule = m_tripleStoreRemotingClient.GetCommunicationModule<TrinityClientModule>();

            var clientModuleInstance = clientModule.Clients;
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            long iterations = 0;

            var tripleStoreMemoryCloudServiceImpl = Global.CloudStorage.GetCommunicationModule<TripleStoreMemoryCloudServiceImpl>();

            //tripleStoreMemoryCloudServiceImpl.ClientInitialize(RunningMode.Client);

            var serverServiceEndpoint =
                m_tripleStoreRemotingClient.GetCommunicationModule<TripleStoreMemoryCloudServiceImpl>();


            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);

                var rdtTripleStatement = new TripleStatement(Guid.NewGuid(), "GraphEngine", "Powers", "Me");

                var storeTripleRequest =
                    new StoreTripleRequestWriter()
                    {
                        Subject   = "GraphEngine",
                        Predicate = "Works",
                        Object    = "Wonders",
                        RefId     = Guid.NewGuid()
                    };

                ServiceEventSource.Current.ServiceMessage(this.Context, "Working-{0}", ++iterations);

                try
                {
                    //m_tripleStoreRemotingClient.StoreTriple(storeTripleRequest);

                    var resp = Global.LocalStorage.StoreTriple(storeTripleRequest);

                    //var tripleResponse = tripleStoreMemoryCloudServiceImpl.StoreTriple(1,storeTripleRequest);

                    //serverServiceEndpoint.StoreTriple(1, storeTripleRequest);
                }
                catch (Exception e)
                {
                    ServiceEventSource.Current.ServiceMessage(this.Context, $"An Unexpected Error has been detected: {e.Message}");
                }

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}
