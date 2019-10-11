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
    /// A .NET runtime object representation of DateTimeNode defined in TSL.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct DateTimeNode
    {
        
        ///<summary>
        ///Initializes a new instance of DateTimeNode with the specified parameters.
        ///</summary>
        public DateTimeNode(DateTime DateTimeValue = default(DateTime))
        {
            
            this.DateTimeValue = DateTimeValue;
            
        }
        
        public static bool operator ==(DateTimeNode a, DateTimeNode b)
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
                
                (a.DateTimeValue == b.DateTimeValue)
                
                ;
            
        }
        public static bool operator !=(DateTimeNode a, DateTimeNode b)
        {
            return !(a == b);
        }
        
        public DateTime DateTimeValue;
        
        /// <summary>
        /// Converts the string representation of a DateTimeNode to its
        /// struct equivalent. A return value indicates whether the 
        /// operation succeeded.
        /// </summary>
        /// <param name="input">A string to convert.</param>
        /// <param name="value">
        /// When this method returns, contains the struct equivalent of the value contained 
        /// in input, if the conversion succeeded, or default(DateTimeNode) if the conversion
        /// failed. The conversion fails if the input parameter is null or String.Empty, or is 
        /// not of the correct format. This parameter is passed uninitialized. 
        /// </param>
        /// <returns>True if input was converted successfully; otherwise, false.</returns>
        public unsafe static bool TryParse(string input, out DateTimeNode value)
        {
            try
            {
                value = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTimeNode>(input);
                return true;
            }
            catch { value = default(DateTimeNode); return false; }
        }
        public static DateTimeNode Parse(string input)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DateTimeNode>(input);
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
    /// Provides in-place operations of DateTimeNode defined in TSL.
    /// </summary>
    public unsafe partial class DateTimeNode_Accessor : IAccessor
    {
        ///<summary>
        ///The pointer to the content of the object.
        ///</summary>
        internal byte* m_ptr;
        internal long m_cellId;
        internal unsafe DateTimeNode_Accessor(byte* _CellPtr
            )
        {
            m_ptr = _CellPtr;
            
            ResizeFunction = (a,b,c) => { return Throw.invalid_resize_on_fixed_struct(); };
                    DateTimeValue_Accessor_Field = new DateTimeAccessor(null);
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
            {            targetPtr += 8;
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
            {            targetPtr += 8;
}
            int size = (int)(targetPtr - m_ptr);
            return size;
        }
        public ResizeFunctionDelegate ResizeFunction { get; set; }
        #endregion
        DateTimeAccessor DateTimeValue_Accessor_Field;
        
        ///<summary>
        ///Provides in-place access to the object field DateTimeValue.
        ///</summary>
        public unsafe DateTimeAccessor DateTimeValue
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                {}DateTimeValue_Accessor_Field.m_ptr = targetPtr;
                DateTimeValue_Accessor_Field.m_cellId = this.m_cellId;
                return DateTimeValue_Accessor_Field;
                
            }
            set
            {
                
                if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                DateTimeValue_Accessor_Field.m_cellId = this.m_cellId;
                
                byte* targetPtr = m_ptr;
                {}                Memory.Copy(value.m_ptr, targetPtr, 8); 
            }
        }
        
        public static unsafe implicit operator DateTimeNode(DateTimeNode_Accessor accessor)
        {
            
            return new DateTimeNode(
                
                        accessor.DateTimeValue
                );
        }
        
        public unsafe static implicit operator DateTimeNode_Accessor(DateTimeNode field)
        {
            byte* targetPtr = null;
            targetPtr += 8;

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
            {

        {
            *(long*)targetPtr = field.DateTimeValue.ToBinary();
            targetPtr += 8;
        }

            }DateTimeNode_Accessor ret;
            
            ret = new DateTimeNode_Accessor(tmpcellptr);
            
            return ret;
        }
        
        public static bool operator ==(DateTimeNode_Accessor a, DateTimeNode_Accessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            byte* targetPtr = a.m_ptr;
            {            targetPtr += 8;
}
            int lengthA = (int)(targetPtr - a.m_ptr);
            targetPtr = b.m_ptr;
            {            targetPtr += 8;
}
            int lengthB = (int)(targetPtr - b.m_ptr);
            if(lengthA != lengthB) return false;
            return Memory.Compare(a.m_ptr,b.m_ptr,lengthA);
        }
        public static bool operator != (DateTimeNode_Accessor a, DateTimeNode_Accessor b)
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
