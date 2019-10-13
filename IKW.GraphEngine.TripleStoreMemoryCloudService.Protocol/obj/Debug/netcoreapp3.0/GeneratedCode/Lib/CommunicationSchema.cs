#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.Network;
using Trinity.Network.Http;
using Trinity.Network.Messaging;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    internal class ProtocolDescriptor : IProtocolDescriptor
    {
        public string Name
        {
            get;
            set;
        }
        public string RequestSignature
        {
            get;
            set;
        }
        public string ResponseSignature
        {
            get;
            set;
        }
        public TrinityMessageType Type
        {
            get;
            set;
        }
    }
    #region Server
    
    #endregion
    #region Proxy
    
    #endregion
    #region Module
    
    public class TripleStoreMemoryCloudServiceModuleCommunicationSchema : ICommunicationSchema
    {
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.SynReqProtocolDescriptors
        {
            get
            {
                string request_sig;
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.SynReqRspProtocolDescriptors
        {
            get
            {
                string request_sig, response_sig;
                
                {
                    
                    request_sig = "{Guid|string|string|string}";
                    
                    response_sig = "{Guid|string|string|string}";
                    yield return new ProtocolDescriptor()
                    {
                        Name = "StoreTriple",
                        RequestSignature = request_sig,
                        ResponseSignature = response_sig,
                        Type = Trinity.Network.Messaging.TrinityMessageType.SYNC_WITH_RSP
                    };
                }
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.AsynReqProtocolDescriptors
        {
            get
            {
                string request_sig;
                
                yield break;
            }
        }
        IEnumerable<IProtocolDescriptor> ICommunicationSchema.AsynReqRspProtocolDescriptors
        {
            get
            {
                string request_sig;
                string response_sig;
                
                yield break;
            }
        }
        string ICommunicationSchema.Name
        {
            get { return "TripleStoreMemoryCloudServiceModule"; }
        }
        IEnumerable<string> ICommunicationSchema.HttpEndpointNames
        {
            get
            {
                
                yield break;
            }
        }
    }
    [CommunicationSchema(typeof(TripleStoreMemoryCloudServiceModuleCommunicationSchema))]
    public abstract partial class TripleStoreMemoryCloudServiceModuleBase : CommunicationModule { }
    namespace TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule
    {
        /// <summary>
        /// Specifies the type of a synchronous request (without response, that is, response type is void) message.
        /// </summary>
        public enum SynReqMessageType : ushort
        {
            
        }
        /// <summary>
        /// Specifies the type of a synchronous request (with response) message.
        /// </summary>
        public enum SynReqRspMessageType : ushort
        {
            StoreTriple,
            
        }
        /// <summary>
        /// Specifies the type of an asynchronous request (without response) message.
        /// </summary>
        public enum AsynReqMessageType : ushort
        {
            
        }
        /// <summary>
        /// Specifies the type of an asynchronous request (with response) message.
        /// </summary>
        public enum AsynReqRspMessageType : ushort
        {
            
        }
    }
    
    #endregion
    
}

#pragma warning restore 162,168,649,660,661,1522
