#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    internal class TypeSystem
    {
        #region TypeID lookup table
        private static Dictionary<Type, uint> TypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(long), 0 }
            ,
            { typeof(Guid), 1 }
            ,
            { typeof(string), 2 }
            ,
            { typeof(List<string>), 3 }
            ,
            { typeof(List<INode>), 4 }
            ,
            { typeof(List<Triple>), 5 }
            ,
            { typeof(INode), 6 }
            ,
            { typeof(Triple), 7 }
            ,
            { typeof(TripleStatement), 8 }
            ,
            { typeof(NodeType), 9 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(Graph), 0 }
            
        };
        #endregion
        internal static uint GetTypeID(Type t)
        {
            uint type_id;
            if (!TypeIDLookupTable.TryGetValue(t, out type_id))
                type_id = uint.MaxValue;
            return type_id;
        }
        internal static uint GetCellTypeID(Type t)
        {
            uint type_id;
            if (!CellTypeIDLookupTable.TryGetValue(t, out type_id))
                throw new Exception("Type " + t.ToString() + " is not a cell.");
            return type_id;
        }
    }
    internal enum TypeConversionAction
    {
        TC_NONCONVERTIBLE = 0,
        TC_ASSIGN,
        TC_TOSTRING,
        TC_PARSESTRING,
        TC_TOBOOL,
        TC_CONVERTLIST,
        TC_WRAPINLIST,
        TC_ARRAYTOLIST,
        TC_EXTRACTNULLABLE,
    }
    internal interface ITypeConverter<T>
    {
        
        T ConvertFrom_long(long value);
        long ConvertTo_long(T value);
        TypeConversionAction GetConversionActionTo_long();
        IEnumerable<long> Enumerate_long(T value);
        
        T ConvertFrom_Guid(Guid value);
        Guid ConvertTo_Guid(T value);
        TypeConversionAction GetConversionActionTo_Guid();
        IEnumerable<Guid> Enumerate_Guid(T value);
        
        T ConvertFrom_string(string value);
        string ConvertTo_string(T value);
        TypeConversionAction GetConversionActionTo_string();
        IEnumerable<string> Enumerate_string(T value);
        
        T ConvertFrom_List_string(List<string> value);
        List<string> ConvertTo_List_string(T value);
        TypeConversionAction GetConversionActionTo_List_string();
        IEnumerable<List<string>> Enumerate_List_string(T value);
        
        T ConvertFrom_List_INode(List<INode> value);
        List<INode> ConvertTo_List_INode(T value);
        TypeConversionAction GetConversionActionTo_List_INode();
        IEnumerable<List<INode>> Enumerate_List_INode(T value);
        
        T ConvertFrom_List_Triple(List<Triple> value);
        List<Triple> ConvertTo_List_Triple(T value);
        TypeConversionAction GetConversionActionTo_List_Triple();
        IEnumerable<List<Triple>> Enumerate_List_Triple(T value);
        
        T ConvertFrom_INode(INode value);
        INode ConvertTo_INode(T value);
        TypeConversionAction GetConversionActionTo_INode();
        IEnumerable<INode> Enumerate_INode(T value);
        
        T ConvertFrom_Triple(Triple value);
        Triple ConvertTo_Triple(T value);
        TypeConversionAction GetConversionActionTo_Triple();
        IEnumerable<Triple> Enumerate_Triple(T value);
        
        T ConvertFrom_TripleStatement(TripleStatement value);
        TripleStatement ConvertTo_TripleStatement(T value);
        TypeConversionAction GetConversionActionTo_TripleStatement();
        IEnumerable<TripleStatement> Enumerate_TripleStatement(T value);
        
        T ConvertFrom_NodeType(NodeType value);
        NodeType ConvertTo_NodeType(T value);
        TypeConversionAction GetConversionActionTo_NodeType();
        IEnumerable<NodeType> Enumerate_NodeType(T value);
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<long>
        
            , ITypeConverter<Guid>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<List<INode>>
        
            , ITypeConverter<List<Triple>>
        
            , ITypeConverter<INode>
        
            , ITypeConverter<Triple>
        
            , ITypeConverter<TripleStatement>
        
            , ITypeConverter<NodeType>
        
        {
            long ITypeConverter<long>.ConvertFrom_long(long value)
            {
                
                return (long)value;
                
            }
            long ITypeConverter<long>.ConvertTo_long(long value)
            {
                return TypeConverter<long>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<long>.Enumerate_long(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'long'.");
                
            }
            Guid ITypeConverter<long>.ConvertTo_Guid(long value)
            {
                return TypeConverter<Guid>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<long>.Enumerate_Guid(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    long intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = long.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "long");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<long>.ConvertTo_string(long value)
            {
                return TypeConverter<string>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<long>.Enumerate_string(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'long'.");
                
            }
            List<string> ITypeConverter<long>.ConvertTo_List_string(long value)
            {
                return TypeConverter<List<string>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<long>.Enumerate_List_string(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'long'.");
                
            }
            List<INode> ITypeConverter<long>.ConvertTo_List_INode(long value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<long>.Enumerate_List_INode(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'long'.");
                
            }
            List<Triple> ITypeConverter<long>.ConvertTo_List_Triple(long value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<long>.Enumerate_List_Triple(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'long'.");
                
            }
            INode ITypeConverter<long>.ConvertTo_INode(long value)
            {
                return TypeConverter<INode>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<long>.Enumerate_INode(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'long'.");
                
            }
            Triple ITypeConverter<long>.ConvertTo_Triple(long value)
            {
                return TypeConverter<Triple>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<long>.Enumerate_Triple(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'long'.");
                
            }
            TripleStatement ITypeConverter<long>.ConvertTo_TripleStatement(long value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<long>.Enumerate_TripleStatement(long value)
            {
                
                yield break;
            }
            long ITypeConverter<long>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'long'.");
                
            }
            NodeType ITypeConverter<long>.ConvertTo_NodeType(long value)
            {
                return TypeConverter<NodeType>.ConvertFrom_long(value);
            }
            TypeConversionAction ITypeConverter<long>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<long>.Enumerate_NodeType(long value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'Guid'.");
                
            }
            long ITypeConverter<Guid>.ConvertTo_long(Guid value)
            {
                return TypeConverter<long>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<Guid>.Enumerate_long(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_Guid(Guid value)
            {
                
                return (Guid)value;
                
            }
            Guid ITypeConverter<Guid>.ConvertTo_Guid(Guid value)
            {
                return TypeConverter<Guid>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<Guid>.Enumerate_Guid(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    Guid intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = Guid.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "Guid");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<Guid>.ConvertTo_string(Guid value)
            {
                return TypeConverter<string>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<Guid>.Enumerate_string(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'Guid'.");
                
            }
            List<string> ITypeConverter<Guid>.ConvertTo_List_string(Guid value)
            {
                return TypeConverter<List<string>>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<Guid>.Enumerate_List_string(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'Guid'.");
                
            }
            List<INode> ITypeConverter<Guid>.ConvertTo_List_INode(Guid value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<Guid>.Enumerate_List_INode(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'Guid'.");
                
            }
            List<Triple> ITypeConverter<Guid>.ConvertTo_List_Triple(Guid value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<Guid>.Enumerate_List_Triple(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'Guid'.");
                
            }
            INode ITypeConverter<Guid>.ConvertTo_INode(Guid value)
            {
                return TypeConverter<INode>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<Guid>.Enumerate_INode(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'Guid'.");
                
            }
            Triple ITypeConverter<Guid>.ConvertTo_Triple(Guid value)
            {
                return TypeConverter<Triple>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<Guid>.Enumerate_Triple(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'Guid'.");
                
            }
            TripleStatement ITypeConverter<Guid>.ConvertTo_TripleStatement(Guid value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<Guid>.Enumerate_TripleStatement(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'Guid'.");
                
            }
            NodeType ITypeConverter<Guid>.ConvertTo_NodeType(Guid value)
            {
                return TypeConverter<NodeType>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<Guid>.Enumerate_NodeType(Guid value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_long(long value)
            {
                
                return Serializer.ToString(value);
                
            }
            long ITypeConverter<string>.ConvertTo_long(string value)
            {
                return TypeConverter<long>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<string>.Enumerate_long(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_Guid(Guid value)
            {
                
                return Serializer.ToString(value);
                
            }
            Guid ITypeConverter<string>.ConvertTo_Guid(string value)
            {
                return TypeConverter<Guid>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<string>.Enumerate_Guid(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_string(string value)
            {
                
                return (string)value;
                
            }
            string ITypeConverter<string>.ConvertTo_string(string value)
            {
                return TypeConverter<string>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<string>.Enumerate_string(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_string(List<string> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<string> ITypeConverter<string>.ConvertTo_List_string(string value)
            {
                return TypeConverter<List<string>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<string>.Enumerate_List_string(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_INode(List<INode> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<INode> ITypeConverter<string>.ConvertTo_List_INode(string value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<string>.Enumerate_List_INode(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                return Serializer.ToString(value);
                
            }
            List<Triple> ITypeConverter<string>.ConvertTo_List_Triple(string value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<string>.Enumerate_List_Triple(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_INode(INode value)
            {
                
                return Serializer.ToString(value);
                
            }
            INode ITypeConverter<string>.ConvertTo_INode(string value)
            {
                return TypeConverter<INode>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<string>.Enumerate_INode(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_Triple(Triple value)
            {
                
                return Serializer.ToString(value);
                
            }
            Triple ITypeConverter<string>.ConvertTo_Triple(string value)
            {
                return TypeConverter<Triple>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<string>.Enumerate_Triple(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                return Serializer.ToString(value);
                
            }
            TripleStatement ITypeConverter<string>.ConvertTo_TripleStatement(string value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<string>.Enumerate_TripleStatement(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_NodeType(NodeType value)
            {
                
                return Serializer.ToString(value);
                
            }
            NodeType ITypeConverter<string>.ConvertTo_NodeType(string value)
            {
                return TypeConverter<NodeType>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<string>.Enumerate_NodeType(string value)
            {
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_long(long value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_long(value));
                    return intermediate_result;
                }
                
            }
            long ITypeConverter<List<string>>.ConvertTo_long(List<string> value)
            {
                return TypeConverter<long>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<string>>.Enumerate_long(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<long>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_Guid(Guid value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_Guid(value));
                    return intermediate_result;
                }
                
            }
            Guid ITypeConverter<List<string>>.ConvertTo_Guid(List<string> value)
            {
                return TypeConverter<Guid>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<List<string>>.Enumerate_Guid(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<Guid>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<string> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_string(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            string element = TypeConverter<string>.ConvertFrom_string(value);
                            intermediate_result = new List<string>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<string>' or 'string'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<string>>.ConvertTo_string(List<string> value)
            {
                return TypeConverter<string>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<string>>.Enumerate_string(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_string(List<string> value)
            {
                
                return (List<string>)value;
                
            }
            List<string> ITypeConverter<List<string>>.ConvertTo_List_string(List<string> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<string>>.Enumerate_List_string(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_INode(List<INode> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_INode(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<INode> ITypeConverter<List<string>>.ConvertTo_List_INode(List<string> value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<List<string>>.Enumerate_List_INode(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<INode>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<string>.ConvertFrom_Triple(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<Triple> ITypeConverter<List<string>>.ConvertTo_List_Triple(List<string> value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<List<string>>.Enumerate_List_Triple(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<Triple>>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_INode(INode value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_INode(value));
                    return intermediate_result;
                }
                
            }
            INode ITypeConverter<List<string>>.ConvertTo_INode(List<string> value)
            {
                return TypeConverter<INode>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<List<string>>.Enumerate_INode(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<INode>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_Triple(Triple value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_Triple(value));
                    return intermediate_result;
                }
                
            }
            Triple ITypeConverter<List<string>>.ConvertTo_Triple(List<string> value)
            {
                return TypeConverter<Triple>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<List<string>>.Enumerate_Triple(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<Triple>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_TripleStatement(value));
                    return intermediate_result;
                }
                
            }
            TripleStatement ITypeConverter<List<string>>.ConvertTo_TripleStatement(List<string> value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<List<string>>.Enumerate_TripleStatement(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<TripleStatement>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_NodeType(NodeType value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_NodeType(value));
                    return intermediate_result;
                }
                
            }
            NodeType ITypeConverter<List<string>>.ConvertTo_NodeType(List<string> value)
            {
                return TypeConverter<NodeType>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<List<string>>.Enumerate_NodeType(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<NodeType>.ConvertFrom_string(element);
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'List<INode>'.");
                
            }
            long ITypeConverter<List<INode>>.ConvertTo_long(List<INode> value)
            {
                return TypeConverter<long>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<INode>>.Enumerate_long(List<INode> value)
            {
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'List<INode>'.");
                
            }
            Guid ITypeConverter<List<INode>>.ConvertTo_Guid(List<INode> value)
            {
                return TypeConverter<Guid>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<List<INode>>.Enumerate_Guid(List<INode> value)
            {
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<INode> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_INode(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            INode element = TypeConverter<INode>.ConvertFrom_string(value);
                            intermediate_result = new List<INode>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<INode>' or 'INode'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<INode>>.ConvertTo_string(List<INode> value)
            {
                return TypeConverter<string>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<INode>>.Enumerate_string(List<INode> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_INode(element);
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<INode> intermediate_result = new List<INode>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<INode>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<INode>>.ConvertTo_List_string(List<INode> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<INode>>.Enumerate_List_string(List<INode> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_INode(element);
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_List_INode(List<INode> value)
            {
                
                return (List<INode>)value;
                
            }
            List<INode> ITypeConverter<List<INode>>.ConvertTo_List_INode(List<INode> value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<List<INode>>.Enumerate_List_INode(List<INode> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<INode>>.ConvertFrom_INode(element);
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'List<INode>'.");
                
            }
            List<Triple> ITypeConverter<List<INode>>.ConvertTo_List_Triple(List<INode> value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<List<INode>>.Enumerate_List_Triple(List<INode> value)
            {
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_INode(INode value)
            {
                
                {
                    List<INode> intermediate_result = new List<INode>();
                    intermediate_result.Add(TypeConverter<INode>.ConvertFrom_INode(value));
                    return intermediate_result;
                }
                
            }
            INode ITypeConverter<List<INode>>.ConvertTo_INode(List<INode> value)
            {
                return TypeConverter<INode>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<List<INode>>.Enumerate_INode(List<INode> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<INode>.ConvertFrom_INode(element);
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'List<INode>'.");
                
            }
            Triple ITypeConverter<List<INode>>.ConvertTo_Triple(List<INode> value)
            {
                return TypeConverter<Triple>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<List<INode>>.Enumerate_Triple(List<INode> value)
            {
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'List<INode>'.");
                
            }
            TripleStatement ITypeConverter<List<INode>>.ConvertTo_TripleStatement(List<INode> value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<List<INode>>.Enumerate_TripleStatement(List<INode> value)
            {
                
                yield break;
            }
            List<INode> ITypeConverter<List<INode>>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'List<INode>'.");
                
            }
            NodeType ITypeConverter<List<INode>>.ConvertTo_NodeType(List<INode> value)
            {
                return TypeConverter<NodeType>.ConvertFrom_List_INode(value);
            }
            TypeConversionAction ITypeConverter<List<INode>>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<List<INode>>.Enumerate_NodeType(List<INode> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'List<Triple>'.");
                
            }
            long ITypeConverter<List<Triple>>.ConvertTo_long(List<Triple> value)
            {
                return TypeConverter<long>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<List<Triple>>.Enumerate_long(List<Triple> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'List<Triple>'.");
                
            }
            Guid ITypeConverter<List<Triple>>.ConvertTo_Guid(List<Triple> value)
            {
                return TypeConverter<Guid>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<List<Triple>>.Enumerate_Guid(List<Triple> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    List<Triple> intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_List_Triple(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        try
                        {
                            Triple element = TypeConverter<Triple>.ConvertFrom_string(value);
                            intermediate_result = new List<Triple>();
                            intermediate_result.Add(element);
                        }
                        catch
                        {
                            throw new ArgumentException("Cannot parse \"" + value + "\" into either 'List<Triple>' or 'Triple'.");
                        }
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<List<Triple>>.ConvertTo_string(List<Triple> value)
            {
                return TypeConverter<string>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<List<Triple>>.Enumerate_string(List<Triple> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<string>.ConvertFrom_Triple(element);
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_List_string(List<string> value)
            {
                
                {
                    List<Triple> intermediate_result = new List<Triple>();
                    foreach (var element in value)
                    {
                        intermediate_result.Add(TypeConverter<Triple>.ConvertFrom_string(element));
                    }
                    return intermediate_result;
                }
                
            }
            List<string> ITypeConverter<List<Triple>>.ConvertTo_List_string(List<Triple> value)
            {
                return TypeConverter<List<string>>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_CONVERTLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<List<Triple>>.Enumerate_List_string(List<Triple> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<string>>.ConvertFrom_Triple(element);
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'List<Triple>'.");
                
            }
            List<INode> ITypeConverter<List<Triple>>.ConvertTo_List_INode(List<Triple> value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<List<Triple>>.Enumerate_List_INode(List<Triple> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                return (List<Triple>)value;
                
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertTo_List_Triple(List<Triple> value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<List<Triple>>.Enumerate_List_Triple(List<Triple> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<List<Triple>>.ConvertFrom_Triple(element);
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'List<Triple>'.");
                
            }
            INode ITypeConverter<List<Triple>>.ConvertTo_INode(List<Triple> value)
            {
                return TypeConverter<INode>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<List<Triple>>.Enumerate_INode(List<Triple> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_Triple(Triple value)
            {
                
                {
                    List<Triple> intermediate_result = new List<Triple>();
                    intermediate_result.Add(TypeConverter<Triple>.ConvertFrom_Triple(value));
                    return intermediate_result;
                }
                
            }
            Triple ITypeConverter<List<Triple>>.ConvertTo_Triple(List<Triple> value)
            {
                return TypeConverter<Triple>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<List<Triple>>.Enumerate_Triple(List<Triple> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<Triple>.ConvertFrom_Triple(element);
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'List<Triple>'.");
                
            }
            TripleStatement ITypeConverter<List<Triple>>.ConvertTo_TripleStatement(List<Triple> value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<List<Triple>>.Enumerate_TripleStatement(List<Triple> value)
            {
                
                yield break;
            }
            List<Triple> ITypeConverter<List<Triple>>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'List<Triple>'.");
                
            }
            NodeType ITypeConverter<List<Triple>>.ConvertTo_NodeType(List<Triple> value)
            {
                return TypeConverter<NodeType>.ConvertFrom_List_Triple(value);
            }
            TypeConversionAction ITypeConverter<List<Triple>>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<List<Triple>>.Enumerate_NodeType(List<Triple> value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'INode'.");
                
            }
            long ITypeConverter<INode>.ConvertTo_long(INode value)
            {
                return TypeConverter<long>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<INode>.Enumerate_long(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'INode'.");
                
            }
            Guid ITypeConverter<INode>.ConvertTo_Guid(INode value)
            {
                return TypeConverter<Guid>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<INode>.Enumerate_Guid(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    INode intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = INode.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "INode");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<INode>.ConvertTo_string(INode value)
            {
                return TypeConverter<string>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<INode>.Enumerate_string(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'INode'.");
                
            }
            List<string> ITypeConverter<INode>.ConvertTo_List_string(INode value)
            {
                return TypeConverter<List<string>>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<INode>.Enumerate_List_string(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'INode'.");
                
            }
            List<INode> ITypeConverter<INode>.ConvertTo_List_INode(INode value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<INode>.Enumerate_List_INode(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'INode'.");
                
            }
            List<Triple> ITypeConverter<INode>.ConvertTo_List_Triple(INode value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<INode>.Enumerate_List_Triple(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_INode(INode value)
            {
                
                return (INode)value;
                
            }
            INode ITypeConverter<INode>.ConvertTo_INode(INode value)
            {
                return TypeConverter<INode>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<INode>.Enumerate_INode(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'INode'.");
                
            }
            Triple ITypeConverter<INode>.ConvertTo_Triple(INode value)
            {
                return TypeConverter<Triple>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<INode>.Enumerate_Triple(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'INode'.");
                
            }
            TripleStatement ITypeConverter<INode>.ConvertTo_TripleStatement(INode value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<INode>.Enumerate_TripleStatement(INode value)
            {
                
                yield break;
            }
            INode ITypeConverter<INode>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'INode'.");
                
            }
            NodeType ITypeConverter<INode>.ConvertTo_NodeType(INode value)
            {
                return TypeConverter<NodeType>.ConvertFrom_INode(value);
            }
            TypeConversionAction ITypeConverter<INode>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<INode>.Enumerate_NodeType(INode value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'Triple'.");
                
            }
            long ITypeConverter<Triple>.ConvertTo_long(Triple value)
            {
                return TypeConverter<long>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<Triple>.Enumerate_long(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'Triple'.");
                
            }
            Guid ITypeConverter<Triple>.ConvertTo_Guid(Triple value)
            {
                return TypeConverter<Guid>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<Triple>.Enumerate_Guid(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    Triple intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = Triple.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "Triple");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<Triple>.ConvertTo_string(Triple value)
            {
                return TypeConverter<string>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<Triple>.Enumerate_string(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'Triple'.");
                
            }
            List<string> ITypeConverter<Triple>.ConvertTo_List_string(Triple value)
            {
                return TypeConverter<List<string>>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<Triple>.Enumerate_List_string(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'Triple'.");
                
            }
            List<INode> ITypeConverter<Triple>.ConvertTo_List_INode(Triple value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<Triple>.Enumerate_List_INode(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'Triple'.");
                
            }
            List<Triple> ITypeConverter<Triple>.ConvertTo_List_Triple(Triple value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<Triple>.Enumerate_List_Triple(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'Triple'.");
                
            }
            INode ITypeConverter<Triple>.ConvertTo_INode(Triple value)
            {
                return TypeConverter<INode>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<Triple>.Enumerate_INode(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_Triple(Triple value)
            {
                
                return (Triple)value;
                
            }
            Triple ITypeConverter<Triple>.ConvertTo_Triple(Triple value)
            {
                return TypeConverter<Triple>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<Triple>.Enumerate_Triple(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'Triple'.");
                
            }
            TripleStatement ITypeConverter<Triple>.ConvertTo_TripleStatement(Triple value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<Triple>.Enumerate_TripleStatement(Triple value)
            {
                
                yield break;
            }
            Triple ITypeConverter<Triple>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'Triple'.");
                
            }
            NodeType ITypeConverter<Triple>.ConvertTo_NodeType(Triple value)
            {
                return TypeConverter<NodeType>.ConvertFrom_Triple(value);
            }
            TypeConversionAction ITypeConverter<Triple>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<Triple>.Enumerate_NodeType(Triple value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'TripleStatement'.");
                
            }
            long ITypeConverter<TripleStatement>.ConvertTo_long(TripleStatement value)
            {
                return TypeConverter<long>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<TripleStatement>.Enumerate_long(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'TripleStatement'.");
                
            }
            Guid ITypeConverter<TripleStatement>.ConvertTo_Guid(TripleStatement value)
            {
                return TypeConverter<Guid>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<TripleStatement>.Enumerate_Guid(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    TripleStatement intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = TripleStatement.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "TripleStatement");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<TripleStatement>.ConvertTo_string(TripleStatement value)
            {
                return TypeConverter<string>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<TripleStatement>.Enumerate_string(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'TripleStatement'.");
                
            }
            List<string> ITypeConverter<TripleStatement>.ConvertTo_List_string(TripleStatement value)
            {
                return TypeConverter<List<string>>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<TripleStatement>.Enumerate_List_string(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'TripleStatement'.");
                
            }
            List<INode> ITypeConverter<TripleStatement>.ConvertTo_List_INode(TripleStatement value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<TripleStatement>.Enumerate_List_INode(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'TripleStatement'.");
                
            }
            List<Triple> ITypeConverter<TripleStatement>.ConvertTo_List_Triple(TripleStatement value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<TripleStatement>.Enumerate_List_Triple(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'TripleStatement'.");
                
            }
            INode ITypeConverter<TripleStatement>.ConvertTo_INode(TripleStatement value)
            {
                return TypeConverter<INode>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<TripleStatement>.Enumerate_INode(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'TripleStatement'.");
                
            }
            Triple ITypeConverter<TripleStatement>.ConvertTo_Triple(TripleStatement value)
            {
                return TypeConverter<Triple>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<TripleStatement>.Enumerate_Triple(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                return (TripleStatement)value;
                
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertTo_TripleStatement(TripleStatement value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<TripleStatement>.Enumerate_TripleStatement(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_NodeType(NodeType value)
            {
                
                throw new InvalidCastException("Invalid cast from 'NodeType' to 'TripleStatement'.");
                
            }
            NodeType ITypeConverter<TripleStatement>.ConvertTo_NodeType(TripleStatement value)
            {
                return TypeConverter<NodeType>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<TripleStatement>.Enumerate_NodeType(TripleStatement value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_long(long value)
            {
                
                throw new InvalidCastException("Invalid cast from 'long' to 'NodeType'.");
                
            }
            long ITypeConverter<NodeType>.ConvertTo_long(NodeType value)
            {
                return TypeConverter<long>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_long()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<long> ITypeConverter<NodeType>.Enumerate_long(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'NodeType'.");
                
            }
            Guid ITypeConverter<NodeType>.ConvertTo_Guid(NodeType value)
            {
                return TypeConverter<Guid>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<NodeType>.Enumerate_Guid(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    NodeType intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = NodeType.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "NodeType");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<NodeType>.ConvertTo_string(NodeType value)
            {
                return TypeConverter<string>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<NodeType>.Enumerate_string(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'NodeType'.");
                
            }
            List<string> ITypeConverter<NodeType>.ConvertTo_List_string(NodeType value)
            {
                return TypeConverter<List<string>>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<NodeType>.Enumerate_List_string(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_List_INode(List<INode> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<INode>' to 'NodeType'.");
                
            }
            List<INode> ITypeConverter<NodeType>.ConvertTo_List_INode(NodeType value)
            {
                return TypeConverter<List<INode>>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_List_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<INode>> ITypeConverter<NodeType>.Enumerate_List_INode(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_List_Triple(List<Triple> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<Triple>' to 'NodeType'.");
                
            }
            List<Triple> ITypeConverter<NodeType>.ConvertTo_List_Triple(NodeType value)
            {
                return TypeConverter<List<Triple>>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_List_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<Triple>> ITypeConverter<NodeType>.Enumerate_List_Triple(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_INode(INode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'INode' to 'NodeType'.");
                
            }
            INode ITypeConverter<NodeType>.ConvertTo_INode(NodeType value)
            {
                return TypeConverter<INode>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_INode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<INode> ITypeConverter<NodeType>.Enumerate_INode(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_Triple(Triple value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Triple' to 'NodeType'.");
                
            }
            Triple ITypeConverter<NodeType>.ConvertTo_Triple(NodeType value)
            {
                return TypeConverter<Triple>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_Triple()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Triple> ITypeConverter<NodeType>.Enumerate_Triple(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'NodeType'.");
                
            }
            TripleStatement ITypeConverter<NodeType>.ConvertTo_TripleStatement(NodeType value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<NodeType>.Enumerate_TripleStatement(NodeType value)
            {
                
                yield break;
            }
            NodeType ITypeConverter<NodeType>.ConvertFrom_NodeType(NodeType value)
            {
                
                return (NodeType)value;
                
            }
            NodeType ITypeConverter<NodeType>.ConvertTo_NodeType(NodeType value)
            {
                return TypeConverter<NodeType>.ConvertFrom_NodeType(value);
            }
            TypeConversionAction ITypeConverter<NodeType>.GetConversionActionTo_NodeType()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<NodeType> ITypeConverter<NodeType>.Enumerate_NodeType(NodeType value)
            {
                
                yield break;
            }
            
            object ITypeConverter<object>.ConvertFrom_long(long value)
            {
                return value;
            }
            long ITypeConverter<object>.ConvertTo_long(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_long()
            {
                throw new NotImplementedException();
            }
            IEnumerable<long> ITypeConverter<object>.Enumerate_long(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_Guid(Guid value)
            {
                return value;
            }
            Guid ITypeConverter<object>.ConvertTo_Guid(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_Guid()
            {
                throw new NotImplementedException();
            }
            IEnumerable<Guid> ITypeConverter<object>.Enumerate_Guid(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_string(string value)
            {
                return value;
            }
            string ITypeConverter<object>.ConvertTo_string(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_string()
            {
                throw new NotImplementedException();
            }
            IEnumerable<string> ITypeConverter<object>.Enumerate_string(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_string(List<string> value)
            {
                return value;
            }
            List<string> ITypeConverter<object>.ConvertTo_List_string(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_string()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<string>> ITypeConverter<object>.Enumerate_List_string(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_INode(List<INode> value)
            {
                return value;
            }
            List<INode> ITypeConverter<object>.ConvertTo_List_INode(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_INode()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<INode>> ITypeConverter<object>.Enumerate_List_INode(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_List_Triple(List<Triple> value)
            {
                return value;
            }
            List<Triple> ITypeConverter<object>.ConvertTo_List_Triple(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_List_Triple()
            {
                throw new NotImplementedException();
            }
            IEnumerable<List<Triple>> ITypeConverter<object>.Enumerate_List_Triple(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_INode(INode value)
            {
                return value;
            }
            INode ITypeConverter<object>.ConvertTo_INode(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_INode()
            {
                throw new NotImplementedException();
            }
            IEnumerable<INode> ITypeConverter<object>.Enumerate_INode(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_Triple(Triple value)
            {
                return value;
            }
            Triple ITypeConverter<object>.ConvertTo_Triple(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_Triple()
            {
                throw new NotImplementedException();
            }
            IEnumerable<Triple> ITypeConverter<object>.Enumerate_Triple(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                return value;
            }
            TripleStatement ITypeConverter<object>.ConvertTo_TripleStatement(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_TripleStatement()
            {
                throw new NotImplementedException();
            }
            IEnumerable<TripleStatement> ITypeConverter<object>.Enumerate_TripleStatement(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_NodeType(NodeType value)
            {
                return value;
            }
            NodeType ITypeConverter<object>.ConvertTo_NodeType(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_NodeType()
            {
                throw new NotImplementedException();
            }
            IEnumerable<NodeType> ITypeConverter<object>.Enumerate_NodeType(object value)
            {
                throw new NotImplementedException();
            }
            
        }
        internal static readonly ITypeConverter<T> s_type_converter = new _TypeConverterImpl() as ITypeConverter<T> ?? new TypeConverter<T>();
        #region Default implementation
        
        T ITypeConverter<T>.ConvertFrom_long(long value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        long ITypeConverter<T>.ConvertTo_long(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_long()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<long> ITypeConverter<T>.Enumerate_long(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_Guid(Guid value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        Guid ITypeConverter<T>.ConvertTo_Guid(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_Guid()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<Guid> ITypeConverter<T>.Enumerate_Guid(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_string(string value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        string ITypeConverter<T>.ConvertTo_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_string()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<string> ITypeConverter<T>.Enumerate_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_string(List<string> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<string> ITypeConverter<T>.ConvertTo_List_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_string()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<string>> ITypeConverter<T>.Enumerate_List_string(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_INode(List<INode> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<INode> ITypeConverter<T>.ConvertTo_List_INode(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_INode()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<INode>> ITypeConverter<T>.Enumerate_List_INode(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_List_Triple(List<Triple> value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        List<Triple> ITypeConverter<T>.ConvertTo_List_Triple(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_List_Triple()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<List<Triple>> ITypeConverter<T>.Enumerate_List_Triple(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_INode(INode value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        INode ITypeConverter<T>.ConvertTo_INode(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_INode()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<INode> ITypeConverter<T>.Enumerate_INode(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_Triple(Triple value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        Triple ITypeConverter<T>.ConvertTo_Triple(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_Triple()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<Triple> ITypeConverter<T>.Enumerate_Triple(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_TripleStatement(TripleStatement value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TripleStatement ITypeConverter<T>.ConvertTo_TripleStatement(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_TripleStatement()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<TripleStatement> ITypeConverter<T>.Enumerate_TripleStatement(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_NodeType(NodeType value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        NodeType ITypeConverter<T>.ConvertTo_NodeType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_NodeType()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<NodeType> ITypeConverter<T>.Enumerate_NodeType(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        #endregion
        internal static readonly uint type_id = TypeSystem.GetTypeID(typeof(T));
        
        internal static T ConvertFrom_long(long value)
        {
            return s_type_converter.ConvertFrom_long(value);
        }
        internal static long ConvertTo_long(T value)
        {
            return s_type_converter.ConvertTo_long(value);
        }
        internal static TypeConversionAction GetConversionActionTo_long()
        {
            return s_type_converter.GetConversionActionTo_long();
        }
        internal static IEnumerable<long> Enumerate_long(T value)
        {
            return s_type_converter.Enumerate_long(value);
        }
        
        internal static T ConvertFrom_Guid(Guid value)
        {
            return s_type_converter.ConvertFrom_Guid(value);
        }
        internal static Guid ConvertTo_Guid(T value)
        {
            return s_type_converter.ConvertTo_Guid(value);
        }
        internal static TypeConversionAction GetConversionActionTo_Guid()
        {
            return s_type_converter.GetConversionActionTo_Guid();
        }
        internal static IEnumerable<Guid> Enumerate_Guid(T value)
        {
            return s_type_converter.Enumerate_Guid(value);
        }
        
        internal static T ConvertFrom_string(string value)
        {
            return s_type_converter.ConvertFrom_string(value);
        }
        internal static string ConvertTo_string(T value)
        {
            return s_type_converter.ConvertTo_string(value);
        }
        internal static TypeConversionAction GetConversionActionTo_string()
        {
            return s_type_converter.GetConversionActionTo_string();
        }
        internal static IEnumerable<string> Enumerate_string(T value)
        {
            return s_type_converter.Enumerate_string(value);
        }
        
        internal static T ConvertFrom_List_string(List<string> value)
        {
            return s_type_converter.ConvertFrom_List_string(value);
        }
        internal static List<string> ConvertTo_List_string(T value)
        {
            return s_type_converter.ConvertTo_List_string(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_string()
        {
            return s_type_converter.GetConversionActionTo_List_string();
        }
        internal static IEnumerable<List<string>> Enumerate_List_string(T value)
        {
            return s_type_converter.Enumerate_List_string(value);
        }
        
        internal static T ConvertFrom_List_INode(List<INode> value)
        {
            return s_type_converter.ConvertFrom_List_INode(value);
        }
        internal static List<INode> ConvertTo_List_INode(T value)
        {
            return s_type_converter.ConvertTo_List_INode(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_INode()
        {
            return s_type_converter.GetConversionActionTo_List_INode();
        }
        internal static IEnumerable<List<INode>> Enumerate_List_INode(T value)
        {
            return s_type_converter.Enumerate_List_INode(value);
        }
        
        internal static T ConvertFrom_List_Triple(List<Triple> value)
        {
            return s_type_converter.ConvertFrom_List_Triple(value);
        }
        internal static List<Triple> ConvertTo_List_Triple(T value)
        {
            return s_type_converter.ConvertTo_List_Triple(value);
        }
        internal static TypeConversionAction GetConversionActionTo_List_Triple()
        {
            return s_type_converter.GetConversionActionTo_List_Triple();
        }
        internal static IEnumerable<List<Triple>> Enumerate_List_Triple(T value)
        {
            return s_type_converter.Enumerate_List_Triple(value);
        }
        
        internal static T ConvertFrom_INode(INode value)
        {
            return s_type_converter.ConvertFrom_INode(value);
        }
        internal static INode ConvertTo_INode(T value)
        {
            return s_type_converter.ConvertTo_INode(value);
        }
        internal static TypeConversionAction GetConversionActionTo_INode()
        {
            return s_type_converter.GetConversionActionTo_INode();
        }
        internal static IEnumerable<INode> Enumerate_INode(T value)
        {
            return s_type_converter.Enumerate_INode(value);
        }
        
        internal static T ConvertFrom_Triple(Triple value)
        {
            return s_type_converter.ConvertFrom_Triple(value);
        }
        internal static Triple ConvertTo_Triple(T value)
        {
            return s_type_converter.ConvertTo_Triple(value);
        }
        internal static TypeConversionAction GetConversionActionTo_Triple()
        {
            return s_type_converter.GetConversionActionTo_Triple();
        }
        internal static IEnumerable<Triple> Enumerate_Triple(T value)
        {
            return s_type_converter.Enumerate_Triple(value);
        }
        
        internal static T ConvertFrom_TripleStatement(TripleStatement value)
        {
            return s_type_converter.ConvertFrom_TripleStatement(value);
        }
        internal static TripleStatement ConvertTo_TripleStatement(T value)
        {
            return s_type_converter.ConvertTo_TripleStatement(value);
        }
        internal static TypeConversionAction GetConversionActionTo_TripleStatement()
        {
            return s_type_converter.GetConversionActionTo_TripleStatement();
        }
        internal static IEnumerable<TripleStatement> Enumerate_TripleStatement(T value)
        {
            return s_type_converter.Enumerate_TripleStatement(value);
        }
        
        internal static T ConvertFrom_NodeType(NodeType value)
        {
            return s_type_converter.ConvertFrom_NodeType(value);
        }
        internal static NodeType ConvertTo_NodeType(T value)
        {
            return s_type_converter.ConvertTo_NodeType(value);
        }
        internal static TypeConversionAction GetConversionActionTo_NodeType()
        {
            return s_type_converter.GetConversionActionTo_NodeType();
        }
        internal static IEnumerable<NodeType> Enumerate_NodeType(T value)
        {
            return s_type_converter.Enumerate_NodeType(value);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
