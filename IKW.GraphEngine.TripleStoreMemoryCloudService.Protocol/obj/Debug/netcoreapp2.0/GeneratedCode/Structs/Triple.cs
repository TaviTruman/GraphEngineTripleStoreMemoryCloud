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
    /// A .NET runtime object representation of Triple defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Triple
    {
        
        ///<summary>
        ///Initializes a new instance of Triple with the specified parameters.
        ///</summary>
        public Triple(INode SubjectNode = default(INode),INode PredicateNode = default(INode),INode ObjectNode = default(INode),string Url = default(string),long GraphInstance = default(long),long HashCode = default(long),List<INode> Nodes = default(List<INode>))
        {
            
            this.SubjectNode = SubjectNode;
            
            this.PredicateNode = PredicateNode;
            
            this.ObjectNode = ObjectNode;
            
            this.Url = Url;
            
            this.GraphInstance = GraphInstance;
            
            this.HashCode = HashCode;
            
            this.Nodes = Nodes;
            
        }
        
        public static bool operator ==(Triple a, Triple b)
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
                
                (a.SubjectNode == b.SubjectNode)
                &&
                (a.PredicateNode == b.PredicateNode)
                &&
                (a.ObjectNode == b.ObjectNode)
                &&
                (a.Url == b.Url)
                &&
                (a.GraphInstance == b.GraphInstance)
                &&
                (a.HashCode == b.HashCode)
                &&
                (a.Nodes == b.Nodes)
                
                ;
            
        }
        public static bool operator !=(Triple a, Triple b)
        {
            return !(a == b);
        }
        
        public INode SubjectNode;
        
        public INode PredicateNode;
        
        public INode ObjectNode;
        
        public string Url;
        
        public long GraphInstance;
        
        public long HashCode;
        
        public List<INode> Nodes;
        
        /// <summary>
        /// Converts the string representation of a Triple to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(Triple) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out Triple value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<Triple>(input);
                return true;
            }
            catch { value = default(Triple); return false; }
        }
        public static Triple Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Triple>(input);
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
    /// Provides in-place operations of Triple defined in TSL.
    /// </summary>
    public unsafe partial class Triple_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe Triple_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    SubjectNode_Accessor_Field = new INode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        PredicateNode_Accessor_Field = new INode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        ObjectNode_Accessor_Field = new INode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        Url_Accessor_Field = new StringAccessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr, ptr_offset + substructure_offset, delta);
                    return this.m_ptr + substructure_offset;
                });        Nodes_Accessor_Field = new INode_AccessorListAccessor(null,
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
            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
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
            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        INode_Accessor SubjectNode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field SubjectNode.
        ///</summary>
        public unsafe INode_Accessor SubjectNode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}SubjectNode_Accessor_Field.m_ptr = targetPtr;
                SubjectNode_Accessor_Field.m_cellId = this.m_cellId;
                return SubjectNode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                SubjectNode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}
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
        INode_Accessor PredicateNode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field PredicateNode.
        ///</summary>
        public unsafe INode_Accessor PredicateNode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}PredicateNode_Accessor_Field.m_ptr = targetPtr;
                PredicateNode_Accessor_Field.m_cellId = this.m_cellId;
                return PredicateNode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                PredicateNode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
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
        INode_Accessor ObjectNode_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field ObjectNode.
        ///</summary>
        public unsafe INode_Accessor ObjectNode
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}ObjectNode_Accessor_Field.m_ptr = targetPtr;
                ObjectNode_Accessor_Field.m_cellId = this.m_cellId;
                return ObjectNode_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                ObjectNode_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
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
        StringAccessor Url_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Url.
        ///</summary>
        public unsafe StringAccessor Url
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}Url_Accessor_Field.m_ptr = targetPtr + 4;
                Url_Accessor_Field.m_cellId = this.m_cellId;
                return Url_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Url_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != Url_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    Url_Accessor_Field.m_ptr = Url_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, Url_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        Url_Accessor_Field.m_ptr = Url_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, Url_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        ///<summary>
        ///Provides in-place access to the object field GraphInstance.
        ///</summary>
        public unsafe long GraphInstance
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);}                *(long*)targetPtr = value;
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
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                return *(long*)(targetPtr);
                
            }
            set
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}                *(long*)targetPtr = value;
            }
        }
        INode_AccessorListAccessor Nodes_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field Nodes.
        ///</summary>
        public unsafe INode_AccessorListAccessor Nodes
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
}Nodes_Accessor_Field.m_ptr = targetPtr + 4;
                Nodes_Accessor_Field.m_cellId = this.m_cellId;
                return Nodes_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                Nodes_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
}
                int length = *(int*)(value.m_ptr - 4);
                int oldlength = *(int*)targetPtr;
                if (value.m_cellId != Nodes_Accessor_Field.m_cellId)
                {
                    //if not in the same Cell
                    Nodes_Accessor_Field.m_ptr = Nodes_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                    Memory.Copy(value.m_ptr - 4, Nodes_Accessor_Field.m_ptr, length + 4);
                }
                else
                {
                    byte[] tmpcell = new byte[length + 4];
                    fixed (byte* tmpcellptr = tmpcell)
                    {                        
                        Memory.Copy(value.m_ptr - 4, tmpcellptr, length + 4);
                        Nodes_Accessor_Field.m_ptr = Nodes_Accessor_Field.ResizeFunction(targetPtr, 0, length - oldlength);
                        Memory.Copy(tmpcellptr, Nodes_Accessor_Field.m_ptr, length + 4);
                    }
                }

            }
        }
        
        public static unsafe implicit operator Triple(Triple_Accessor accessor)
        {
            
            return new Triple(
                
                        accessor.SubjectNode,
                        accessor.PredicateNode,
                        accessor.ObjectNode,
                        accessor.Url,
                        accessor.GraphInstance,
                        accessor.HashCode,
                        accessor.Nodes
                );
        }
        
        public unsafe static implicit operator Triple_Accessor(Triple field)
        {
            byte* targetPtr = null;
            
            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.SubjectNode.GraphUri!= null)
        {
            int strlen_3 = field.SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.PredicateNode.GraphUri!= null)
        {
            int strlen_3 = field.PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.ObjectNode.GraphUri!= null)
        {
            int strlen_3 = field.ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field.Url!= null)
        {
            int strlen_2 = field.Url.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(field.Nodes!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.Nodes.Count;++iterator_2)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field.Nodes[iterator_2].GraphUri!= null)
        {
            int strlen_4 = field.Nodes[iterator_2].GraphUri.Length * 2;
            targetPtr += strlen_4+sizeof(int);
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
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {
            *(NodeType*)targetPtr = field.SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.SubjectNode.GraphParent;
            targetPtr += 8;

        if(field.SubjectNode.GraphUri!= null)
        {
            int strlen_3 = field.SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field.PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.PredicateNode.GraphParent;
            targetPtr += 8;

        if(field.PredicateNode.GraphUri!= null)
        {
            int strlen_3 = field.PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field.ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.ObjectNode.GraphParent;
            targetPtr += 8;

        if(field.ObjectNode.GraphUri!= null)
        {
            int strlen_3 = field.ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(field.Url!= null)
        {
            int strlen_2 = field.Url.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = field.Url)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = field.HashCode;
            targetPtr += 8;

{
byte *storedPtr_2 = targetPtr;

    targetPtr += sizeof(int);
    if(field.Nodes!= null)
    {
        for(int iterator_2 = 0;iterator_2<field.Nodes.Count;++iterator_2)
        {

            {
            *(NodeType*)targetPtr = field.Nodes[iterator_2].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field.Nodes[iterator_2].GraphParent;
            targetPtr += 8;

        if(field.Nodes[iterator_2].GraphUri!= null)
        {
            int strlen_4 = field.Nodes[iterator_2].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field.Nodes[iterator_2].GraphUri)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field.Nodes[iterator_2].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_2 = (int)(targetPtr - storedPtr_2 - 4);

}

            }Triple_Accessor ret;
            
            ret = new Triple_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Triple_Accessor a, Triple_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (Triple_Accessor a, Triple_Accessor b)
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
