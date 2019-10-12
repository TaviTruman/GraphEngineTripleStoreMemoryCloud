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
    /// A .NET runtime object representation of Graph defined in TSL.
    /// </summary>
    public partial struct Graph : ICell
    {
        ///<summary>
        ///The id of the cell.
        ///</summary>
        public long CellId;
        ///<summary>
        ///Initializes a new instance of Graph with the specified parameters.
        ///</summary>
        public Graph(long cell_id , string BaseUri = default(string), List<Triple> TripleCollection = default(List<Triple>))
        {
            
            this.BaseUri = BaseUri;
            
            this.TripleCollection = TripleCollection;
            
            CellId = cell_id;
        }
        
        ///<summary>
        ///Initializes a new instance of Graph with the specified parameters.
        ///</summary>
        public Graph( string BaseUri = default(string), List<Triple> TripleCollection = default(List<Triple>))
        {
            
            this.BaseUri = BaseUri;
            
            this.TripleCollection = TripleCollection;
            
            CellId = CellIdFactory.NewCellId();
        }
        
        public string BaseUri;
        
        public List<Triple> TripleCollection;
        
        public static bool operator ==(Graph a, Graph b)
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
                
                (a.BaseUri == b.BaseUri)
                &&
                (a.TripleCollection == b.TripleCollection)
                
                ;
            
        }
        public static bool operator !=(Graph a, Graph b)
        {
            return !(a == b);
        }
        #region Text processing
        /// <summary>
        /// Converts the string representation of a Graph to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Graph) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// True if input was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string input, out Graph value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Graph>(input);
                return true;
            }
            catch { value = default(Graph); return false; }
        }
        public static Graph Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Graph>(input);
        }
        ///<summary>Converts a Graph to its string representation, in JSON format.</summary>
        ///<returns>A string representation of the Graph.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "BaseUri"
            ,
            "TripleCollection"
            
            );
        internal static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
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
                return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                
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
                this.BaseUri = TypeConverter<T>.ConvertTo_string(value);
                break;
                
                case 1:
                this.TripleCollection = TypeConverter<T>.ConvertTo_List_Triple(value);
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
                
                case 0:
                
                {
                    if (this.BaseUri == null)
                        this.BaseUri = TypeConverter<T>.ConvertTo_string(value);
                    else
                        this.BaseUri += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 1:
                
                {
                    if (this.TripleCollection == null)
                        this.TripleCollection = new List<Triple>();
                    switch (TypeConverter<T>.GetConversionActionTo_List_Triple())
                    {
                        case TypeConversionAction.TC_ASSIGN:
                        foreach (var element in value as List<Triple>)
                            this.TripleCollection.Add(element);
                        break;
                        case TypeConversionAction.TC_CONVERTLIST:
                        case TypeConversionAction.TC_ARRAYTOLIST:
                        foreach (var element in TypeConverter<T>.Enumerate_Triple(value))
                            this.TripleCollection.Add(element);
                        break;
                        case TypeConversionAction.TC_WRAPINLIST:
                        case TypeConversionAction.TC_PARSESTRING:
                        this.TripleCollection.Add(TypeConverter<T>.ConvertTo_Triple(value));
                        break;
                        default:
                        Throw.data_type_incompatible_with_list(typeof(T).ToString());
                        break;
                    }
                }
                
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
                
                case 0:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 1:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 2:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 3:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 4:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 5:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 6:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 7:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 8:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 9:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value constructs
        
        private IEnumerable<T> _enumerate_from_BaseUri<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 8:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 9:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_TripleCollection<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        {
                            
                            var element0 = this.TripleCollection;
                            
                            foreach (var element1 in  element0)
                            
                            {
                                yield return TypeConverter<T>.ConvertFrom_Triple(element1);
                            }
                        }
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        {
                            
                            var element0 = this.TripleCollection;
                            
                            foreach (var element1 in  element0)
                            
                            {
                                yield return TypeConverter<T>.ConvertFrom_Triple(element1);
                            }
                        }
                        
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
                return _enumerate_from_BaseUri<T>();
                
                case 1:
                return _enumerate_from_TripleCollection<T>();
                
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
                
                foreach (var val in _enumerate_from_BaseUri<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_TripleCollection<T>())
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
            return (Graph_Accessor)this;
        }
        #endregion
        #region Other interfaces
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_Graph; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_Graph; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_Graph;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.Graph.GetFieldDescriptors();
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.Graph.GetFieldAttributes(fieldName);
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.Graph.GetAttributeValue(attributeKey);
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.Graph.Attributes; }
        }
        IEnumerable<string> ICellDescriptor.GetFieldNames()
        {
            
            {
                yield return "BaseUri";
            }
            
            {
                yield return "TripleCollection";
            }
            
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.Graph;
            }
        }
        #endregion
    }
    /// <summary>
    /// Provides in-place operations of Graph defined in TSL.
    /// </summary>
    public unsafe class Graph_Accessor : ICellAccessor
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
        private unsafe Graph_Accessor()
        {
                    BaseUri_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        TripleCollection_Accessor_Field = new Triple_AccessorListAccessor(null,
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        private static byte[] s_default_content = null;
        private static unsafe byte[] construct( string BaseUri = default(string) , List<Triple> TripleCollection = default(List<Triple>) )
        {
            if (s_default_content != null) return s_default_content;
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            }
        }
    }

}

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = BaseUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = TripleCollection[iterator_2].Url)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = TripleCollection[iterator_2].HashCode;
            targetPtr += 8;

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
            }
            
            s_default_content = tmpcell;
            return tmpcell;
        }
        StringAccessor BaseUri_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field BaseUri.
        ///</summary>
        public unsafe StringAccessor BaseUri
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}BaseUri_Accessor_Field.m_ptr = targetPtr + 4;
                BaseUri_Accessor_Field.m_cellId = this.m_cellId;
                return BaseUri_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                BaseUri_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != BaseUri_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    BaseUri_Accessor_Field.m_ptr = BaseUri_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, BaseUri_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        BaseUri_Accessor_Field.m_ptr = BaseUri_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, BaseUri_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        Triple_AccessorListAccessor TripleCollection_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field TripleCollection.
        ///</summary>
        public unsafe Triple_AccessorListAccessor TripleCollection
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}TripleCollection_Accessor_Field.m_ptr = targetPtr + 4;
                TripleCollection_Accessor_Field.m_cellId = this.m_cellId;
                return TripleCollection_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                TripleCollection_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {targetPtr += *(int*)targetPtr + sizeof(int);}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != TripleCollection_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    TripleCollection_Accessor_Field.m_ptr = TripleCollection_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, TripleCollection_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        TripleCollection_Accessor_Field.m_ptr = TripleCollection_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, TripleCollection_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Graph(Graph_Accessor accessor)
        {
            
            return new Graph(accessor.CellId
            
            ,
            
                    accessor.BaseUri
            ,
            
                    accessor.TripleCollection
            );
        }
        
        public unsafe static implicit operator Graph_Accessor(Graph field)
        {
            byte* targetPtr = null;
            
            {

        if(field.BaseUri!= null)
        {
            int strlen_2 = field.BaseUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(field.TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.TripleCollection.Count;++iterator_2)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field.TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = field.TripleCollection[iterator_2].Url.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(field.TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = field.TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            }
        }
    }

}

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        if(field.BaseUri!= null)
        {
            int strlen_2 = field.BaseUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.BaseUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.TripleCollection.Count;++iterator_2)
        {

            {

            {
            *(NodeType*)targetPtr = field.TripleCollection[iterator_2].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.TripleCollection[iterator_2].SubjectNode.GraphParent;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.TripleCollection[iterator_2].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.TripleCollection[iterator_2].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field.TripleCollection[iterator_2].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.TripleCollection[iterator_2].PredicateNode.GraphParent;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.TripleCollection[iterator_2].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.TripleCollection[iterator_2].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field.TripleCollection[iterator_2].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.TripleCollection[iterator_2].ObjectNode.GraphParent;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = field.TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field.TripleCollection[iterator_2].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.TripleCollection[iterator_2].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(field.TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = field.TripleCollection[iterator_2].Url.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.TripleCollection[iterator_2].Url)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.TripleCollection[iterator_2].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = field.TripleCollection[iterator_2].HashCode;
            targetPtr += 8;

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(field.TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<field.TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            *(NodeType*)targetPtr = field.TripleCollection[iterator_2].Nodes[iterator_4].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.TripleCollection[iterator_2].Nodes[iterator_4].GraphParent;
            targetPtr += 8;

        if(field.TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = field.TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = field.TripleCollection[iterator_2].Nodes[iterator_4].GraphUri)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.TripleCollection[iterator_2].Nodes[iterator_4].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }Graph_Accessor ret;
            
            ret = Graph_Accessor._get()._Setup(field.CellId, tmpcellptr, -1, 0, null);
            ret.m_cellId = field.CellId;
            
            return ret;
        }
        
        public static bool operator ==(Graph_Accessor a, Graph_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Graph_Accessor a, Graph_Accessor b)
        {
            return !(a == b);
        }
        
        public static bool operator ==(Graph_Accessor a, Graph b)
        {
            Graph_Accessor bb = b;
            return (a == bb);
        }
        public static bool operator !=(Graph_Accessor a, Graph b)
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
        internal unsafe Graph_Accessor _Lock(long cellId, CellAccessOptions options)
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
                    if (cellType != (ushort)CellType.Graph)
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
                        eResult                = Global.LocalStorage.AddOrUse(cellId, defaultContent, ref size, (ushort)CellType.Graph, out this.m_ptr, out this.m_cellEntryIndex);
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
        internal unsafe Graph_Accessor _Lock(long cellId, CellAccessOptions options, LocalTransactionContext tx)
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
                    if (cellType != (ushort)CellType.Graph)
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
                        eResult                = Global.LocalStorage.AddOrUse(tx, cellId, defaultContent, ref size, (ushort)CellType.Graph, out this.m_ptr, out this.m_cellEntryIndex);
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
        private class PoolPolicy : IPooledObjectPolicy<Graph_Accessor>
        {
            public Graph_Accessor Create()
            {
                return new Graph_Accessor();
            }
            public bool Return(Graph_Accessor obj)
            {
                return !obj.m_IsIterator;
            }
        }
        private static DefaultObjectPool<Graph_Accessor> s_accessor_pool = new DefaultObjectPool<Graph_Accessor>(new PoolPolicy());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Graph_Accessor _get() => s_accessor_pool.Get();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void _put(Graph_Accessor item) => s_accessor_pool.Return(item);
        /// <summary>
        /// For internal use only.
        /// Caller guarantees that entry lock is obtained.
        /// Does not handle CellAccessOptions. Only copy to the accessor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Graph_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options)
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
        internal Graph_Accessor _Setup(long CellId, byte* cellPtr, int entryIndex, CellAccessOptions options, LocalTransactionContext tx)
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
        internal static Graph_Accessor AllocIterativeAccessor(CellInfo info, LocalTransactionContext tx)
        {
            Graph_Accessor accessor = new Graph_Accessor();
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
        /// If write-ahead-log behavior is specified on <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.StorageExtension_Graph.UseGraph"/>,
        /// the changes will be committed to the write-ahead log.
        /// </summary>
        public void Dispose()
        {
            if (m_cellEntryIndex >= 0)
            {
                if ((m_options & c_WALFlags) != 0)
                {
                    LocalMemoryStorage.CWriteAheadLog(this.CellId, this.m_ptr, this.CellSize, (ushort)CellType.Graph, m_options);
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
        /// <summary>Converts a Graph_Accessor to its string representation, in JSON format.</summary>
        /// <returns>A string representation of the Graph.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        #endregion
        #region Lookup tables
        internal static StringLookupTable FieldLookupTable = new StringLookupTable(
            
            "BaseUri"
            ,
            "TripleCollection"
            
            );
        static HashSet<string> AppendToFieldRerouteSet = new HashSet<string>()
        {
            
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
                return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                
                case 1:
                return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                
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
                    string conversion_result = TypeConverter<T>.ConvertTo_string(value);
                    
            {
                this.BaseUri = conversion_result;
            }
            
                }
                break;
                
                case 1:
                {
                    List<Triple> conversion_result = TypeConverter<T>.ConvertTo_List_Triple(value);
                    
            {
                this.TripleCollection = conversion_result;
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
                
                case 0:
                
                {
                    
                    this.BaseUri += TypeConverter<T>.ConvertTo_string(value);
                }
                
                break;
                
                case 1:
                
                {
                    
                    switch (TypeConverter<T>.GetConversionActionTo_List_Triple())
                    {
                        case TypeConversionAction.TC_ASSIGN:
                        foreach (var element in value as List<Triple>)
                            this.TripleCollection.Add(element);
                        break;
                        case TypeConversionAction.TC_CONVERTLIST:
                        case TypeConversionAction.TC_ARRAYTOLIST:
                        foreach (var element in TypeConverter<T>.Enumerate_Triple(value))
                            this.TripleCollection.Add(element);
                        break;
                        case TypeConversionAction.TC_WRAPINLIST:
                        case TypeConversionAction.TC_PARSESTRING:
                        this.TripleCollection.Add(TypeConverter<T>.ConvertTo_Triple(value));
                        break;
                        default:
                        Throw.data_type_incompatible_with_list(typeof(T).ToString());
                        break;
                    }
                }
                
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
                
                case 0:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 1:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 2:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 3:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 4:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 5:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.TripleCollection, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("TripleCollection", TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection));
                
                break;
                
                case 6:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 7:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 8:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                case 9:
                
                if (StorageSchema.Graph_descriptor.check_attribute(StorageSchema.Graph_descriptor.BaseUri, attributeKey, attributeValue))
                    
                        yield return new KeyValuePair<string, T>("BaseUri", TypeConverter<T>.ConvertFrom_string(this.BaseUri));
                
                break;
                
                default:
                Throw.incompatible_with_cell();
                break;
            }
            yield break;
        }
        #region enumerate value methods
        
        private IEnumerable<T> _enumerate_from_BaseUri<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 0:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 1:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 2:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 4:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 6:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 8:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                case 9:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_string(this.BaseUri);
                        
                    }
                    break;
                
                default:
                    Throw.incompatible_with_cell();
                    break;
            }
            yield break;
            
        }
        
        private IEnumerable<T> _enumerate_from_TripleCollection<T>()
        {
            
            switch (TypeConverter<T>.type_id)
            {
                
                case 2:
                    {
                        
                        {
                            
                            var element0 = this.TripleCollection;
                            
                            foreach (var element1 in  element0)
                            
                            {
                                yield return TypeConverter<T>.ConvertFrom_Triple(element1);
                            }
                        }
                        
                    }
                    break;
                
                case 3:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                        
                    }
                    break;
                
                case 5:
                    {
                        
                        yield return TypeConverter<T>.ConvertFrom_List_Triple(this.TripleCollection);
                        
                    }
                    break;
                
                case 7:
                    {
                        
                        {
                            
                            var element0 = this.TripleCollection;
                            
                            foreach (var element1 in  element0)
                            
                            {
                                yield return TypeConverter<T>.ConvertFrom_Triple(element1);
                            }
                        }
                        
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
                return _enumerate_from_BaseUri<T>();
                
                case 1:
                return _enumerate_from_TripleCollection<T>();
                
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
                
                foreach (var val in _enumerate_from_BaseUri<T>())
                    yield return val;
                
                foreach (var val in _enumerate_from_TripleCollection<T>())
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
                yield return "BaseUri";
            }
            
            {
                yield return "TripleCollection";
            }
            
        }
        IAttributeCollection ICellDescriptor.GetFieldAttributes(string fieldName)
        {
            return StorageSchema.Graph.GetFieldAttributes(fieldName);
        }
        IEnumerable<IFieldDescriptor> ICellDescriptor.GetFieldDescriptors()
        {
            return StorageSchema.Graph.GetFieldDescriptors();
        }
        string ITypeDescriptor.TypeName
        {
            get { return StorageSchema.s_cellTypeName_Graph; }
        }
        Type ITypeDescriptor.Type
        {
            get { return StorageSchema.s_cellType_Graph; }
        }
        bool ITypeDescriptor.IsOfType<T>()
        {
            return typeof(T) == StorageSchema.s_cellType_Graph;
        }
        bool ITypeDescriptor.IsList()
        {
            return false;
        }
        IReadOnlyDictionary<string, string> IAttributeCollection.Attributes
        {
            get { return StorageSchema.Graph.Attributes; }
        }
        string IAttributeCollection.GetAttributeValue(string attributeKey)
        {
            return StorageSchema.Graph.GetAttributeValue(attributeKey);
        }
        ushort ICellDescriptor.CellType
        {
            get
            {
                return (ushort)CellType.Graph;
            }
        }
        public ICellAccessor Serialize()
        {
            return this;
        }
        #endregion
        public ICell Deserialize()
        {
            return (Graph)this;
        }
    }
    ///<summary>
    ///Provides interfaces for accessing Graph cells
    ///on <see cref="Trinity.Storage.LocalMemorySotrage"/>.
    static public class StorageExtension_Graph
    {
        #region IKeyValueStore non logging
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this IKeyValueStore storage, long cellId, string BaseUri = default(string), List<Triple> TripleCollection = default(List<Triple>))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            }
        }
    }

}

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = BaseUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = TripleCollection[iterator_2].Url)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = TripleCollection[iterator_2].HashCode;
            targetPtr += 8;

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
            }
            
            return storage.SaveCell(cellId, tmpcell, (ushort)CellType.Graph) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this IKeyValueStore storage, long cellId, Graph cellContent)
        {
            return SaveGraph(storage, cellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this IKeyValueStore storage, Graph cellContent)
        {
            return SaveGraph(storage, cellContent.CellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.IKeyValueStore"/> instance.</param>
        /// </summary>
        public unsafe static Graph LoadGraph(this IKeyValueStore storage, long cellId)
        {
            if (TrinityErrorCode.E_SUCCESS == storage.LoadCell(cellId, out var buff))
            {
                fixed (byte* p = buff)
                {
                    return Graph_Accessor._get()._Setup(cellId, p, -1, 0);
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
        /// the cell as a Graph. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.Graph"/> instance.</returns>
        public unsafe static Graph_Accessor UseGraph(this Trinity.Storage.LocalMemoryStorage storage, long cellId, CellAccessOptions options)
        {
            return Graph_Accessor._get()._Lock(cellId, options);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Graph. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".Graph"/> instance.</returns>
        public unsafe static Graph_Accessor UseGraph(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            return Graph_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound);
        }
        #endregion
        #region LocalStorage Non-Tx logging
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, string BaseUri = default(string), List<Triple> TripleCollection = default(List<Triple>))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            }
        }
    }

}

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = BaseUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = TripleCollection[iterator_2].Url)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = TripleCollection[iterator_2].HashCode;
            targetPtr += 8;

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
            }
            
            return storage.SaveCell(options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.Graph) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, long cellId, Graph cellContent)
        {
            return SaveGraph(storage, options, cellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, CellAccessOptions options, Graph cellContent)
        {
            return SaveGraph(storage, options, cellContent.CellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static Graph LoadGraph(this Trinity.Storage.LocalMemoryStorage storage, long cellId)
        {
            using (var cell = Graph_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound))
            {
                return cell;
            }
        }
        #endregion
        #region LocalMemoryStorage Tx accessors
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Graph. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock. Otherwise this method is wait-free.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>A <see cref="InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL.Graph"/> instance.</returns>
        public unsafe static Graph_Accessor UseGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId, CellAccessOptions options)
        {
            return Graph_Accessor._get()._Lock(cellId, options, tx);
        }
        /// <summary>
        /// Allocate a cell accessor on the specified cell, which interprets
        /// the cell as a Graph. Any changes done to the accessor
        /// are written to the storage immediately.
        /// If <c><see cref="Trinity.TrinityConfig.ReadOnly"/> == false</c>,
        /// on calling this method, it attempts to acquire the lock of the cell,
        /// and blocks until it gets the lock.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">The id of the specified cell.</param>
        /// <returns>A <see cref="" + script.RootNamespace + ".Graph"/> instance.</returns>
        public unsafe static Graph_Accessor UseGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            return Graph_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx);
        }
        #endregion
        #region LocalStorage Tx logging
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The value of the cell is specified in the method parameters.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, string BaseUri = default(string), List<Triple> TripleCollection = default(List<Triple>))
        {
            
            byte* targetPtr;
            
            targetPtr = null;
            
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

{

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            targetPtr += strlen_6+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            }
        }
    }

}

            }
            byte[] tmpcell = new byte[(int)(targetPtr)];
            fixed (byte* _tmpcellptr = tmpcell)
            {
                targetPtr = _tmpcellptr;
                
            {

        if(BaseUri!= null)
        {
            int strlen_2 = BaseUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = BaseUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection!= null)
    {
        for(int iterator_2 = 0;iterator_2<TripleCollection.Count;++iterator_2)
        {

            {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].SubjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].PredicateNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].ObjectNode.GraphUri!= null)
        {
            int strlen_5 = TripleCollection[iterator_2].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = TripleCollection[iterator_2].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(TripleCollection[iterator_2].Url!= null)
        {
            int strlen_4 = TripleCollection[iterator_2].Url.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = TripleCollection[iterator_2].Url)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = TripleCollection[iterator_2].HashCode;
            targetPtr += 8;

{
byte *storedPtr_4 = targetPtr;

    targetPtr += sizeof(int);
    if(TripleCollection[iterator_2].Nodes!= null)
    {
        for(int iterator_4 = 0;iterator_4<TripleCollection[iterator_2].Nodes.Count;++iterator_4)
        {

            {
            *(NodeType*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].GraphParent;
            targetPtr += 8;

        if(TripleCollection[iterator_2].Nodes[iterator_4].GraphUri!= null)
        {
            int strlen_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_6;
            targetPtr += sizeof(int);
            fixed(char* pstr_6 = TripleCollection[iterator_2].Nodes[iterator_4].GraphUri)
            {
                Memory.Copy(pstr_6, targetPtr, strlen_6);
                targetPtr += strlen_6;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = TripleCollection[iterator_2].Nodes[iterator_4].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_4 = (int)(targetPtr - storedPtr_4 - 4);

}

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }
            }
            
            return storage.SaveCell(tx, options, cellId, tmpcell, 0, tmpcell.Length, (ushort)CellType.Graph) == TrinityErrorCode.E_SUCCESS;
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. The parameter <paramref name="cellId"/> overrides the cell id in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="cellId">A 64-bit cell Id.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, long cellId, Graph cellContent)
        {
            return SaveGraph(storage, tx, options, cellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Adds a new cell of type Graph to the key-value store if the cell Id does not exist, or updates an existing cell in the key-value store if the cell Id already exists. Cell Id is specified by the CellId field in the content object.
        /// </summary>
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// <param name="options">Specifies write-ahead logging behavior. Valid values are CellAccessOptions.StrongLogAhead(default) and CellAccessOptions.WeakLogAhead. Other values are ignored.</param>
        /// <param name="cellContent">The content of the cell.</param>
        /// <returns>true if saving succeeds; otherwise, false.</returns>
        public unsafe static bool SaveGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, CellAccessOptions options, Graph cellContent)
        {
            return SaveGraph(storage, tx, options, cellContent.CellId  , cellContent.BaseUri  , cellContent.TripleCollection );
        }
        /// <summary>
        /// Loads the content of the specified cell. Any changes done to this object are not written to the store, unless
        /// the content object is saved back into the storage.
        /// <param name="storage"/>A <see cref="Trinity.Storage.LocalMemoryStorage"/> instance.</param>
        /// </summary>
        public unsafe static Graph LoadGraph(this Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx, long cellId)
        {
            using (var cell = Graph_Accessor._get()._Lock(cellId, CellAccessOptions.ThrowExceptionOnCellNotFound, tx))
            {
                return cell;
            }
        }
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
