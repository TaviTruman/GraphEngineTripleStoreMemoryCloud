#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    /// <summary>
    /// Represents the enum type NodeType defined in the TSL.
    /// </summary>
    public enum NodeType : byte
    {
        Blank = 0,Uri = 1,Literal = 2,GraphLiteral = 3,Variable = 4
    }
    
    /// <summary>
    /// Represents the enum type TripleSegmentPart defined in the TSL.
    /// </summary>
    public enum TripleSegmentPart : byte
    {
        Subject = 0,Predicate = 1,Object = 2
    }
    
}

#pragma warning restore 162,168,649,660,661,1522
