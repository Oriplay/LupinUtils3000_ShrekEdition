using System;
using System.Collections.Generic;
using UnityEngine;

namespace LupinUtils.GUI
{
    public static class DynamicSelectionList 
    {
        private static Color _selectedColor = Color.green;

        /// <summary>
        /// Dynamic selection list
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="index">selected index</param>
        /// <param name="addAction">Add element action</param>
        /// <param name="getNameFunc">get name to button func</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>list</returns>
        public static List<T> Draw<T>(this List<T> list, ref int index, Action addAction, Func<T, string> getNameFunc)
        {
            var standardBackgroundColor = UnityEngine.GUI.backgroundColor;
            
            list.UpdateIndex(ref index);
            
            GUILayout.BeginVertical(UnityEditor.EditorStyles.helpBox, GUILayout.ExpandWidth(false));
            
            for (int i = 0; i < list.Count; i++)
            {
                var element = list[i];
                
                var name = getNameFunc.Invoke(element);
                
                UnityEngine.GUI.backgroundColor = index == i ? _selectedColor : standardBackgroundColor;
                
                if (GUILayout.Button(name, GUILayout.ExpandWidth(false)))
                {
                    index = i;
                }
            }
            
            UnityEngine.GUI.backgroundColor = standardBackgroundColor;
            
            list.UpdateIndex(ref index);
            
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(false));
            if (GUILayout.Button("+", GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                addAction?.Invoke();
            }
            if (GUILayout.Button("-", GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                RemoveAndUpdate(ref list, ref index);
            }
            GUILayout.EndHorizontal();
            
            GUILayout.EndVertical();
            
            list.UpdateIndex(ref index);
            
            return list;
        }

        /// <summary>
        /// Update selected index
        /// </summary>
        /// <param name="enterList"></param>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        public static void UpdateIndex<T>(this List<T> enterList, ref int index)
        {
            if (index >= enterList.Count)
            {
                index = enterList.Count - 1;
            }

            if (index < 0)
            {
                index = 0;
            }
        }

        /// <summary>
        /// Remove element and Update selected index
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="index">selected index</param>
        /// <typeparam name="T">Type</typeparam>
        private static void RemoveAndUpdate<T>(ref List<T> list, ref int index)
        {
            list.UpdateIndex(ref index);

            if (list.Count <= 0) return;
            
            list.RemoveAt(index);
            index--;
            list.UpdateIndex(ref index);
        }

        /// <summary>
        /// Check selected element and invoke action
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="index">selected index</param>
        /// <param name="invokedFunc">Func</param>
        /// <typeparam name="T">Type</typeparam>
        public static void InvokeSelectedFunc<T>(this List<T> list, ref int index, Func<T, bool> invokedFunc)
        {
            if (list.Count <= 0) return;
            list.UpdateIndex(ref index);
            var element = list[index];
            if (element != null)
            {
                invokedFunc.Invoke(element);
            }
        }
        
        /// <summary>
        /// Set selected color
        /// </summary>
        /// <param name="color">color</param>
        public static void SetSelectedColor(Color color)
        {
            _selectedColor = color;
        }
    }
}
