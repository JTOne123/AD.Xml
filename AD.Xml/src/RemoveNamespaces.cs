﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace AD.Xml
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public static class RemoveNamespacesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static XElement RemoveNamespaces(this XElement element)
        {
            return
                new XElement(element.Name.LocalName,
                    element.Attributes()
                           .Where(x => !x.IsNamespaceDeclaration)
                           .Select(x => new XAttribute(x.Name.LocalName, x.Value)),
                    element.HasElements ? element.Elements().Select(x => x.RemoveNamespaces()) : element.Value as object);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> RemoveNamespaces(this IEnumerable<XElement> elements)
        {
            return elements.Select(x => x.RemoveNamespaces());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static ParallelQuery<XElement> RemoveNamespaces(this ParallelQuery<XElement> elements)
        {
            return elements.Select(x => x.RemoveNamespaces());
        }
    }
}
