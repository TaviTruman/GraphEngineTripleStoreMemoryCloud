#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Trinity.Core.Lib;
using Trinity.TSL;
using Trinity.TSL.Lib;

namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    public unsafe class Triple_AccessorListAccessor : IEnumerable<Triple_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal Triple_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new Triple_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        Triple_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe Triple_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
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
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<Triple_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<Triple_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            Triple_AccessorListAccessor target;
            internal _iterator(Triple_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal Triple_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                }
                
            }
        }
        public IEnumerator<Triple_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(Triple element)
        {
            byte* targetPtr = null;
            {
                
            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {

            {
            *(NodeType*)targetPtr = element.SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.SubjectNode.GraphParent;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.PredicateNode.GraphParent;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.ObjectNode.GraphParent;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.Url)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            *(NodeType*)targetPtr = element.Nodes[iterator_1].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.Nodes[iterator_1].GraphParent;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.Nodes[iterator_1].GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.Nodes[iterator_1].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, Triple element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

            {
            *(NodeType*)targetPtr = element.SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.SubjectNode.GraphParent;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.PredicateNode.GraphParent;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.ObjectNode.GraphParent;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.Url)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            *(NodeType*)targetPtr = element.Nodes[iterator_1].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.Nodes[iterator_1].GraphParent;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.Nodes[iterator_1].GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.Nodes[iterator_1].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(Triple element, Comparison<Triple_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_2+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
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
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {

            {
            *(NodeType*)targetPtr = element.SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.SubjectNode.GraphParent;
            targetPtr += 8;

        if(element.SubjectNode.GraphUri!= null)
        {
            int strlen_2 = element.SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.PredicateNode.GraphParent;
            targetPtr += 8;

        if(element.PredicateNode.GraphUri!= null)
        {
            int strlen_2 = element.PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = element.ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.ObjectNode.GraphParent;
            targetPtr += 8;

        if(element.ObjectNode.GraphUri!= null)
        {
            int strlen_2 = element.ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_2;
            targetPtr += sizeof(int);
            fixed(char* pstr_2 = element.ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_2, targetPtr, strlen_2);
                targetPtr += strlen_2;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(element.Url!= null)
        {
            int strlen_1 = element.Url.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.Url)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(element.Nodes!= null)
    {
        for(int iterator_1 = 0;iterator_1<element.Nodes.Count;++iterator_1)
        {

            {
            *(NodeType*)targetPtr = element.Nodes[iterator_1].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.Nodes[iterator_1].GraphParent;
            targetPtr += 8;

        if(element.Nodes[iterator_1].GraphUri!= null)
        {
            int strlen_3 = element.Nodes[iterator_1].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = element.Nodes[iterator_1].GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.Nodes[iterator_1].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<Triple> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            Triple_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(Triple_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(Triple_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<Triple_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(Triple[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(Triple[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, Triple[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<Triple> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            Triple_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}{            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 16;
targetPtr += *(int*)targetPtr + sizeof(int);}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<Triple> (Triple_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<Triple> list = new List<Triple>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator Triple_AccessorListAccessor(List<Triple> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field[iterator_1].SubjectNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].SubjectNode.GraphUri.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field[iterator_1].PredicateNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].PredicateNode.GraphUri.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            {
            targetPtr += 1;
            targetPtr += 8;

        if(field[iterator_1].ObjectNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].ObjectNode.GraphUri.Length * 2;
            targetPtr += strlen_4+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        if(field[iterator_1].Url!= null)
        {
            int strlen_3 = field[iterator_1].Url.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;
            targetPtr += 8;

{

    targetPtr += sizeof(int);
    if(field[iterator_1].Nodes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].Nodes.Count;++iterator_3)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field[iterator_1].Nodes[iterator_3].GraphUri!= null)
        {
            int strlen_5 = field[iterator_1].Nodes[iterator_3].GraphUri.Length * 2;
            targetPtr += strlen_5+sizeof(int);
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

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {

            {
            *(NodeType*)targetPtr = field[iterator_1].SubjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field[iterator_1].SubjectNode.GraphParent;
            targetPtr += 8;

        if(field[iterator_1].SubjectNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].SubjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].SubjectNode.GraphUri)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].SubjectNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field[iterator_1].PredicateNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field[iterator_1].PredicateNode.GraphParent;
            targetPtr += 8;

        if(field[iterator_1].PredicateNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].PredicateNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].PredicateNode.GraphUri)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].PredicateNode.HashCode;
            targetPtr += 8;

            }
            {
            *(NodeType*)targetPtr = field[iterator_1].ObjectNode.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field[iterator_1].ObjectNode.GraphParent;
            targetPtr += 8;

        if(field[iterator_1].ObjectNode.GraphUri!= null)
        {
            int strlen_4 = field[iterator_1].ObjectNode.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_4;
            targetPtr += sizeof(int);
            fixed(char* pstr_4 = field[iterator_1].ObjectNode.GraphUri)
            {
                Memory.Copy(pstr_4, targetPtr, strlen_4);
                targetPtr += strlen_4;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].ObjectNode.HashCode;
            targetPtr += 8;

            }
        if(field[iterator_1].Url!= null)
        {
            int strlen_3 = field[iterator_1].Url.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].Url)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].GraphInstance;
            targetPtr += 8;
            *(long*)targetPtr = field[iterator_1].HashCode;
            targetPtr += 8;

{
byte *storedPtr_3 = targetPtr;

    targetPtr += sizeof(int);
    if(field[iterator_1].Nodes!= null)
    {
        for(int iterator_3 = 0;iterator_3<field[iterator_1].Nodes.Count;++iterator_3)
        {

            {
            *(NodeType*)targetPtr = field[iterator_1].Nodes[iterator_3].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field[iterator_1].Nodes[iterator_3].GraphParent;
            targetPtr += 8;

        if(field[iterator_1].Nodes[iterator_3].GraphUri!= null)
        {
            int strlen_5 = field[iterator_1].Nodes[iterator_3].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_5;
            targetPtr += sizeof(int);
            fixed(char* pstr_5 = field[iterator_1].Nodes[iterator_3].GraphUri)
            {
                Memory.Copy(pstr_5, targetPtr, strlen_5);
                targetPtr += strlen_5;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].Nodes[iterator_3].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_3 = (int)(targetPtr - storedPtr_3 - 4);

}

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
Triple_AccessorListAccessor ret;
            
            ret = new Triple_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(Triple_AccessorListAccessor a, Triple_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(Triple_AccessorListAccessor a, Triple_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    
    public unsafe class INode_AccessorListAccessor : IEnumerable<INode_Accessor>
    {
        internal byte* m_ptr;
        internal long m_cellId;
        internal ResizeFunctionDelegate ResizeFunction;
        internal INode_AccessorListAccessor(byte* _CellPtr, ResizeFunctionDelegate func)
        {
            m_ptr = _CellPtr;
            ResizeFunction = func;
            m_ptr += 4;
                    elementAccessor = new INode_Accessor(null,
                (ptr,ptr_offset,delta)=>
                {
                    int substructure_offset = (int)(ptr - this.m_ptr);
                    this.m_ptr = this.ResizeFunction(this.m_ptr-sizeof(int), ptr_offset + substructure_offset +sizeof(int), delta);
                    *(int*)this.m_ptr += delta;
                    this.m_ptr += sizeof(int);
                    return this.m_ptr + substructure_offset;
                });
        }
        internal int length
        {
            get
            {
                return *(int*)(m_ptr - 4);
            }
        }
        INode_Accessor elementAccessor;
        
        /// <summary>
        /// Gets the number of elements actually contained in the List. 
        /// </summary>";
        public unsafe int Count
        {
            get
            {
                
                byte* targetPtr = m_ptr;
                byte* endPtr = m_ptr + length;
                int ret = 0;
                while (targetPtr < endPtr)
                {
                    {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                    ++ret;
                }
                return ret;
                
            }
        }
        /// <summary>
        /// Gets or sets the element at the specified index. 
        /// </summary>
        /// <param name="index">Given index</param>
        /// <returns>Corresponding element at the specified index</returns>";
        public unsafe INode_Accessor this[int index]
        {
            get
            {
                
                {
                    
                    {
                        byte* targetPtr = m_ptr;
                        while (index-- > 0)
                        {
                            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                        }
                        
                        elementAccessor.m_ptr = targetPtr;
                        
                    }
                    
                    elementAccessor.m_cellId = this.m_cellId;
                    return elementAccessor;
                }
                
            }
            set
            {
                
                {
                    if ((object)value == null) throw new ArgumentNullException("The assigned variable is null.");
                    elementAccessor.m_cellId = this.m_cellId;
                    byte* targetPtr = m_ptr;
                    
                    while (index-- > 0)
                    {
                        {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
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
        }
        /// <summary>
        /// Copies the elements to a new byte array
        /// </summary>
        /// <returns>Elements compactly arranged in a byte array.</returns>
        public unsafe byte[] ToByteArray()
        {
            byte[] ret = new byte[length];
            fixed (byte* retptr = ret)
            {
                Memory.Copy(m_ptr, retptr, length);
                return ret;
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has one parameter indicates element in List</param>
        public unsafe void ForEach(Action<INode_Accessor> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            
            elementAccessor.m_cellId = this.m_cellId;
            
            while (targetPtr < endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor);
                    {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                }
                
            }
        }
        /// <summary>
        /// Performs the specified action on each elements
        /// </summary>
        /// <param name="action">A lambda expression which has two parameters. First indicates element in the List and second the index of this element.</param>
        public unsafe void ForEach(Action<INode_Accessor, int> action)
        {
            byte* targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            for (int index = 0; targetPtr < endPtr; ++index)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr;
                    action(elementAccessor, index);
                    {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                }
                
            }
        }
        internal unsafe struct _iterator
        {
            byte* targetPtr;
            byte* endPtr;
            INode_AccessorListAccessor target;
            internal _iterator(INode_AccessorListAccessor target)
            {
                targetPtr = target.m_ptr;
                endPtr = targetPtr + target.length;
                this.target = target;
            }
            internal bool good()
            {
                return (targetPtr < endPtr);
            }
            internal INode_Accessor current()
            {
                
                {
                    target.elementAccessor.m_ptr = targetPtr;
                    return target.elementAccessor;
                }
                
            }
            internal void move_next()
            {
                 
                {
                    {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                }
                
            }
        }
        public IEnumerator<INode_Accessor> GetEnumerator()
        {
            _iterator _it = new _iterator(this);
            while (_it.good())
            {
                yield return _it.current();
                _it.move_next();
            }
        }
        unsafe IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Adds an item to the end of the List
        /// </summary>
        /// <param name="element">The object to be added to the end of the List.</param>
        public unsafe void Add(INode element)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            int size = (int)targetPtr;
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), *(int*)(this.m_ptr-sizeof(int))+sizeof(int), size);
            targetPtr = this.m_ptr + (*(int*)this.m_ptr)+sizeof(int);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            
            {
            *(NodeType*)targetPtr = element.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.GraphParent;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.GraphUri)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

            }
        }
        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="element">The object to insert.</param>
        public unsafe void Insert(int index, INode element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            }
            
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            *(NodeType*)targetPtr = element.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.GraphParent;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.GraphUri)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

            }
        }
        /// <summary>
        /// Inserts an element into a sorted list.
        /// </summary>
        /// <param name="element">The object to insert.</param>
        /// <param name="comparison"></param>
        public unsafe void Insert(INode element, Comparison<INode_Accessor> comparison)
        {
            byte* targetPtr = null;
            {
                
            {
            targetPtr += 1;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            targetPtr += strlen_1+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
            }
            int size = (int)targetPtr;
            targetPtr = m_ptr;
            byte* endPtr = m_ptr + length;
            while (targetPtr<endPtr)
            {
                
                {
                    elementAccessor.m_ptr = targetPtr + 4;
                    if (comparison(elementAccessor, element)<=0)
                    {
                        {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            int offset = (int)(targetPtr - m_ptr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
            targetPtr = this.m_ptr + offset;
            
            {
            *(NodeType*)targetPtr = element.TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = element.GraphParent;
            targetPtr += 8;

        if(element.GraphUri!= null)
        {
            int strlen_1 = element.GraphUri.Length * 2;
            *(int*)targetPtr = strlen_1;
            targetPtr += sizeof(int);
            fixed(char* pstr_1 = element.GraphUri)
            {
                Memory.Copy(pstr_1, targetPtr, strlen_1);
                targetPtr += strlen_1;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = element.HashCode;
            targetPtr += 8;

            }
        }
        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public unsafe void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            int size = (int)(oldtargetPtr - targetPtr);
            this.m_ptr = this.ResizeFunction(this.m_ptr - sizeof(int), offset + sizeof(int), size);
            *(int*)this.m_ptr += size;
            this.m_ptr += sizeof(int);
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(List<INode> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            INode_AccessorListAccessor tcollection = collection;
            int delta = tcollection.length;
            m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
            Memory.Copy(tcollection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
            *(int*)m_ptr += delta;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Adds the elements of the specified collection to the end of the List
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be null.</param>
        public unsafe void AddRange(INode_AccessorListAccessor collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            int delta = collection.length;
            if (collection.m_cellId != m_cellId)
            {
                m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                Memory.Copy(collection.m_ptr, m_ptr + *(int*)m_ptr + 4, delta);
                *(int*)m_ptr += delta;
            }
            else
            {
                byte[] tmpcell = new byte[delta];
                fixed (byte* tmpcellptr = tmpcell)
                {
                    Memory.Copy(collection.m_ptr, tmpcellptr, delta);
                    m_ptr = ResizeFunction(m_ptr - 4, *(int*)(m_ptr - 4) + 4, delta);
                    Memory.Copy(tmpcellptr, m_ptr + *(int*)m_ptr + 4, delta);
                    *(int*)m_ptr += delta;
                }
            }
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes all elements from the List
        /// </summary>
        public unsafe void Clear()
        {
            int delta = length;
            Memory.memset(m_ptr, 0, (ulong)delta);
            m_ptr = ResizeFunction(m_ptr - 4, 4, -delta);
            *(int*)m_ptr = 0;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Determines whether an element is in the List
        /// </summary>
        /// <param name="item">The object to locate in the List.The value can be null for non-atom types</param>
        /// <returns>true if item is found in the List; otherwise, false.</returns>
        public unsafe bool Contains(INode_Accessor item)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (item == x) ret = true;
            });
            return ret;
        }
        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>true if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.</returns>
        public unsafe bool Exists(Predicate<INode_Accessor> match)
        {
            bool ret = false;
            ForEach(x =>
            {
                if (match(x)) ret = true;
            });
            return ret;
        }
        
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        public unsafe void CopyTo(INode[] array)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (array.Length < Count) throw new ArgumentException("The number of elements in the source List is greater than the number of elements that the destination array can contain.");
            ForEach((x, i) => array[i] = x);
        }
        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public unsafe void CopyTo(INode[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0.");
            if (array.Length - arrayIndex < Count) throw new ArgumentException("The number of elements in the source List is greater than the available space from arrayIndex to the end of the destination array.");
            ForEach((x, i) => array[i + arrayIndex] = x);
        }
        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the ptr1 array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>;
        /// <param name="count">The number of elements to copy.</param>
        public unsafe void CopyTo(int index, INode[] array, int arrayIndex, int count)
        {
            if (array == null) throw new ArgumentNullException("array is null.");
            if (arrayIndex < 0 || index < 0 || count < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than 0 or index is less than 0 or count is less than 0.");
            if (array.Length - arrayIndex < count) throw new ArgumentException("The number of elements from index to the end of the source List is greater than the available space from arrayIndex to the end of the destination array. ");
            if (index + count > Count) throw new ArgumentException("Source list does not have enough elements to copy.");
            int j = 0;
            for (int i = index; i < index + count; i++)
            {
                array[j + arrayIndex] = this[i];
                ++j;
            }
        }
          
        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public unsafe void InsertRange(int index, List<INode> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection is null.");
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            INode_AccessorListAccessor tmpAccessor = collection;
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            }
            int offset = (int)(targetPtr - m_ptr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, tmpAccessor.length);
            Memory.Copy(tmpAccessor.m_ptr, m_ptr + offset + 4, tmpAccessor.length);
            *(int*)m_ptr += tmpAccessor.length;
            this.m_ptr += 4;
        }
        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public unsafe void RemoveRange(int index, int count)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("index is less than 0.");
            if (index > Count) throw new ArgumentOutOfRangeException("index is greater than Count.");
            if (index + count > Count) throw new ArgumentException("index and count do not denote a valid range of elements in the List.");
            byte* targetPtr = m_ptr;
            for (int i = 0; i < index; i++)
            {
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            }
            int offset = (int)(targetPtr - m_ptr);
            byte* oldtargetPtr = targetPtr;
            for (int i = 0; i < count; i++)
            {
                {            targetPtr += 9;
targetPtr += *(int*)targetPtr + sizeof(int);            targetPtr += 8;
}
            }
            int size = (int)(oldtargetPtr - targetPtr);
            m_ptr = ResizeFunction(m_ptr - 4, offset + 4, size);
            *(int*)m_ptr += size;
            this.m_ptr += 4;
        }
        public unsafe static implicit operator List<INode> (INode_AccessorListAccessor accessor)
        {
            if((object)accessor == null) return null;
            List<INode> list = new List<INode>();
            accessor.ForEach(element => list.Add(element));
            return list;
        }
        
        public unsafe static implicit operator INode_AccessorListAccessor(List<INode> field)
        {
            byte* targetPtr = null;
            
{

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            targetPtr += 1;
            targetPtr += 8;

        if(field[iterator_1].GraphUri!= null)
        {
            int strlen_3 = field[iterator_1].GraphUri.Length * 2;
            targetPtr += strlen_3+sizeof(int);
        }else
        {
            targetPtr += sizeof(int);
        }
            targetPtr += 8;

            }
        }
    }

}

            byte* tmpcellptr = BufferAllocator.AllocBuffer((int)targetPtr);
            Memory.memset(tmpcellptr, 0, (ulong)targetPtr);
            targetPtr = tmpcellptr;
            
{
byte *storedPtr_1 = targetPtr;

    targetPtr += sizeof(int);
    if(field!= null)
    {
        for(int iterator_1 = 0;iterator_1<field.Count;++iterator_1)
        {

            {
            *(NodeType*)targetPtr = field[iterator_1].TypeOfNode;
            targetPtr += 1;
            *(long*)targetPtr = field[iterator_1].GraphParent;
            targetPtr += 8;

        if(field[iterator_1].GraphUri!= null)
        {
            int strlen_3 = field[iterator_1].GraphUri.Length * 2;
            *(int*)targetPtr = strlen_3;
            targetPtr += sizeof(int);
            fixed(char* pstr_3 = field[iterator_1].GraphUri)
            {
                Memory.Copy(pstr_3, targetPtr, strlen_3);
                targetPtr += strlen_3;
            }
        }else
        {
            *(int*)targetPtr = 0;
            targetPtr += sizeof(int);
        }
            *(long*)targetPtr = field[iterator_1].HashCode;
            targetPtr += 8;

            }
        }
    }
*(int*)storedPtr_1 = (int)(targetPtr - storedPtr_1 - 4);

}
INode_AccessorListAccessor ret;
            
            ret = new INode_AccessorListAccessor(tmpcellptr, null);
            
            return ret;
        }
        
        public static bool operator ==(INode_AccessorListAccessor a, INode_AccessorListAccessor b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            if (a.m_ptr == b.m_ptr) return true;
            if (a.length != b.length) return false;
            return Memory.Compare(a.m_ptr, b.m_ptr, a.length);
        }
        public static bool operator !=(INode_AccessorListAccessor a, INode_AccessorListAccessor b)
        {
            return !(a == b);
        }
    }
}

#pragma warning restore 162,168,649,660,661,1522
