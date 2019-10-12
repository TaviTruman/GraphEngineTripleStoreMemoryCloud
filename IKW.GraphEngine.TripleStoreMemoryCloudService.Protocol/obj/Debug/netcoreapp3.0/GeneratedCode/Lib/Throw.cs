#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.Storage;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    class Throw
    {
        
        internal static void parse_long(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into long.");
        }
        internal static void incompatible_with_long()
        {
            throw new DataTypeIncompatibleException("Data type 'long' not compatible with the target field.");
        }
        
        internal static void parse_Guid(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Guid.");
        }
        internal static void incompatible_with_Guid()
        {
            throw new DataTypeIncompatibleException("Data type 'Guid' not compatible with the target field.");
        }
        
        internal static void parse_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into string.");
        }
        internal static void incompatible_with_string()
        {
            throw new DataTypeIncompatibleException("Data type 'string' not compatible with the target field.");
        }
        
        internal static void parse_List_string(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<string>.");
        }
        internal static void incompatible_with_List_string()
        {
            throw new DataTypeIncompatibleException("Data type 'List<string>' not compatible with the target field.");
        }
        
        internal static void parse_List_INode(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<INode>.");
        }
        internal static void incompatible_with_List_INode()
        {
            throw new DataTypeIncompatibleException("Data type 'List<INode>' not compatible with the target field.");
        }
        
        internal static void parse_List_Triple(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into List<Triple>.");
        }
        internal static void incompatible_with_List_Triple()
        {
            throw new DataTypeIncompatibleException("Data type 'List<Triple>' not compatible with the target field.");
        }
        
        internal static void parse_INode(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into INode.");
        }
        internal static void incompatible_with_INode()
        {
            throw new DataTypeIncompatibleException("Data type 'INode' not compatible with the target field.");
        }
        
        internal static void parse_Triple(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into Triple.");
        }
        internal static void incompatible_with_Triple()
        {
            throw new DataTypeIncompatibleException("Data type 'Triple' not compatible with the target field.");
        }
        
        internal static void parse_TripleStatement(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into TripleStatement.");
        }
        internal static void incompatible_with_TripleStatement()
        {
            throw new DataTypeIncompatibleException("Data type 'TripleStatement' not compatible with the target field.");
        }
        
        internal static void parse_NodeType(string value)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into NodeType.");
        }
        internal static void incompatible_with_NodeType()
        {
            throw new DataTypeIncompatibleException("Data type 'NodeType' not compatible with the target field.");
        }
        
        internal static void data_type_incompatible_with_list(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target list.");
        }
        internal static void data_type_incompatible_with_field(string type)
        {
            throw new DataTypeIncompatibleException("Data type '" + type + "' not compatible with the target field.");
        }
        internal static void target__field_not_list()
        {
            throw new DataTypeIncompatibleException("Target field is not a List, value or a string, cannot perform append operation.");
        }
        internal static void list_incompatible_list(string type)
        {
            throw new DataTypeIncompatibleException("List type '" + type + "' not compatible with the target list.");
        }
        internal static void incompatible_with_cell()
        {
            throw new DataTypeIncompatibleException("Data type incompatible with the cell.");
        }
        internal static void array_dimension_size_mismatch(string type)
        {
            throw new ArgumentException(type + ": Array dimension size mismatch.");
        }
        internal static void invalid_cell_type()
        {
            throw new ArgumentException("Invalid cell type name. If you want a new cell type, please define it in your TSL.");
        }
        internal static void undefined_field()
        {
            throw new ArgumentException("Undefined field.");
        }
        
        internal static void member_access_on_non_struct__field(string field_name_string)
        {
            throw new DataTypeIncompatibleException("Cannot apply member access method on a non-struct field'" + field_name_string + "'.");
        }
        internal static void cell_not_found()
        {
            throw new CellNotFoundException("The cell is not found.");
        }
        internal static void cell_not_found(long cellId)
        {
            throw new CellNotFoundException("The cell with id = " + cellId + " not found.");
        }
        internal static void wrong_cell_type()
        {
            throw new CellTypeNotMatchException("Cell type mismatched.");
        }
        internal static unsafe void cannot_parse(string value, string type_str)
        {
            throw new ArgumentException("Cannot parse \""+value+"\" into " + type_str + ".");
        }
        internal static unsafe byte* invalid_resize_on_fixed_struct()
        {
            throw new InvalidOperationException("Invalid resize operation on a fixed struct.");
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
