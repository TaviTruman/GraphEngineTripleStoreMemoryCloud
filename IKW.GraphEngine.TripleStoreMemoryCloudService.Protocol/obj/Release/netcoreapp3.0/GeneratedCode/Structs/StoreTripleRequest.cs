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
    /// A .NET runtime object representation of StoreTripleRequest defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct StoreTripleRequest
    {
        
        ///<summary>
        ///Initializes a new instance of StoreTripleRequest with the specified parameters.
        ///</summary>
        public StoreTripleRequest(TripleStatement RDFTriple = default(TripleStatement))
        {
            
            this.RDFTriple = RDFTriple;
            
        }
        
        public static bool operator ==(StoreTripleRequest a, StoreTripleRequest b)
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
                
                (a.RDFTriple == b.RDFTriple)
                
                ;
            
        }
        public static bool operator !=(StoreTripleRequest a, StoreTripleRequest b)
        {
            return !(a == b);
        }
        
        public TripleStatement RDFTriple;
        
        /// <summary>
        /// Converts the string representation of a StoreTripleRequest to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(StoreTripleRequest) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out StoreTripleRequest value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<StoreTripleRequest>(input);
                return true;
            }
            catch { value = default(StoreTripleRequest); return false; }
        }
        public static StoreTripleRequest Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<StoreTripleRequest>(input);
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
    /// Provides in-place operations of StoreTripleRequest defined in TSL.
    /// </summary>
    public unsafe partial class StoreTripleRequest_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe StoreTripleRequest_Accessor(byte* _CellPtr
            
            , ResizeFunctionDelegate func
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = func;
                    RDFTriple_Accessor_Field = new TripleStatement_Accessor(null,
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
            {{            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
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
            {{            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        TripleStatement_Accessor RDFTriple_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field RDFTriple.
        ///</summary>
        public unsafe TripleStatement_Accessor RDFTriple
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}RDFTriple_Accessor_Field.m_ptr = targetPtr;
                RDFTriple_Accessor_Field.m_cellId = this.m_cellId;
                return RDFTriple_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                RDFTriple_Accessor_Field.m_cellId = this.m_cellId;
                
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
        
        public static unsafe implicit operator StoreTripleRequest(StoreTripleRequest_Accessor accessor)
        {
            
            return new StoreTripleRequest(
                
                        accessor.RDFTriple
                );
        }
        
        public unsafe static implicit operator StoreTripleRequest_Accessor(StoreTripleRequest field)
        {
            byte* targetPtr = null;
            
            {

            {
targetPtr += 16;
        if(field.RDFTriple.Subject!= null)
        {
            int strlen_3 = field.RDFTriple.Subject.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.RDFTriple.Predicate!= null)
        {
            int strlen_3 = field.RDFTriple.Predicate.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

        if(field.RDFTriple.Object!= null)
        {
            int strlen_3 = field.RDFTriple.Object.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }

            }
            }
            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

            {

        {
            byte[] tmpGuid = field.RDFTriple.RefId.ToByteArray();
            fixed(byte* tmpGuidPtr = tmpGuid)
            {
                Memory.Copy(tmpGuidPtr, targetPtr, 16);
            }
            targetPtr += 16;
        }

        if(field.RDFTriple.Subject!= null)
        {
            int strlen_3 = field.RDFTriple.Subject.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.RDFTriple.Subject)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.RDFTriple.Predicate!= null)
        {
            int strlen_3 = field.RDFTriple.Predicate.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.RDFTriple.Predicate)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

        if(field.RDFTriple.Object!= null)
        {
            int strlen_3 = field.RDFTriple.Object.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field.RDFTriple.Object)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }

            }
            }StoreTripleRequest_Accessor ret;
            
            ret = new StoreTripleRequest_Accessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(StoreTripleRequest_Accessor a, StoreTripleRequest_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {{            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {{            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);targetPtr += *(int*)targetPtr + sizeof(int);}}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (StoreTripleRequest_Accessor a, StoreTripleRequest_Accessor b)
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
