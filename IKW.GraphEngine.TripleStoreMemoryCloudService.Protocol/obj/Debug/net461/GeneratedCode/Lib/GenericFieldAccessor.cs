#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    internal struct GenericFieldAccessor
    {
        #region FieldID lookup table
        
        static Dictionary<string, uint> FieldLookupTable_INode = new Dictionary<string, uint>()
        {
            
            {"TypeOfNode" , 0}
            ,
            {"GraphParent" , 1}
            ,
            {"GraphUri" , 2}
            ,
            {"HashCode" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_Triple = new Dictionary<string, uint>()
        {
            
            {"SubjectNode" , 0}
            ,
            {"PredicateNode" , 1}
            ,
            {"ObjectNode" , 2}
            ,
            {"Url" , 3}
            ,
            {"GraphInstance" , 4}
            ,
            {"HashCode" , 5}
            ,
            {"Nodes" , 6}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_TripleStatement = new Dictionary<string, uint>()
        {
            
            {"RefId" , 0}
            ,
            {"Subject" , 1}
            ,
            {"Predicate" , 2}
            ,
            {"Object" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_StoreTripleRequest = new Dictionary<string, uint>()
        {
            
            {"RefId" , 0}
            ,
            {"Subject" , 1}
            ,
            {"Predicate" , 2}
            ,
            {"Object" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_StoreTripleResponse = new Dictionary<string, uint>()
        {
            
            {"RefId" , 0}
            ,
            {"Subject" , 1}
            ,
            {"Predicate" , 2}
            ,
            {"Object" , 3}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_HelloNessageRequest = new Dictionary<string, uint>()
        {
            
            {"HelloMessageContent" , 0}
            
        };
        
        static Dictionary<string, uint> FieldLookupTable_HelloMessageReponse = new Dictionary<string, uint>()
        {
            
            {"HelloMessageContent" , 0}
            
        };
        
        #endregion
        
        internal static void SetField<T>(INode_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_INode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_INode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        NodeType conversion_result = TypeConverter<T>.ConvertTo_NodeType(value);
                        
            {
                accessor.TypeOfNode = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.GraphParent = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.GraphUri = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.HashCode = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(INode_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_INode.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_INode.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_NodeType(accessor.TypeOfNode);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_long(accessor.GraphParent);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.GraphUri);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_long(accessor.HashCode);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(Triple_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Triple.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        GenericFieldAccessor.SetField(accessor.SubjectNode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 1:
                        GenericFieldAccessor.SetField(accessor.PredicateNode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    case 2:
                        GenericFieldAccessor.SetField(accessor.ObjectNode, fieldName, field_divider_idx + 1, value);
                        break;
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Triple.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        INode conversion_result = TypeConverter<T>.ConvertTo_INode(value);
                        
            {
                accessor.SubjectNode = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        INode conversion_result = TypeConverter<T>.ConvertTo_INode(value);
                        
            {
                accessor.PredicateNode = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        INode conversion_result = TypeConverter<T>.ConvertTo_INode(value);
                        
            {
                accessor.ObjectNode = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Url = conversion_result;
            }
            
                        break;
                    }
                
                case 4:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.GraphInstance = conversion_result;
            }
            
                        break;
                    }
                
                case 5:
                    {
                        long conversion_result = TypeConverter<T>.ConvertTo_long(value);
                        
            {
                accessor.HashCode = conversion_result;
            }
            
                        break;
                    }
                
                case 6:
                    {
                        List<INode> conversion_result = TypeConverter<T>.ConvertTo_List_INode(value);
                        
            {
                accessor.Nodes = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(Triple_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_Triple.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    case 0:
                        return GenericFieldAccessor.GetField<T>(accessor.SubjectNode, fieldName, field_divider_idx + 1);
                    
                    case 1:
                        return GenericFieldAccessor.GetField<T>(accessor.PredicateNode, fieldName, field_divider_idx + 1);
                    
                    case 2:
                        return GenericFieldAccessor.GetField<T>(accessor.ObjectNode, fieldName, field_divider_idx + 1);
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_Triple.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_INode(accessor.SubjectNode);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_INode(accessor.PredicateNode);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_INode(accessor.ObjectNode);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Url);
                    break;
                
                case 4:
                    return TypeConverter<T>.ConvertFrom_long(accessor.GraphInstance);
                    break;
                
                case 5:
                    return TypeConverter<T>.ConvertFrom_long(accessor.HashCode);
                    break;
                
                case 6:
                    return TypeConverter<T>.ConvertFrom_List_INode(accessor.Nodes);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(TripleStatement_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TripleStatement.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TripleStatement.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Guid conversion_result = TypeConverter<T>.ConvertTo_Guid(value);
                        
            {
                accessor.RefId = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Subject = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Predicate = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Object = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(TripleStatement_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_TripleStatement.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_TripleStatement.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Guid(accessor.RefId);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Subject);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Predicate);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Object);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(StoreTripleRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_StoreTripleRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_StoreTripleRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Guid conversion_result = TypeConverter<T>.ConvertTo_Guid(value);
                        
            {
                accessor.RefId = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Subject = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Predicate = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Object = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(StoreTripleRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_StoreTripleRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_StoreTripleRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Guid(accessor.RefId);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Subject);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Predicate);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Object);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(StoreTripleResponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_StoreTripleResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_StoreTripleResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        Guid conversion_result = TypeConverter<T>.ConvertTo_Guid(value);
                        
            {
                accessor.RefId = conversion_result;
            }
            
                        break;
                    }
                
                case 1:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Subject = conversion_result;
            }
            
                        break;
                    }
                
                case 2:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Predicate = conversion_result;
            }
            
                        break;
                    }
                
                case 3:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.Object = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(StoreTripleResponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_StoreTripleResponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_StoreTripleResponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_Guid(accessor.RefId);
                    break;
                
                case 1:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Subject);
                    break;
                
                case 2:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Predicate);
                    break;
                
                case 3:
                    return TypeConverter<T>.ConvertFrom_string(accessor.Object);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(HelloNessageRequest_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_HelloNessageRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_HelloNessageRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.HelloMessageContent = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(HelloNessageRequest_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_HelloNessageRequest.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_HelloNessageRequest.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.HelloMessageContent);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
        internal static void SetField<T>(HelloMessageReponse_Accessor accessor, string fieldName, int field_name_idx, T value)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_HelloMessageReponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
                return;
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_HelloMessageReponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    {
                        string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                        
            {
                accessor.HelloMessageContent = conversion_result;
            }
            
                        break;
                    }
                
            }
        }
        internal static T GetField<T>(HelloMessageReponse_Accessor accessor, string fieldName, int field_name_idx)
        {
            uint member_id;
            int field_divider_idx = fieldName.IndexOf('.', field_name_idx);
            if (-1 != field_divider_idx)
            {
                string member_name_string = fieldName.Substring(field_name_idx, field_divider_idx - field_name_idx);
                if (!FieldLookupTable_HelloMessageReponse.TryGetValue(member_name_string, out member_id))
                    Throw.undefined_field();
                switch (member_id)
                {
                    
                    default:
                        Throw.member_access_on_non_struct__field(member_name_string);
                        break;
                }
            }
            fieldName = fieldName.Substring(field_name_idx);
            if (!FieldLookupTable_HelloMessageReponse.TryGetValue(fieldName, out member_id))
                Throw.undefined_field();
            switch (member_id)
            {
                
                case 0:
                    return TypeConverter<T>.ConvertFrom_string(accessor.HelloMessageContent);
                    break;
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5008");
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
