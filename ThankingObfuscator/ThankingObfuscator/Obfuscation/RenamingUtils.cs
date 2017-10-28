﻿using dnlib.DotNet;
using System;
using System.Linq;

namespace SymbolRenamer.SymbolRenaming
{
    public static class RenamingUtils
    {

        /// <summary>
        /// Determines whether the object has the specified custom attribute.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="fullName">The full name of the type of custom attribute.</param>
        /// <returns><c>true</c> if the specified object has custom attribute; otherwise, <c>false</c>.</returns>
        public static bool HasAttribute(this IHasCustomAttribute obj, string fullName)
        {
            return obj.CustomAttributes.Any(attr => attr.TypeFullName == fullName);
        }

        /// <summary>
        /// Determines whether the specified type is COM import.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if specified type is COM import; otherwise, <c>false</c>.</returns>
        public static bool IsComImport(this TypeDef type)
        {
            return type.IsImport ||
                   type.HasAttribute("System.Runtime.InteropServices.ComImportAttribute") ||
                   type.HasAttribute("System.Runtime.InteropServices.TypeLibTypeAttribute");
        }

        /// <summary>
		/// Determines whether the specified type is a delegate.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if the specified type is a delegate; otherwise, <c>false</c>.</returns>
		public static bool IsDelegate(this TypeDef type)
        {
            if (type.BaseType == null)
                return false;

            string fullName = type.BaseType.FullName;
            return fullName == "System.Delegate" || fullName == "System.MulticastDelegate";
        }

        /// <summary>
        /// Determines whether the specified type is inherited from a base type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="baseType">The full name of base type.</param>
        /// <returns><c>true</c> if the specified type is inherited from a base type; otherwise, <c>false</c>.</returns>
        public static bool InheritsFrom(this TypeDef type, string baseType)
        {
            if (type.BaseType == null)
                return false;

            TypeDef bas = type;
            do
            {
                try
                {
                    bas = bas.BaseType.ResolveTypeDefThrow();
                    if (bas.ReflectionFullName == baseType)
                        return true;
                }
                catch (TypeResolveException)
                {
                    return false;
                }

            } while (bas.BaseType != null);
            return false;
        }


        /// <summary>
		/// Determines whether the specified type implements the specified interface.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="fullName">The full name of the type of interface.</param>
		/// <returns><c>true</c> if the specified type implements the interface; otherwise, <c>false</c>.</returns>
		public static bool Implements(this TypeDef type, string fullName)
        {
            do
            {
                foreach (InterfaceImpl iface in type.Interfaces)
                {
                    if (iface.Interface.ReflectionFullName == fullName)
                        return true;
                }

                if (type.BaseType == null)
                    return false;
                try
                {
                    type = type.BaseType.ResolveTypeDefThrow();
                }
                catch (TypeResolveException)
                {
                    return false;
                }
            } while (type != null);
            throw new Exception("Should not be reached.");
        }


    }
}
