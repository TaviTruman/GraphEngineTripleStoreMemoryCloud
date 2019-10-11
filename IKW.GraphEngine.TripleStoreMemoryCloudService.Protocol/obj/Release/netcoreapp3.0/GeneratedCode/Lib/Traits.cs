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
            
            { typeof(byte), 0 }
            ,
            { typeof(bool), 1 }
            ,
            { typeof(decimal), 2 }
            ,
            { typeof(DateTime), 3 }
            ,
            { typeof(Guid), 4 }
            ,
            { typeof(string), 5 }
            ,
            { typeof(List<string>), 6 }
            ,
            { typeof(Node), 7 }
            ,
            { typeof(StringNode), 8 }
            ,
            { typeof(TripleStatement), 9 }
            ,
        };
        #endregion
        #region CellTypeID lookup table
        private static Dictionary<Type, uint> CellTypeIDLookupTable = new Dictionary<Type, uint>()
        {
            
            { typeof(RDFTriple), 0 }
            
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
        
        T ConvertFrom_byte(byte value);
        byte ConvertTo_byte(T value);
        TypeConversionAction GetConversionActionTo_byte();
        IEnumerable<byte> Enumerate_byte(T value);
        
        T ConvertFrom_bool(bool value);
        bool ConvertTo_bool(T value);
        TypeConversionAction GetConversionActionTo_bool();
        IEnumerable<bool> Enumerate_bool(T value);
        
        T ConvertFrom_decimal(decimal value);
        decimal ConvertTo_decimal(T value);
        TypeConversionAction GetConversionActionTo_decimal();
        IEnumerable<decimal> Enumerate_decimal(T value);
        
        T ConvertFrom_DateTime(DateTime value);
        DateTime ConvertTo_DateTime(T value);
        TypeConversionAction GetConversionActionTo_DateTime();
        IEnumerable<DateTime> Enumerate_DateTime(T value);
        
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
        
        T ConvertFrom_Node(Node value);
        Node ConvertTo_Node(T value);
        TypeConversionAction GetConversionActionTo_Node();
        IEnumerable<Node> Enumerate_Node(T value);
        
        T ConvertFrom_StringNode(StringNode value);
        StringNode ConvertTo_StringNode(T value);
        TypeConversionAction GetConversionActionTo_StringNode();
        IEnumerable<StringNode> Enumerate_StringNode(T value);
        
        T ConvertFrom_TripleStatement(TripleStatement value);
        TripleStatement ConvertTo_TripleStatement(T value);
        TypeConversionAction GetConversionActionTo_TripleStatement();
        IEnumerable<TripleStatement> Enumerate_TripleStatement(T value);
        
    }
    internal class TypeConverter<T> : ITypeConverter<T>
    {
        internal class _TypeConverterImpl : ITypeConverter<object>
            
            , ITypeConverter<byte>
        
            , ITypeConverter<bool>
        
            , ITypeConverter<decimal>
        
            , ITypeConverter<DateTime>
        
            , ITypeConverter<Guid>
        
            , ITypeConverter<string>
        
            , ITypeConverter<List<string>>
        
            , ITypeConverter<Node>
        
            , ITypeConverter<StringNode>
        
            , ITypeConverter<TripleStatement>
        
        {
            byte ITypeConverter<byte>.ConvertFrom_byte(byte value)
            {
                
                return (byte)value;
                
            }
            byte ITypeConverter<byte>.ConvertTo_byte(byte value)
            {
                return TypeConverter<byte>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<byte>.Enumerate_byte(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'byte'.");
                
            }
            bool ITypeConverter<byte>.ConvertTo_bool(byte value)
            {
                return TypeConverter<bool>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_TOBOOL;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<byte>.Enumerate_bool(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'byte'.");
                
            }
            decimal ITypeConverter<byte>.ConvertTo_decimal(byte value)
            {
                return TypeConverter<decimal>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<byte>.Enumerate_decimal(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'byte'.");
                
            }
            DateTime ITypeConverter<byte>.ConvertTo_DateTime(byte value)
            {
                return TypeConverter<DateTime>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<byte>.Enumerate_DateTime(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'byte'.");
                
            }
            Guid ITypeConverter<byte>.ConvertTo_Guid(byte value)
            {
                return TypeConverter<Guid>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<byte>.Enumerate_Guid(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    byte intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = byte.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "byte");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<byte>.ConvertTo_string(byte value)
            {
                return TypeConverter<string>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<byte>.Enumerate_string(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'byte'.");
                
            }
            List<string> ITypeConverter<byte>.ConvertTo_List_string(byte value)
            {
                return TypeConverter<List<string>>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<byte>.Enumerate_List_string(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'byte'.");
                
            }
            Node ITypeConverter<byte>.ConvertTo_Node(byte value)
            {
                return TypeConverter<Node>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<byte>.Enumerate_Node(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'byte'.");
                
            }
            StringNode ITypeConverter<byte>.ConvertTo_StringNode(byte value)
            {
                return TypeConverter<StringNode>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<byte>.Enumerate_StringNode(byte value)
            {
                
                yield break;
            }
            byte ITypeConverter<byte>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'byte'.");
                
            }
            TripleStatement ITypeConverter<byte>.ConvertTo_TripleStatement(byte value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_byte(value);
            }
            TypeConversionAction ITypeConverter<byte>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<byte>.Enumerate_TripleStatement(byte value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_byte(byte value)
            {
                
                return (value != 0);
                
            }
            byte ITypeConverter<bool>.ConvertTo_byte(bool value)
            {
                return TypeConverter<byte>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<bool>.Enumerate_byte(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_bool(bool value)
            {
                
                return (bool)value;
                
            }
            bool ITypeConverter<bool>.ConvertTo_bool(bool value)
            {
                return TypeConverter<bool>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<bool>.Enumerate_bool(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_decimal(decimal value)
            {
                
                return (value != 0);
                
            }
            decimal ITypeConverter<bool>.ConvertTo_decimal(bool value)
            {
                return TypeConverter<decimal>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<bool>.Enumerate_decimal(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'bool'.");
                
            }
            DateTime ITypeConverter<bool>.ConvertTo_DateTime(bool value)
            {
                return TypeConverter<DateTime>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<bool>.Enumerate_DateTime(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'bool'.");
                
            }
            Guid ITypeConverter<bool>.ConvertTo_Guid(bool value)
            {
                return TypeConverter<Guid>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<bool>.Enumerate_Guid(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    bool intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_bool(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "bool");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<bool>.ConvertTo_string(bool value)
            {
                return TypeConverter<string>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<bool>.Enumerate_string(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'bool'.");
                
            }
            List<string> ITypeConverter<bool>.ConvertTo_List_string(bool value)
            {
                return TypeConverter<List<string>>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<bool>.Enumerate_List_string(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'bool'.");
                
            }
            Node ITypeConverter<bool>.ConvertTo_Node(bool value)
            {
                return TypeConverter<Node>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<bool>.Enumerate_Node(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'bool'.");
                
            }
            StringNode ITypeConverter<bool>.ConvertTo_StringNode(bool value)
            {
                return TypeConverter<StringNode>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<bool>.Enumerate_StringNode(bool value)
            {
                
                yield break;
            }
            bool ITypeConverter<bool>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'bool'.");
                
            }
            TripleStatement ITypeConverter<bool>.ConvertTo_TripleStatement(bool value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_bool(value);
            }
            TypeConversionAction ITypeConverter<bool>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<bool>.Enumerate_TripleStatement(bool value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_byte(byte value)
            {
                
                return (decimal)value;
                
            }
            byte ITypeConverter<decimal>.ConvertTo_byte(decimal value)
            {
                return TypeConverter<byte>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<decimal>.Enumerate_byte(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'decimal'.");
                
            }
            bool ITypeConverter<decimal>.ConvertTo_bool(decimal value)
            {
                return TypeConverter<bool>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_TOBOOL;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<decimal>.Enumerate_bool(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_decimal(decimal value)
            {
                
                return (decimal)value;
                
            }
            decimal ITypeConverter<decimal>.ConvertTo_decimal(decimal value)
            {
                return TypeConverter<decimal>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<decimal>.Enumerate_decimal(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'decimal'.");
                
            }
            DateTime ITypeConverter<decimal>.ConvertTo_DateTime(decimal value)
            {
                return TypeConverter<DateTime>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<decimal>.Enumerate_DateTime(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'decimal'.");
                
            }
            Guid ITypeConverter<decimal>.ConvertTo_Guid(decimal value)
            {
                return TypeConverter<Guid>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<decimal>.Enumerate_Guid(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    decimal intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = decimal.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "decimal");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<decimal>.ConvertTo_string(decimal value)
            {
                return TypeConverter<string>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<decimal>.Enumerate_string(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'decimal'.");
                
            }
            List<string> ITypeConverter<decimal>.ConvertTo_List_string(decimal value)
            {
                return TypeConverter<List<string>>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<decimal>.Enumerate_List_string(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'decimal'.");
                
            }
            Node ITypeConverter<decimal>.ConvertTo_Node(decimal value)
            {
                return TypeConverter<Node>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<decimal>.Enumerate_Node(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'decimal'.");
                
            }
            StringNode ITypeConverter<decimal>.ConvertTo_StringNode(decimal value)
            {
                return TypeConverter<StringNode>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<decimal>.Enumerate_StringNode(decimal value)
            {
                
                yield break;
            }
            decimal ITypeConverter<decimal>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'decimal'.");
                
            }
            TripleStatement ITypeConverter<decimal>.ConvertTo_TripleStatement(decimal value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_decimal(value);
            }
            TypeConversionAction ITypeConverter<decimal>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<decimal>.Enumerate_TripleStatement(decimal value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_byte(byte value)
            {
                
                throw new InvalidCastException("Invalid cast from 'byte' to 'DateTime'.");
                
            }
            byte ITypeConverter<DateTime>.ConvertTo_byte(DateTime value)
            {
                return TypeConverter<byte>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<DateTime>.Enumerate_byte(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'DateTime'.");
                
            }
            bool ITypeConverter<DateTime>.ConvertTo_bool(DateTime value)
            {
                return TypeConverter<bool>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<DateTime>.Enumerate_bool(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'DateTime'.");
                
            }
            decimal ITypeConverter<DateTime>.ConvertTo_decimal(DateTime value)
            {
                return TypeConverter<decimal>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<DateTime>.Enumerate_decimal(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_DateTime(DateTime value)
            {
                
                return (DateTime)value;
                
            }
            DateTime ITypeConverter<DateTime>.ConvertTo_DateTime(DateTime value)
            {
                return TypeConverter<DateTime>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<DateTime>.Enumerate_DateTime(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'DateTime'.");
                
            }
            Guid ITypeConverter<DateTime>.ConvertTo_Guid(DateTime value)
            {
                return TypeConverter<Guid>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<DateTime>.Enumerate_Guid(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    DateTime intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = ExternalParser.TryParse_DateTime(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "DateTime");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<DateTime>.ConvertTo_string(DateTime value)
            {
                return TypeConverter<string>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<DateTime>.Enumerate_string(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'DateTime'.");
                
            }
            List<string> ITypeConverter<DateTime>.ConvertTo_List_string(DateTime value)
            {
                return TypeConverter<List<string>>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<DateTime>.Enumerate_List_string(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'DateTime'.");
                
            }
            Node ITypeConverter<DateTime>.ConvertTo_Node(DateTime value)
            {
                return TypeConverter<Node>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<DateTime>.Enumerate_Node(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'DateTime'.");
                
            }
            StringNode ITypeConverter<DateTime>.ConvertTo_StringNode(DateTime value)
            {
                return TypeConverter<StringNode>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<DateTime>.Enumerate_StringNode(DateTime value)
            {
                
                yield break;
            }
            DateTime ITypeConverter<DateTime>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'DateTime'.");
                
            }
            TripleStatement ITypeConverter<DateTime>.ConvertTo_TripleStatement(DateTime value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_DateTime(value);
            }
            TypeConversionAction ITypeConverter<DateTime>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<DateTime>.Enumerate_TripleStatement(DateTime value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_byte(byte value)
            {
                
                throw new InvalidCastException("Invalid cast from 'byte' to 'Guid'.");
                
            }
            byte ITypeConverter<Guid>.ConvertTo_byte(Guid value)
            {
                return TypeConverter<byte>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<Guid>.Enumerate_byte(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'Guid'.");
                
            }
            bool ITypeConverter<Guid>.ConvertTo_bool(Guid value)
            {
                return TypeConverter<bool>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<Guid>.Enumerate_bool(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'Guid'.");
                
            }
            decimal ITypeConverter<Guid>.ConvertTo_decimal(Guid value)
            {
                return TypeConverter<decimal>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<Guid>.Enumerate_decimal(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'Guid'.");
                
            }
            DateTime ITypeConverter<Guid>.ConvertTo_DateTime(Guid value)
            {
                return TypeConverter<DateTime>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<Guid>.Enumerate_DateTime(Guid value)
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
            Guid ITypeConverter<Guid>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'Guid'.");
                
            }
            Node ITypeConverter<Guid>.ConvertTo_Node(Guid value)
            {
                return TypeConverter<Node>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<Guid>.Enumerate_Node(Guid value)
            {
                
                yield break;
            }
            Guid ITypeConverter<Guid>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'Guid'.");
                
            }
            StringNode ITypeConverter<Guid>.ConvertTo_StringNode(Guid value)
            {
                return TypeConverter<StringNode>.ConvertFrom_Guid(value);
            }
            TypeConversionAction ITypeConverter<Guid>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<Guid>.Enumerate_StringNode(Guid value)
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
            string ITypeConverter<string>.ConvertFrom_byte(byte value)
            {
                
                return Serializer.ToString(value);
                
            }
            byte ITypeConverter<string>.ConvertTo_byte(string value)
            {
                return TypeConverter<byte>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<string>.Enumerate_byte(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_bool(bool value)
            {
                
                return Serializer.ToString(value);
                
            }
            bool ITypeConverter<string>.ConvertTo_bool(string value)
            {
                return TypeConverter<bool>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<string>.Enumerate_bool(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_decimal(decimal value)
            {
                
                return Serializer.ToString(value);
                
            }
            decimal ITypeConverter<string>.ConvertTo_decimal(string value)
            {
                return TypeConverter<decimal>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<string>.Enumerate_decimal(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_DateTime(DateTime value)
            {
                
                return Serializer.ToString(value);
                
            }
            DateTime ITypeConverter<string>.ConvertTo_DateTime(string value)
            {
                return TypeConverter<DateTime>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<string>.Enumerate_DateTime(string value)
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
            string ITypeConverter<string>.ConvertFrom_Node(Node value)
            {
                
                return Serializer.ToString(value);
                
            }
            Node ITypeConverter<string>.ConvertTo_Node(string value)
            {
                return TypeConverter<Node>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<string>.Enumerate_Node(string value)
            {
                
                yield break;
            }
            string ITypeConverter<string>.ConvertFrom_StringNode(StringNode value)
            {
                
                return Serializer.ToString(value);
                
            }
            StringNode ITypeConverter<string>.ConvertTo_StringNode(string value)
            {
                return TypeConverter<StringNode>.ConvertFrom_string(value);
            }
            TypeConversionAction ITypeConverter<string>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_PARSESTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<string>.Enumerate_StringNode(string value)
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_byte(byte value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_byte(value));
                    return intermediate_result;
                }
                
            }
            byte ITypeConverter<List<string>>.ConvertTo_byte(List<string> value)
            {
                return TypeConverter<byte>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<List<string>>.Enumerate_byte(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<byte>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_bool(bool value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_bool(value));
                    return intermediate_result;
                }
                
            }
            bool ITypeConverter<List<string>>.ConvertTo_bool(List<string> value)
            {
                return TypeConverter<bool>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<List<string>>.Enumerate_bool(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<bool>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_decimal(decimal value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_decimal(value));
                    return intermediate_result;
                }
                
            }
            decimal ITypeConverter<List<string>>.ConvertTo_decimal(List<string> value)
            {
                return TypeConverter<decimal>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<List<string>>.Enumerate_decimal(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<decimal>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_DateTime(DateTime value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_DateTime(value));
                    return intermediate_result;
                }
                
            }
            DateTime ITypeConverter<List<string>>.ConvertTo_DateTime(List<string> value)
            {
                return TypeConverter<DateTime>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<List<string>>.Enumerate_DateTime(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<DateTime>.ConvertFrom_string(element);
                
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
            List<string> ITypeConverter<List<string>>.ConvertFrom_Node(Node value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_Node(value));
                    return intermediate_result;
                }
                
            }
            Node ITypeConverter<List<string>>.ConvertTo_Node(List<string> value)
            {
                return TypeConverter<Node>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<List<string>>.Enumerate_Node(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<Node>.ConvertFrom_string(element);
                
                yield break;
            }
            List<string> ITypeConverter<List<string>>.ConvertFrom_StringNode(StringNode value)
            {
                
                {
                    List<string> intermediate_result = new List<string>();
                    intermediate_result.Add(TypeConverter<string>.ConvertFrom_StringNode(value));
                    return intermediate_result;
                }
                
            }
            StringNode ITypeConverter<List<string>>.ConvertTo_StringNode(List<string> value)
            {
                return TypeConverter<StringNode>.ConvertFrom_List_string(value);
            }
            TypeConversionAction ITypeConverter<List<string>>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<List<string>>.Enumerate_StringNode(List<string> value)
            {
                
                foreach (var element in value)
                    yield return TypeConverter<StringNode>.ConvertFrom_string(element);
                
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
            Node ITypeConverter<Node>.ConvertFrom_byte(byte value)
            {
                
                throw new InvalidCastException("Invalid cast from 'byte' to 'Node'.");
                
            }
            byte ITypeConverter<Node>.ConvertTo_byte(Node value)
            {
                return TypeConverter<byte>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<Node>.Enumerate_byte(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'Node'.");
                
            }
            bool ITypeConverter<Node>.ConvertTo_bool(Node value)
            {
                return TypeConverter<bool>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<Node>.Enumerate_bool(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'Node'.");
                
            }
            decimal ITypeConverter<Node>.ConvertTo_decimal(Node value)
            {
                return TypeConverter<decimal>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<Node>.Enumerate_decimal(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'Node'.");
                
            }
            DateTime ITypeConverter<Node>.ConvertTo_DateTime(Node value)
            {
                return TypeConverter<DateTime>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<Node>.Enumerate_DateTime(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'Node'.");
                
            }
            Guid ITypeConverter<Node>.ConvertTo_Guid(Node value)
            {
                return TypeConverter<Guid>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<Node>.Enumerate_Guid(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    Node intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = Node.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "Node");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<Node>.ConvertTo_string(Node value)
            {
                return TypeConverter<string>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<Node>.Enumerate_string(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'Node'.");
                
            }
            List<string> ITypeConverter<Node>.ConvertTo_List_string(Node value)
            {
                return TypeConverter<List<string>>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<Node>.Enumerate_List_string(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_Node(Node value)
            {
                
                return (Node)value;
                
            }
            Node ITypeConverter<Node>.ConvertTo_Node(Node value)
            {
                return TypeConverter<Node>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<Node>.Enumerate_Node(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'Node'.");
                
            }
            StringNode ITypeConverter<Node>.ConvertTo_StringNode(Node value)
            {
                return TypeConverter<StringNode>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<Node>.Enumerate_StringNode(Node value)
            {
                
                yield break;
            }
            Node ITypeConverter<Node>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'Node'.");
                
            }
            TripleStatement ITypeConverter<Node>.ConvertTo_TripleStatement(Node value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_Node(value);
            }
            TypeConversionAction ITypeConverter<Node>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<Node>.Enumerate_TripleStatement(Node value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_byte(byte value)
            {
                
                throw new InvalidCastException("Invalid cast from 'byte' to 'StringNode'.");
                
            }
            byte ITypeConverter<StringNode>.ConvertTo_byte(StringNode value)
            {
                return TypeConverter<byte>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<StringNode>.Enumerate_byte(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'StringNode'.");
                
            }
            bool ITypeConverter<StringNode>.ConvertTo_bool(StringNode value)
            {
                return TypeConverter<bool>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<StringNode>.Enumerate_bool(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'StringNode'.");
                
            }
            decimal ITypeConverter<StringNode>.ConvertTo_decimal(StringNode value)
            {
                return TypeConverter<decimal>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<StringNode>.Enumerate_decimal(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'StringNode'.");
                
            }
            DateTime ITypeConverter<StringNode>.ConvertTo_DateTime(StringNode value)
            {
                return TypeConverter<DateTime>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<StringNode>.Enumerate_DateTime(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_Guid(Guid value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Guid' to 'StringNode'.");
                
            }
            Guid ITypeConverter<StringNode>.ConvertTo_Guid(StringNode value)
            {
                return TypeConverter<Guid>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_Guid()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Guid> ITypeConverter<StringNode>.Enumerate_Guid(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_string(string value)
            {
                
                {
                    #region String parse
                    StringNode intermediate_result;
                    bool conversion_success;
                    
                    {
                        conversion_success = StringNode.TryParse(value, out intermediate_result);
                    }
                    
                    if (!conversion_success)
                    {
                        
                        Throw.cannot_parse(value, "StringNode");
                        
                    }
                    return intermediate_result;
                    #endregion
                }
                
            }
            string ITypeConverter<StringNode>.ConvertTo_string(StringNode value)
            {
                return TypeConverter<string>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_string()
            {
                
                return TypeConversionAction.TC_TOSTRING;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<string> ITypeConverter<StringNode>.Enumerate_string(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_List_string(List<string> value)
            {
                
                throw new InvalidCastException("Invalid cast from 'List<string>' to 'StringNode'.");
                
            }
            List<string> ITypeConverter<StringNode>.ConvertTo_List_string(StringNode value)
            {
                return TypeConverter<List<string>>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_List_string()
            {
                
                return TypeConversionAction.TC_WRAPINLIST;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<List<string>> ITypeConverter<StringNode>.Enumerate_List_string(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'StringNode'.");
                
            }
            Node ITypeConverter<StringNode>.ConvertTo_Node(StringNode value)
            {
                return TypeConverter<Node>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<StringNode>.Enumerate_Node(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_StringNode(StringNode value)
            {
                
                return (StringNode)value;
                
            }
            StringNode ITypeConverter<StringNode>.ConvertTo_StringNode(StringNode value)
            {
                return TypeConverter<StringNode>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_ASSIGN;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<StringNode>.Enumerate_StringNode(StringNode value)
            {
                
                yield break;
            }
            StringNode ITypeConverter<StringNode>.ConvertFrom_TripleStatement(TripleStatement value)
            {
                
                throw new InvalidCastException("Invalid cast from 'TripleStatement' to 'StringNode'.");
                
            }
            TripleStatement ITypeConverter<StringNode>.ConvertTo_TripleStatement(StringNode value)
            {
                return TypeConverter<TripleStatement>.ConvertFrom_StringNode(value);
            }
            TypeConversionAction ITypeConverter<StringNode>.GetConversionActionTo_TripleStatement()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<TripleStatement> ITypeConverter<StringNode>.Enumerate_TripleStatement(StringNode value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_byte(byte value)
            {
                
                throw new InvalidCastException("Invalid cast from 'byte' to 'TripleStatement'.");
                
            }
            byte ITypeConverter<TripleStatement>.ConvertTo_byte(TripleStatement value)
            {
                return TypeConverter<byte>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_byte()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<byte> ITypeConverter<TripleStatement>.Enumerate_byte(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_bool(bool value)
            {
                
                throw new InvalidCastException("Invalid cast from 'bool' to 'TripleStatement'.");
                
            }
            bool ITypeConverter<TripleStatement>.ConvertTo_bool(TripleStatement value)
            {
                return TypeConverter<bool>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_bool()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<bool> ITypeConverter<TripleStatement>.Enumerate_bool(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_decimal(decimal value)
            {
                
                throw new InvalidCastException("Invalid cast from 'decimal' to 'TripleStatement'.");
                
            }
            decimal ITypeConverter<TripleStatement>.ConvertTo_decimal(TripleStatement value)
            {
                return TypeConverter<decimal>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_decimal()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<decimal> ITypeConverter<TripleStatement>.Enumerate_decimal(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_DateTime(DateTime value)
            {
                
                throw new InvalidCastException("Invalid cast from 'DateTime' to 'TripleStatement'.");
                
            }
            DateTime ITypeConverter<TripleStatement>.ConvertTo_DateTime(TripleStatement value)
            {
                return TypeConverter<DateTime>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_DateTime()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<DateTime> ITypeConverter<TripleStatement>.Enumerate_DateTime(TripleStatement value)
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
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_Node(Node value)
            {
                
                throw new InvalidCastException("Invalid cast from 'Node' to 'TripleStatement'.");
                
            }
            Node ITypeConverter<TripleStatement>.ConvertTo_Node(TripleStatement value)
            {
                return TypeConverter<Node>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_Node()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<Node> ITypeConverter<TripleStatement>.Enumerate_Node(TripleStatement value)
            {
                
                yield break;
            }
            TripleStatement ITypeConverter<TripleStatement>.ConvertFrom_StringNode(StringNode value)
            {
                
                throw new InvalidCastException("Invalid cast from 'StringNode' to 'TripleStatement'.");
                
            }
            StringNode ITypeConverter<TripleStatement>.ConvertTo_StringNode(TripleStatement value)
            {
                return TypeConverter<StringNode>.ConvertFrom_TripleStatement(value);
            }
            TypeConversionAction ITypeConverter<TripleStatement>.GetConversionActionTo_StringNode()
            {
                
                return TypeConversionAction.TC_NONCONVERTIBLE;
                
            }
            /// <summary>
            /// ONLY VALID FOR TC_CONVERTLIST AND TC_ARRAYTOLIST.
            /// </summary>
            IEnumerable<StringNode> ITypeConverter<TripleStatement>.Enumerate_StringNode(TripleStatement value)
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
            
            object ITypeConverter<object>.ConvertFrom_byte(byte value)
            {
                return value;
            }
            byte ITypeConverter<object>.ConvertTo_byte(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_byte()
            {
                throw new NotImplementedException();
            }
            IEnumerable<byte> ITypeConverter<object>.Enumerate_byte(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_bool(bool value)
            {
                return value;
            }
            bool ITypeConverter<object>.ConvertTo_bool(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_bool()
            {
                throw new NotImplementedException();
            }
            IEnumerable<bool> ITypeConverter<object>.Enumerate_bool(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_decimal(decimal value)
            {
                return value;
            }
            decimal ITypeConverter<object>.ConvertTo_decimal(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_decimal()
            {
                throw new NotImplementedException();
            }
            IEnumerable<decimal> ITypeConverter<object>.Enumerate_decimal(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_DateTime(DateTime value)
            {
                return value;
            }
            DateTime ITypeConverter<object>.ConvertTo_DateTime(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_DateTime()
            {
                throw new NotImplementedException();
            }
            IEnumerable<DateTime> ITypeConverter<object>.Enumerate_DateTime(object value)
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
            
            object ITypeConverter<object>.ConvertFrom_Node(Node value)
            {
                return value;
            }
            Node ITypeConverter<object>.ConvertTo_Node(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_Node()
            {
                throw new NotImplementedException();
            }
            IEnumerable<Node> ITypeConverter<object>.Enumerate_Node(object value)
            {
                throw new NotImplementedException();
            }
            
            object ITypeConverter<object>.ConvertFrom_StringNode(StringNode value)
            {
                return value;
            }
            StringNode ITypeConverter<object>.ConvertTo_StringNode(object value)
            {
                throw new NotImplementedException();
            }
            TypeConversionAction ITypeConverter<object>.GetConversionActionTo_StringNode()
            {
                throw new NotImplementedException();
            }
            IEnumerable<StringNode> ITypeConverter<object>.Enumerate_StringNode(object value)
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
            
        }
        internal static readonly ITypeConverter<T> s_type_converter = new _TypeConverterImpl() as ITypeConverter<T> ?? new TypeConverter<T>();
        #region Default implementation
        
        T ITypeConverter<T>.ConvertFrom_byte(byte value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        byte ITypeConverter<T>.ConvertTo_byte(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_byte()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<byte> ITypeConverter<T>.Enumerate_byte(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_bool(bool value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        bool ITypeConverter<T>.ConvertTo_bool(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_bool()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<bool> ITypeConverter<T>.Enumerate_bool(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_decimal(decimal value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        decimal ITypeConverter<T>.ConvertTo_decimal(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_decimal()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<decimal> ITypeConverter<T>.Enumerate_decimal(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_DateTime(DateTime value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        DateTime ITypeConverter<T>.ConvertTo_DateTime(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_DateTime()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<DateTime> ITypeConverter<T>.Enumerate_DateTime(T value)
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
        
        T ITypeConverter<T>.ConvertFrom_Node(Node value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        Node ITypeConverter<T>.ConvertTo_Node(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_Node()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<Node> ITypeConverter<T>.Enumerate_Node(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        
        T ITypeConverter<T>.ConvertFrom_StringNode(StringNode value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        StringNode ITypeConverter<T>.ConvertTo_StringNode(T value)
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        TypeConversionAction ITypeConverter<T>.GetConversionActionTo_StringNode()
        {
            throw new NotImplementedException("Internal error T5013.");
        }
        IEnumerable<StringNode> ITypeConverter<T>.Enumerate_StringNode(T value)
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
        
        #endregion
        internal static readonly uint type_id = TypeSystem.GetTypeID(typeof(T));
        
        internal static T ConvertFrom_byte(byte value)
        {
            return s_type_converter.ConvertFrom_byte(value);
        }
        internal static byte ConvertTo_byte(T value)
        {
            return s_type_converter.ConvertTo_byte(value);
        }
        internal static TypeConversionAction GetConversionActionTo_byte()
        {
            return s_type_converter.GetConversionActionTo_byte();
        }
        internal static IEnumerable<byte> Enumerate_byte(T value)
        {
            return s_type_converter.Enumerate_byte(value);
        }
        
        internal static T ConvertFrom_bool(bool value)
        {
            return s_type_converter.ConvertFrom_bool(value);
        }
        internal static bool ConvertTo_bool(T value)
        {
            return s_type_converter.ConvertTo_bool(value);
        }
        internal static TypeConversionAction GetConversionActionTo_bool()
        {
            return s_type_converter.GetConversionActionTo_bool();
        }
        internal static IEnumerable<bool> Enumerate_bool(T value)
        {
            return s_type_converter.Enumerate_bool(value);
        }
        
        internal static T ConvertFrom_decimal(decimal value)
        {
            return s_type_converter.ConvertFrom_decimal(value);
        }
        internal static decimal ConvertTo_decimal(T value)
        {
            return s_type_converter.ConvertTo_decimal(value);
        }
        internal static TypeConversionAction GetConversionActionTo_decimal()
        {
            return s_type_converter.GetConversionActionTo_decimal();
        }
        internal static IEnumerable<decimal> Enumerate_decimal(T value)
        {
            return s_type_converter.Enumerate_decimal(value);
        }
        
        internal static T ConvertFrom_DateTime(DateTime value)
        {
            return s_type_converter.ConvertFrom_DateTime(value);
        }
        internal static DateTime ConvertTo_DateTime(T value)
        {
            return s_type_converter.ConvertTo_DateTime(value);
        }
        internal static TypeConversionAction GetConversionActionTo_DateTime()
        {
            return s_type_converter.GetConversionActionTo_DateTime();
        }
        internal static IEnumerable<DateTime> Enumerate_DateTime(T value)
        {
            return s_type_converter.Enumerate_DateTime(value);
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
        
        internal static T ConvertFrom_Node(Node value)
        {
            return s_type_converter.ConvertFrom_Node(value);
        }
        internal static Node ConvertTo_Node(T value)
        {
            return s_type_converter.ConvertTo_Node(value);
        }
        internal static TypeConversionAction GetConversionActionTo_Node()
        {
            return s_type_converter.GetConversionActionTo_Node();
        }
        internal static IEnumerable<Node> Enumerate_Node(T value)
        {
            return s_type_converter.Enumerate_Node(value);
        }
        
        internal static T ConvertFrom_StringNode(StringNode value)
        {
            return s_type_converter.ConvertFrom_StringNode(value);
        }
        internal static StringNode ConvertTo_StringNode(T value)
        {
            return s_type_converter.ConvertTo_StringNode(value);
        }
        internal static TypeConversionAction GetConversionActionTo_StringNode()
        {
            return s_type_converter.GetConversionActionTo_StringNode();
        }
        internal static IEnumerable<StringNode> Enumerate_StringNode(T value)
        {
            return s_type_converter.Enumerate_StringNode(value);
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
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
