#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Security;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Runtime.CompilerServices;
using Trinity.Storage.Transaction;
using Microsoft.Extensions.ObjectPool;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    /// <summary>
    /// A .NET runtime object representation of RDFTriple defined in TSL.
    /// </summary>
    public partial struct RDFTriple : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of RDFTriple with the specified parameters.
        ///</summary>
        public RDFTriple(long cell_id , Guid RefId = default(Guid), Node Subject = default(Node), Node Predicate = default(Node), Node Object = default(Node))
        {
            
            this.RefId = RefId;
            
            this.Subject = Subject;
            
            this.Predicate = Predicate;
            
            this.Object = Object;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of RDFTriple with the specified parameters.
        ///</summary>
        public RDFTriple( Guid RefId = default(Guid), Node Subject = default(Node), Node Predicate = default(Node), Node Object = default(Node))
        {
            
            this.RefId = RefId;
            
            this.Subject = Subject;
            
            this.Predicate = Predicate;
            
            this.Object = Object;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public Guid RefId;
        
        public Node Subject;
        
        public Node Predicate;
        
        public Node Object;
        
        public static bool operator ==(RDFTriple a, RDFTriple b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            
            return
                
                (a.RefId == b.RefId)
                &&
                (a.Subject == b.Subject)
                &&
                (a.Predicate == b.Predicate)
                &&
                (a.Object == b.Object)
                
                ;
            
        }
        public static bool operator !=(RDFTriple a, RDFTriple b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a RDFTriple to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(RDFTriple) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out RDFTriple value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<RDFTriple>(input);
                return true;
            }
            catch { value = default(RDFTriple); return false; }
        }
        public static RDFTriple Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RDFTriple>(input);
        }
        ///<summary>Converts a RDFTriple to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the RDFTriple.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "RefId"
            ,
            "Subject"
            ,
            "Predicate"
            ,
            "Object"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "RefId"
            ,
            "Subject"
            ,
            "Predicate"
            ,
            "Object"
            ,
        };
        #endregion
        #region ICell implementation
        /// <summary>
        /// Get the field of the specified name in the cell.
        /// </summary>
        /// <typeparam name="T">
        /// The desired type that the field is supposed 
        /// to be interpreted as. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <returns>The value of the field.</returns>
        public T GetField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                
                case 3:
                return TypeConverter<T>.ConvertFrom_Node(this.Object);
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        /// <summary>
        /// Set the value of the target field.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">
        /// The value of the field. Automatic type casting 
        /// will be attempted if the desired type is not 
        /// implicitly convertible from the type of the field.
        /// </param>
        public void SetField<T>(string fieldName, T value)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                this.RefId = TypeConverter<T>.ConvertTo_Guid(value);
                break;
                
                case 1:
                this.Subject = TypeConverter<T>.ConvertTo_Node(value);
                break;
                
                case 2:
                this.Predicate = TypeConverter<T>.ConvertTo_Node(value);
                break;
                
                case 3:
                this.Object = TypeConverter<T>.ConvertTo_Node(value);
                break;
                
                default:
                Throw.data_type_incompatible_with_field(typeof(T).ToString());
                break;
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                
                return true;
                
                case 1:
                
                return true;
                
                case 2:
                
                return true;
                
                case 3:
                
                return true;
                
                default:
                return false;
            }
        }
        /// <summary>
        /// Append <paramref name="value"/> to the target field. Note that if the target field
        /// is not appendable(string or list), calling this method is equivalent to <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.GenericCellAccessor.SetField(string, T)"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the value.
        /// </typeparam>
        /// <param name="fieldName">The name of the target field.</param>
        /// <param name="value">The value to be appended. 
        /// If the value is incompatible with the element 
        /// type of the field, automatic type casting will be attempted.
        /// </param>
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        long ICell.CellId { get { return CellId; } set { CellId = value; } }
        public IEnumerable<KeyValuePair<string, T>> SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                break;
                
                case 5:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                case 6:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                case 7:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_RefId<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Subject<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Predicate<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Object<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                return _enumerate_from_RefId<T>();
                
                case 1:
                return _enumerate_from_Subject<T>();
                
                case 2:
                return _enumerate_from_Predicate<T>();
                
                case 3:
                return _enumerate_from_Object<T>();
                
                default:
                Throw.undefined_field();
                return null;
            }
        }
        public IEnumerable<T> EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                
                foreach (var val in _enumerate_from_RefId<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Subject<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Predicate<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Object<T>())
                    yield return val;
                
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    
                }
            }
            yield break;
        }
        public ICellAccessor Serialize()
        {
            return (RDFTriple_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_RDFTriple; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_RDFTriple; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_RDFTriple;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.RDFTriple.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.RDFTriple.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.RDFTriple.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.RDFTriple.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "RefId";
            }
            
            {
                yield return "Subject";
            }
            
            {
                yield return "Predicate";
            }
            
            {
                yield return "Object";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.RDFTriple;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of RDFTriple defined in TSL.
    /// </summary>
    public unsafe class RDFTriple_Accessor : ICellAccessor
    {
        #region Fields
        internal   long                    m_cellId;
        /// <summary>
        /// A pointer to the underlying raw binary blob. Take caution when accessing data with
        /// the raw pointer, as no boundary checks are employed, and improper operations will cause data corruption and/or system crash.
        /// </summary>
        internal byte*                   m_ptr;
        internal LocalTransactionContext m_tx;
        internal int                     m_cellEntryIndex;
        internal CellAccessOptions       m_options;
        internal bool                    m_IsIterator;
        private  const CellAccessOptions c_WALFlags = CellAccessOptions.StrongLogAhead | CellAccessOptions.WeakLogAhead;
        #endregion
        #region Constructors
        private unsafe RDFTriple_Accessor()
        {
                    RefId_Accessor_Field = new GuidAccessor(null);        Subject_Accessor_Field = new Node_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        Predicate_Accessor_Field = new Node_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        Object_Accessor_Field = new Node_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });
        }
        #endregion
        
        internal static string[] optional_field_names = null;
        ///<summary>
        ///Get an array of the names of all optional fields for object type t_struct_name.
        ///</summary>
        public static string[] GetOptionalFieldNames()
        {
            if (optional_field_names == null)
                optional_field_names = new string[]
                {
                    
                };
            return optional_field_names;
        }
        ///<summary>
        ///Get a list of the names of available optional fields in the object being operated by this accessor.
        ///</summary>
        internal List<string> GetNotNullOptionalFields()
        {
            List<string> list = new List<string>();
            BitArray ba = new BitArray(GetOptionalFieldMap());
            string[] optional_fields = GetOptionalFieldNames();
            for (int i = 0; i < ba.Count; i++)
            {
                if (ba[i])
                    list.Add(optional_fields[i]);
            }
            return list;
        }
        internal unsafe byte[] GetOptionalFieldMap()
        {
            
            return new byte[0];
            
        }
        
        #region IAccessor Implementation
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }
        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;
            {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( Guid RefId = default(Guid) , Node Subject = default(Node) , Node Predicate = default(Node) , Node Object = default(Node) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
targetPtr += 16;
            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        {
            byte[] tmpGuid = RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Subject._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Predicate._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Object._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        GuidAccessor RefId_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field RefId.
        ///</summary>
        public unsafe GuidAccessor RefId
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}RefId_Accessor_Field.m_ptr = targetPtr;
                RefId_Accessor_Field.m_cellId = this.m_cellId;
                return RefId_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                RefId_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}                Memory.Copy(value.m_ptr, targetPtr, 16); 
            }
        }
        Node_Accessor Subject_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Subject.
        ///</summary>
        public unsafe Node_Accessor Subject
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
}Subject_Accessor_Field.m_ptr = targetPtr;
                Subject_Accessor_Field.m_cellId = this.m_cellId;
                return Subject_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Subject_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        Node_Accessor Predicate_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Predicate.
        ///</summary>
        public unsafe Node_Accessor Predicate
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}}Predicate_Accessor_Field.m_ptr = targetPtr;
                Predicate_Accessor_Field.m_cellId = this.m_cellId;
                return Predicate_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Predicate_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        Node_Accessor Object_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Object.
        ///</summary>
        public unsafe Node_Accessor Object
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}Object_Accessor_Field.m_ptr = targetPtr;
                Object_Accessor_Field.m_cellId = this.m_cellId;
                return Object_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Object_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
                int offset = (int)(targetPtr - m_ptr);
                byte* oldtargetPtr = targetPtr;
                int oldlength = (int)(targetPtr - oldtargetPtr);
                targetPtr = value.m_ptr;
                int newlength = (int)(targetPtr - value.m_ptr);
                if (newlength != oldlength)
                {
                    if (value.m_cellId != this.m_cellId)
                    {
                        this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                        Memory.Copy(value.m_ptr, this.m_ptr + offset, newlength);
                    }
                    else
                    {
                        byte[] tmpcell = new byte[newlength];
                        fixed(byte* tmpcellptr = tmpcell)
                        {
                            Memory.Copy(value.m_ptr, tmpcellptr, newlength);
                            this.m_ptr = this.ResizeFunction(this.m_ptr, offset, newlength - oldlength);
                            Memory.Copy(tmpcellptr, this.m_ptr + offset, newlength);
                        }
                    }
                }
                else
                {
                    Memory.Copy(value.m_ptr, oldtargetPtr, oldlength);
                }
            }
        }
        
        public static unsafe implicit operator RDFTriple(RDFTriple_Accessor accessor)
        {
            
            return new RDFTriple(accessor.CellId
            
            ,
            
                    accessor.RefId
            ,
            
                    accessor.Subject
            ,
            
                    accessor.Predicate
            ,
            
                    accessor.Object
            );
        }
        
        public unsafe static implicit operator RDFTriple_Accessor(RDFTriple field)
        {
            byte* targetPtr = null;
            
            {
targetPtr += 16;
            {

            {

        if(field.Subject._node.StringValue!= null)
        {
            int strlen_4 = field.Subject._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(field.Predicate._node.StringValue!= null)
        {
            int strlen_4 = field.Predicate._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(field.Object._node.StringValue!= null)
        {
            int strlen_4 = field.Object._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        {
            byte[] tmpGuid = field.RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

            {

            {

        if(field.Subject._node.StringValue!= null)
        {
            int strlen_4 = field.Subject._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.Subject._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(field.Predicate._node.StringValue!= null)
        {
            int strlen_4 = field.Predicate._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.Predicate._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(field.Object._node.StringValue!= null)
        {
            int strlen_4 = field.Object._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.Object._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }RDFTriple_Accessor ret;
            
            ret = RDFTriple_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(RDFTriple_Accessor a, RDFTriple_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 16;
{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}{{targetPtr += *(int*)targetPtr + sizeof(int);}}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (RDFTriple_Accessor a, RDFTriple_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(RDFTriple_Accessor a, RDFTriple b)
        {
            RDFTriple_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(RDFTriple_Accessor a, RDFTriple b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Get the size of the cell content, in bytes.
        /// </summary>
        public int CellSize { get { int size; Global.LocalStorage.LockedGetCellSize(this.CellId, this.m_cellEntryIndex, out size); return size; } }
        #region Internal
        private unsafe byte* _Resize_NonTx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell((long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        private unsafe byte* _Resize_Tx(byte* ptr, int ptr_offset, int delta)
        {
            int offset = (int)(ptr - m_ptr) + ptr_offset;
            m_ptr = Global.LocalStorage.ResizeCell(m_tx, (long)CellId, m_cellEntryIndex, offset, delta);
            return m_ptr + (offset - ptr_offset);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe RDFTriple_Accessor _Lock(long cellId, CellAccessOptions options)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.ResizeFunction = _Resize_NonTx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.RDFTriple)
                    {
                        Global.LocalStorage.ReleaseCellLock(cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.RDFTriple, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal unsafe RDFTriple_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
        {
            ushort cellType;
            this.CellId = cellId;
            this.m_options = options;
            this.m_tx = tx;
            this.ResizeFunction = _Resize_Tx;
            TrinityErrorCode eResult = Global.LocalStorage.GetLockedCellInfo(tx, cellId, out _, out cellType, out this.m_ptr, out this.m_cellEntryIndex);
            switch (eResult)
            {
                case TrinityErrorCode.E_SUCCESS:
                {
                    if (cellType != (ushort)CellType.RDFTriple)
                    {
                        Global.LocalStorage.ReleaseCellLock(tx, cellId, this.m_cellEntryIndex);
                        _put(this);
                        Throw.wrong_cell_type();
                    }
                    break;
                }
                case TrinityErrorCode.E_CELL_NOT_FOUND:
                {
                    if ((options & CellAccessOptions.ThrowExceptionOnCellNotFound) != 0)
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    else if ((options & CellAccessOptions.CreateNewOnCellNotFound) != 0)
                    {
                        byte[]  defaultContent = construct();
                        int     size           = defaultContent.Length;
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.RDFTriple, out this.m_ptr, out this.m_cellEntryIndex);
                        if (eResult == TrinityErrorCode.E_WRONG_CELL_TYPE)
                        {
                            _put(this);
                            Throw.wrong_cell_type();
                        }
                    }
                    else if ((options & CellAccessOptions.ReturnNullOnCellNotFound) != 0)
                    {
                        _put(this);
                        return null;
                    }
                    else
                    {
                        _put(this);
                        Throw.cell_not_found(cellId);
                    }
                    break;
                }
                default:
                _put(this);
                throw new NotImplementedException();
            }
            return this;
        }
        private class PoolPolicy : IPooledObjectPolicy<RDFTriple_Accessor>
        {
            public RDFTriple_Accessor Create()
            {
                return new RDFTriple_Accessor();
            }
            public bool Return(RDFTriple_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<RDFTriple_Accessor> s_accessor_pool = new DefaultObjectPool<RDFTriple_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static RDFTriple_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(RDFTriple_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RDFTriple_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = null;
            this.ResizeFunction = _Resize_NonTx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal RDFTriple_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
        {
            this.CellId      = CellId;
            m_cellEntryIndex = entryIndex;
            m_options        = options;
            m_ptr            = cellPtr;
            m_tx             = tx;
            this.ResizeFunction = _Resize_Tx;
            return this;
        }
        /// <summary>
        /// For internal use only.
        /// </summary>
        internal static RDFTriple_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            RDFTriple_Accessor accessor = new RDFTriple_Accessor();
            accessor.m_IsIterator = true;
            if (tx != null) accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0, tx);
            else accessor._Setup(info.CellId, info.CellPtr, info.CellEntryIndex, 0);
            return accessor;
        }
        #endregion
        #region Public
        /// <summary>
        /// Dispose the accessor.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// the cell lock will be released.
        /// If write-ahead-log behavior is specified on <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.StorageExtension_RDFTriple.UseRDFTriple"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.RDFTriple, m_options);
                }
                if (!m_IsIterator)
                {
                    if (m_tx == null) Global.LocalStorage.ReleaseCellLock(CellId, m_cellEntryIndex);
                    else Global.LocalStorage.ReleaseCellLock(m_tx, CellId, m_cellEntryIndex);
                }
            }
            _put(this);
        }
        /// <summary>
        /// Get the cell type id.
        /// </summary>
        /// <returns>A 16-bit unsigned integer representing the cell type id.</returns>
        public ushort GetCellType()
        {
            ushort cellType;
            if (Global.LocalStorage.GetCellType(CellId, out cellType) == TrinityErrorCode.E_CELL_NOT_FOUND)
            {
                Throw.cell_not_found();
            }
            return cellType;
        }
        /// <summary>Converts a RDFTriple_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the RDFTriple.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "RefId"
            ,
            "Subject"
            ,
            "Predicate"
            ,
            "Object"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
            "RefId"
            ,
            "Subject"
            ,
            "Predicate"
            ,
            "Object"
            ,
        };
        #endregion
        #region ICell implementation
        public T GetField<T>(string fieldName)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    
                    case 1:
                    return GenericFieldAccessor.GetField<T>(this.Subject, fieldName, field_divider_idx + 1);
                    
                    case 2:
                    return GenericFieldAccessor.GetField<T>(this.Predicate, fieldName, field_divider_idx + 1);
                    
                    case 3:
                    return GenericFieldAccessor.GetField<T>(this.Object, fieldName, field_divider_idx + 1);
                    
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                
                case 2:
                return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                
                case 3:
                return TypeConverter<T>.ConvertFrom_Node(this.Object);
                
            }
            /* Should not reach here */
            throw new Exception("Internal error T5005");
        }
        public void SetField<T>(string fieldName, T value)
        {
            int field_divider_idx = fieldName.IndexOf('.');
            if (-1 != field_divider_idx)
            {
                string field_name_string = fieldName.Substring(0, field_divider_idx);
                switch (FieldLookupTable.Lookup(field_name_string))
                {
                    case -1:
                    Throw.undefined_field();
                    break;
                    
                    case 1:
                    GenericFieldAccessor.SetField(this.Subject, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 2:
                    GenericFieldAccessor.SetField(this.Predicate, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    case 3:
                    GenericFieldAccessor.SetField(this.Object, fieldName, field_divider_idx + 1, value);
                    break;
                    
                    default:
                    Throw.member_access_on_non_struct__field(field_name_string);
                    break;
                }
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                case 0:
                {
                    Guid conversion_result = TypeConverter<T>.ConvertTo_Guid(value);
                    
            {
                this.RefId = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    Node conversion_result = TypeConverter<T>.ConvertTo_Node(value);
                    
            {
                this.Subject = conversion_result;
            }
            
                }
                break;
                
                case 2:
                {
                    Node conversion_result = TypeConverter<T>.ConvertTo_Node(value);
                    
            {
                this.Predicate = conversion_result;
            }
            
                }
                break;
                
                case 3:
                {
                    Node conversion_result = TypeConverter<T>.ConvertTo_Node(value);
                    
            {
                this.Object = conversion_result;
            }
            
                }
                break;
                
            }
        }
        /// <summary>
        /// Tells if a field with the given name exists in the current cell.
        /// </summary>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>The existence of the field.</returns>
        public bool ContainsField(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                
                return true;
                
                case 1:
                
                return true;
                
                case 2:
                
                return true;
                
                case 3:
                
                return true;
                
                default:
                return false;
            }
        }
        public void AppendToField<T>(string fieldName, T value)
        {
            if (AppendToFieldRerouteSet.Contains(fieldName))
            {
                SetField(fieldName, value);
                return;
            }
            switch (FieldLookupTable.Lookup(fieldName))
            {
                case -1:
                Throw.undefined_field();
                break;
                
                default:
                Throw.target__field_not_list();
                break;
            }
        }
        public long CellId { get { return m_cellId; } set { m_cellId = value; } }
        IEnumerable<KeyValuePair<string, T>> ICell.SelectFields<T>(string attributeKey, string attributeValue)
        {
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                break;
                
                case 5:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                case 6:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.RefId, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("RefId", TypeConverter<T>.ConvertFrom_Guid(this.RefId));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                case 7:
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Subject, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Subject", TypeConverter<T>.ConvertFrom_Node(this.Subject));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Predicate, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Predicate", TypeConverter<T>.ConvertFrom_Node(this.Predicate));
                
                if (StorageSchema.RDFTriple_descriptor.check_attribute(StorageSchema.RDFTriple_descriptor.Object, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("Object", TypeConverter<T>.ConvertFrom_Node(this.Object));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_RefId<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Guid(this.RefId);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Subject<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Subject);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Predicate<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Predicate);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_Object<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_Node(this.Object);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private static StringLookupTable s_field_attribute_id_table = new StringLookupTable(
            
            );
        #endregion
        public IEnumerable<T> EnumerateField<T>(string fieldName)
        {
            switch (FieldLookupTable.Lookup(fieldName))
            {
                
                case 0:
                return _enumerate_from_RefId<T>();
                
                case 1:
                return _enumerate_from_Subject<T>();
                
                case 2:
                return _enumerate_from_Predicate<T>();
                
                case 3:
                return _enumerate_from_Object<T>();
                
                default:
                Throw.undefined_field();
                return null;
            }
        }
        IEnumerable<T> ICell.EnumerateValues<T>(string attributeKey, string attributeValue)
        {
            int attr_id;
            if (attributeKey == null)
            {
                
                foreach (var val in _enumerate_from_RefId<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Subject<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Predicate<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_Object<T>())
                    yield return val;
                
            }
            else if (-1 != (attr_id = s_field_attribute_id_table.Lookup(attributeKey)))
            {
                switch (attr_id)
                {
                    
                }
            }
            yield break;
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "RefId";
            }
            
            {
                yield return "Subject";
            }
            
            {
                yield return "Predicate";
            }
            
            {
                yield return "Object";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.RDFTriple.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.RDFTriple.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_RDFTriple; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_RDFTriple; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_RDFTriple;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.RDFTriple.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.RDFTriple.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.RDFTriple;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (RDFTriple)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing RDFTriple cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_RDFTriple
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this IKeyValueStore storage, long cellId, Guid RefId = default(Guid), Node Subject = default(Node), Node Predicate = default(Node), Node Object = default(Node))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
targetPtr += 16;
            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        {
            byte[] tmpGuid = RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Subject._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Predicate._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Object._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.RDFTriple) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this IKeyValueStore storage, long cellId, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, cellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this IKeyValueStore storage, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, cellContent.CellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static RDFTriple LoadRDFTriple(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return RDFTriple_Accessor._get()._Setup(cellId, p, -1, 0);
                }
            }
            else
            {
                Throw.cell_not_found();
                throw new Exception();
            }
        }
        #endregion
        #region LocalMemoryStorage Non-Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a RDFTriple. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.RDFTriple"/> instance.</returns>
        public unsafe static RDFTriple_Accessor UseRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return RDFTriple_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a RDFTriple. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".RDFTriple"/> instance.</returns>
        public unsafe static RDFTriple_Accessor UseRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return RDFTriple_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, Guid RefId = default(Guid), Node Subject = default(Node), Node Predicate = default(Node), Node Object = default(Node))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
targetPtr += 16;
            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        {
            byte[] tmpGuid = RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Subject._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Predicate._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Object._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.RDFTriple) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, options, cellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, options, cellContent.CellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static RDFTriple LoadRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = RDFTriple_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a RDFTriple. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.RDFTriple"/> instance.</returns>
        public unsafe static RDFTriple_Accessor UseRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return RDFTriple_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a RDFTriple. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".RDFTriple"/> instance.</returns>
        public unsafe static RDFTriple_Accessor UseRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return RDFTriple_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, Guid RefId = default(Guid), Node Subject = default(Node), Node Predicate = default(Node), Node Object = default(Node))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {
targetPtr += 16;
            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        {
            byte[] tmpGuid = RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

            {

            {

        if(Subject._node.StringValue!= null)
        {
            int strlen_4 = Subject._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Subject._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Predicate._node.StringValue!= null)
        {
            int strlen_4 = Predicate._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Predicate._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            {

            {

        if(Object._node.StringValue!= null)
        {
            int strlen_4 = Object._node.StringValue.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = Object._node.StringValue)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }
            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.RDFTriple) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, tx, options, cellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Adds a new cell of type RDFTriple to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, RDFTriple cellContent)
        {
            return SaveRDFTriple(storage, tx, options, cellContent.CellId  , cellContent.RefId  , cellContent.Subject  , cellContent.Predicate  , cellContent.Object );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static RDFTriple LoadRDFTriple(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = RDFTriple_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
