using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;

namespace LupinUtils.Collections
{
    public static class CollectionsUtils 
    {
        /// <summary>
        /// returns random element
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Random element</returns>
        public static T RandomElement<T>(this ICollection<T> collection)
        {
            if (collection==null ||collection.Count == 0) return default(T);
            return collection.ElementAt(UnityEngine.Random.Range(0, collection.Count));
        }
        
        /// <summary>
        /// returns random element (System random)
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="systemRandom">System random</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Random element</returns>
        public static T RandomElement<T>(this ICollection<T> collection, System.Random systemRandom)
        {
            if (collection==null ||collection.Count == 0) return default(T);
            return collection.ElementAt(systemRandom.Next(0, collection.Count));
        }
    }
}
