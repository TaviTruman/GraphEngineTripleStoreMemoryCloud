#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.Core.Lib;
using Trinity.Network;
using Trinity.Network.Messaging;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using Trinity.Storage;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    public abstract partial class TripleStoreMemoryCloudServiceModuleBase : CommunicationModule
    {
        protected override void RegisterMessageHandler()
        {
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(this.SynReqIdOffset + (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqMessageType.Ping), _PingHandler);
                
            }
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(this.SynReqRspIdOffset + (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqRspMessageType.StoreTriple), _StoreTripleHandler);
                
            }
            
            {
                
                MessageRegistry.RegisterMessageHandler((ushort)(this.SynReqRspIdOffset + (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqRspMessageType.HelloMessage), _HelloMessageHandler);
                
            }
            
        }
        
        private unsafe void _PingHandler(SynReqArgs args)
        {
            PingHandler();
            
        }
        
        public abstract void PingHandler();
        
        private unsafe void _StoreTripleHandler(SynReqRspArgs args)
        {
            var rsp = new StoreTripleResponseWriter();
            StoreTripleHandler(new StoreTripleRequestReader(args.Buffer, args.Offset), rsp);
            *(int*)(rsp.m_ptr - TrinityProtocol.MsgHeader) = rsp.Length + TrinityProtocol.TrinityMsgHeader;
            args.Response = new TrinityMessage(rsp.buffer, rsp.Length + TrinityProtocol.MsgHeader);
        }
        public abstract void StoreTripleHandler(StoreTripleRequestReader request, StoreTripleResponseWriter response);
        
        private unsafe void _HelloMessageHandler(SynReqRspArgs args)
        {
            var rsp = new HelloMessageReponseWriter();
            HelloMessageHandler(new HelloNessageRequestReader(args.Buffer, args.Offset), rsp);
            *(int*)(rsp.m_ptr - TrinityProtocol.MsgHeader) = rsp.Length + TrinityProtocol.TrinityMsgHeader;
            args.Response = new TrinityMessage(rsp.buffer, rsp.Length + TrinityProtocol.MsgHeader);
        }
        public abstract void HelloMessageHandler(HelloNessageRequestReader request, HelloMessageReponseWriter response);
        
    }
    
    namespace TripleStoreMemoryCloudServiceModule
    {
        public static class MessagePassingExtension
        {
            
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static void Ping(this Trinity.Storage.IMessagePassingEndpoint storage)
        {
            byte* bufferPtr = stackalloc byte[TrinityProtocol.MsgHeader];
            *(int*)(bufferPtr) = TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqMessageType.Ping;
            storage.SendMessage<TripleStoreMemoryCloudServiceModuleBase>(bufferPtr, TrinityProtocol.MsgHeader);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static StoreTripleResponseReader StoreTriple(this Trinity.Storage.IMessagePassingEndpoint storage, StoreTripleRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC_WITH_RSP ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqRspMessageType.StoreTriple;
            TrinityResponse response;
            storage.SendMessage<TripleStoreMemoryCloudServiceModuleBase>(bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new StoreTripleResponseReader(response.Buffer, response.Offset);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe static HelloMessageReponseReader HelloMessage(this Trinity.Storage.IMessagePassingEndpoint storage, HelloNessageRequestWriter msg)
        {
            byte* bufferPtr = msg.buffer;
            *(int*)(bufferPtr) = msg.Length + TrinityProtocol.TrinityMsgHeader;
            *(TrinityMessageType*)(bufferPtr + TrinityProtocol.MsgTypeOffset) = TrinityMessageType.SYNC_WITH_RSP ;
            *(ushort*)(bufferPtr + TrinityProtocol.MsgIdOffset) = (ushort)global::InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.TSL.CommunicationModule.TripleStoreMemoryCloudServiceModule.SynReqRspMessageType.HelloMessage;
            TrinityResponse response;
            storage.SendMessage<TripleStoreMemoryCloudServiceModuleBase>(bufferPtr, msg.Length + TrinityProtocol.MsgHeader, out response);
            return new HelloMessageReponseReader(response.Buffer, response.Offset);
        }
        
        }
    }
    
    #region Legacy
    public static class LegacyMessagePassingExtension
    {
        
    }
    
    public abstract partial class TripleStoreMemoryCloudServiceModuleBase : CommunicationModule
    {
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe  void Ping( int partitionId)
        {
            TripleStoreMemoryCloudServiceModule.MessagePassingExtension.Ping(m_memorycloud[partitionId]);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe StoreTripleResponseReader StoreTriple( int partitionId, StoreTripleRequestWriter msg)
        {
            return TripleStoreMemoryCloudServiceModule.MessagePassingExtension.StoreTriple(m_memorycloud[partitionId], msg);
        }
        
        #region prototype definition template variables
        
        #endregion
        
        public unsafe HelloMessageReponseReader HelloMessage( int partitionId, HelloNessageRequestWriter msg)
        {
            return TripleStoreMemoryCloudServiceModule.MessagePassingExtension.HelloMessage(m_memorycloud[partitionId], msg);
        }
        
    }
    
    #endregion
}

#pragma warning restore 162,168,649,660,661,1522
