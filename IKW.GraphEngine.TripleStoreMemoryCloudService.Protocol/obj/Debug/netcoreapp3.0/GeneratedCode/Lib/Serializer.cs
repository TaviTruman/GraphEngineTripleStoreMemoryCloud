#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace InKnowWorks.TripleStoreMemoryCloud.Protocols.TSL
{
    /// <summary>
    /// Provides facilities for serializing data to Json strings.
    /// </summary>
    public class Serializer
    {
        [ThreadStatic]
        static StringBuilder s_stringBuilder;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void s_ensure_string_builder()
        {
            if (s_stringBuilder == null)
                s_stringBuilder = new StringBuilder();
            else
                s_stringBuilder.Clear();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a long object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(long value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Guid object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Guid value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a string object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(string value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<string> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<string> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<INode> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<INode> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a List<Triple> object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(List<Triple> value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a INode object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(INode value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a StoreTripleRequest object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(StoreTripleRequest value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a StoreTripleResponse object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(StoreTripleResponse value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a Triple object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Triple value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a TripleStatement object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(TripleStatement value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>
        /// Serializes a NodeType object to Json string.
        /// </summary>
        /// <param name="value">The target object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(NodeType value)
        {
            s_ensure_string_builder();
            ToString_impl(value, s_stringBuilder, in_json: false);
            return s_stringBuilder.ToString();
        }
        
        /// <summary>
        /// Serializes a Graph object to Json string.
        /// </summary>
        /// <param name="value">The target cell object to be serialized.</param>
        /// <returns>The serialized Json string.</returns>
        public static string ToString(Graph cell)
        {
            s_ensure_string_builder();
            s_stringBuilder.Append('{');
            s_stringBuilder.AppendFormat("\"CellId\":{0}", cell.CellId);
            
            {
                
                if (cell.BaseUri != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"BaseUri\":");
                    ToString_impl(cell.BaseUri, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            {
                
                if (cell.TripleCollection != null)
                {
                    
                    s_stringBuilder.Append(',');
                    s_stringBuilder.Append("\"TripleCollection\":");
                    ToString_impl(cell.TripleCollection, s_stringBuilder, in_json: true);
                    
                }
                
            }
            
            s_stringBuilder.Append('}');
            return s_stringBuilder.ToString();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(long value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                {
                    str_builder.Append(value);
                }
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Guid value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(string value, StringBuilder str_builder, bool in_json)
        {
            
            if (in_json)
            {
                str_builder.Append(JsonStringProcessor.escape(value));
            }
            else
            {
                str_builder.Append(value);
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<string> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<INode> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(List<Triple> value, StringBuilder str_builder, bool in_json)
        {
            
            {
                str_builder.Append('[');
                bool first = true;
                foreach (var element in value)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        str_builder.Append(',');
                    }
                    ToString_impl(element, str_builder, in_json:true);
                }
                str_builder.Append(']');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(INode value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"TypeOfNode\":");
                        
                        ToString_impl(value.TypeOfNode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"GraphParent\":");
                        
                        ToString_impl(value.GraphParent, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.GraphUri != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"GraphUri\":");
                        
                        ToString_impl(value.GraphUri, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"HashCode\":");
                        
                        ToString_impl(value.HashCode, str_builder, in_json: true);
                        
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(StoreTripleRequest value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"RefId\":");
                        
                        ToString_impl(value.RefId, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Subject != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Subject\":");
                        
                        ToString_impl(value.Subject, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Predicate != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Predicate\":");
                        
                        ToString_impl(value.Predicate, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Object != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Object\":");
                        
                        ToString_impl(value.Object, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(StoreTripleResponse value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"RefId\":");
                        
                        ToString_impl(value.RefId, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Subject != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Subject\":");
                        
                        ToString_impl(value.Subject, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Predicate != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Predicate\":");
                        
                        ToString_impl(value.Predicate, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Object != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Object\":");
                        
                        ToString_impl(value.Object, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(Triple value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"SubjectNode\":");
                        
                        ToString_impl(value.SubjectNode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"PredicateNode\":");
                        
                        ToString_impl(value.PredicateNode, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"ObjectNode\":");
                        
                        ToString_impl(value.ObjectNode, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Url != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Url\":");
                        
                        ToString_impl(value.Url, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"GraphInstance\":");
                        
                        ToString_impl(value.GraphInstance, str_builder, in_json: true);
                        
                }
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"HashCode\":");
                        
                        ToString_impl(value.HashCode, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Nodes != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Nodes\":");
                        
                        ToString_impl(value.Nodes, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(TripleStatement value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                str_builder.Append('{');
                bool first_field = true;
                
                {
                    
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"RefId\":");
                        
                        ToString_impl(value.RefId, str_builder, in_json: true);
                        
                }
                
                {
                    
                    if (value.Subject != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Subject\":");
                        
                        ToString_impl(value.Subject, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Predicate != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Predicate\":");
                        
                        ToString_impl(value.Predicate, str_builder, in_json: true);
                        
                    }
                    
                }
                
                {
                    
                    if (value.Object != null)
                    
                    {
                        
                        if(first_field)
                            first_field = false;
                        else
                            str_builder.Append(',');
                        str_builder.Append("\"Object\":");
                        
                        ToString_impl(value.Object, str_builder, in_json: true);
                        
                    }
                    
                }
                
                str_builder.Append('}');
            }
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ToString_impl(NodeType value, StringBuilder str_builder, bool in_json)
        {
            
            {
                
                if(in_json)
                    str_builder.Append('"');
                
                {
                    str_builder.Append(value);
                }
                
                if(in_json)
                    str_builder.Append('"');
                
            }
            
        }
        
        #region mute
        
        #endregion
    }
}

#pragma warning restore 162,168,649,660,661,1522
