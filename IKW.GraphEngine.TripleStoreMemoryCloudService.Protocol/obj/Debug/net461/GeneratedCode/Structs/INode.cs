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
using Trinity.Storage;
using Trinity.Utilities;
using Trinity.TSL.Lib;
using Trinity.Network;
using Trinity.Network.Sockets;
using Trinity.Network.Messaging;
using Trinity.TSL;
using System.Text.RegularExpressions;
using Trinity.Core.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    /// <summary>
    /// A .NET runtime object representation of INode defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct INode
    {
        
        ///<summary>
        ///Initializes a new instance of INode with the specified parameters.
        ///</summary>
        public INode(NodeType TypeOfNode = default(NodeType),long GraphParent = default(long),string GraphUri = default(string),long HashCode = default(long))
        {
            
            this.TypeOfNode = TypeOfNode;
            
            this.GraphParent = GraphParent;
            
            this.GraphUri = GraphUri;
            
            this.HashCode = HashCode;
            
        }
        
        public static bool operator ==(INode a, INode b)
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
                
                (a.TypeOfNode == b.TypeOfNode)
                &&
                (a.GraphParent == b.GraphParent)
                &&
                (a.GraphUri == b.GraphUri)
                &&
                (a.HashCode == b.HashCode)
                
                ;
            
        }
        public static bool operator !=(INode a, INode b)
        {
            return !(a == b);
        }
        
        public NodeType TypeOfNode;
        
        public long GraphParent;
        
        public string GraphUri;
        
        public long HashCode;
        
        /// <summary>
        /// Converts the string representation of a INode to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(INode) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out INode value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<INode>(input);
                return true;
            }
            catch { value = default(INode); return false; }
        }
        public static INode Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<INode>(input);
        }
        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
    }
    /// <summary>
    /// Provides in-place operations of INode defined in TSL.
    /// </summary>
    public unsafe partial class INode_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe INode_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    GraphUri_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });
        }
        
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
        
        ///<summary>
        ///Copies the struct content into a byte array.
        ///</summary>
        public byte[] ToByteArray()
        {
            byte* targetPtr = m_ptr;
            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            int size = (int)(targetPtr - m_ptr);
            byte[] ret = new byte[size];
            Memory.Copy(m_ptr, 0, ret, 0, size);
            return ret;
        }
        #region IAccessor
        public unsafe byte* GetUnderlyingBufferPointer()
        {
            return m_ptr;
        }
        public unsafe int GetBufferLength()
        {
            byte* targetPtr = m_ptr;
            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        
        ///<summary>
        ///Provides in-place access to the object field TypeOfNode.
        ///</summary>
        public unsafe NodeType TypeOfNode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}
                return *(NodeType*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {}                *(NodeType*)targetPtr = value;
            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field GraphParent.
        ///</summary>
        public unsafe long GraphParent
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 1;
}                *(long*)targetPtr = value;
            }
        }
        StringAccessor GraphUri_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field GraphUri.
        ///</summary>
        public unsafe StringAccessor GraphUri
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 9;
}GraphUri_Accessor_Field.m_ptr = targetPtr + 4;
                GraphUri_Accessor_Field.m_cellId = this.m_cellId;
                return GraphUri_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                GraphUri_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 9;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != GraphUri_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    GraphUri_Accessor_Field.m_ptr = GraphUri_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, GraphUri_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        GraphUri_Accessor_Field.m_ptr = GraphUri_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, GraphUri_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field HashCode.
        ///</summary>
        public unsafe long HashCode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);}                *(long*)targetPtr = value;
            }
        }
        
        public static unsafe implicit operator INode(INode_Accessor accessor)
        {
            
            return new INode(
                
                        accessor.TypeOfNode,
                        accessor.GraphParent,
                        accessor.GraphUri,
                        accessor.HashCode
                );
        }
        
        public unsafe static implicit operator INode_Accessor(INode field)
        {
            byte* targetPtr = null;
            
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.GraphUri!= null)
        {
            int strlen_2 = field.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {
            *(NodeType*)targetPtr = field.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.GraphParent;
            targetPtr += 8;

        if(field.GraphUri!= null)
        {
            int strlen_2 = field.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.HashCode;
            targetPtr += 8;

            }INode_Accessor ret;
            
            ret = new INode_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(INode_Accessor a, INode_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (INode_Accessor a, INode_Accessor b)
        {
            return !(a == b);
        }
        
        /// <summary>
        /// Serializes this object to a Json string.
        /// </summary>
        /// <returns>The Json string serialized.</returns>
        public override string ToString()
        {
            return Serializer.ToString(this);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522
