using System;
using System.Collections.Generic;
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
            Log.WriteLine("Hello world from GE-SF integration!");

            var dynamicMemoryCloud = Global.CloudStorage as DynamicMemoryCloud;

            var localMemoryCloud = Global.LocalStorage;

            var myTriple =
                new Triple()
                {
                    GraphInstance = Trinity.Core.Lib.CellIdFactory.NewCellId(),
                    HashCode = Trinity.Core.Lib.HashHelper.HashString2Int64("http://www.inknowworks.semanticweb.ontology/"),
                    Nodes = new List<INode>()
                    {
                        new INode()
                        {
                            GraphParent = Trinity.Core.Lib.CellIdFactory.NewCellId(),
                            GraphUri    = "http://www.inknowworks.semanticweb.ontology/persongraph",
                            HashCode    = Trinity.Core.Lib.HashHelper.HashString2Int64("http://www.inknowworks.semanticweb.ontology/persongraph"),
                            TypeOfNode  = NodeType.GraphLiteral
                        }
                    }
                };

            var tripleCollection = new List<Triple> { myTriple };

            var myGraph = new Graph()
            {
                BaseUri = "http://www.inknowworks.semanticweb.ontology/",
                CellId  = Trinity.Core.Lib.CellIdFactory.NewCellId(),
                TripleCollection = tripleCollection
            };

            dynamicMemoryCloud?.SaveGraph(myGraph);

        }
    }
}
