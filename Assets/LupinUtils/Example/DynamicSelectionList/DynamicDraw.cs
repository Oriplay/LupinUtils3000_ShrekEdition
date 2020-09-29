using System.Collections;
using System.Collections.Generic;
using LupinUtils.GUI;
using UnityEngine;

public class DynamicDraw : MonoBehaviour
{
    //test class
    public class DynamicTest
    {
        public string Head = "";
        public string Body = "";
    }

    //test list
    public List<DynamicTest> testList = new List<DynamicTest>()
    {
        new DynamicTest(){Head = "Element1"},
        new DynamicTest(){Head = "Element2"},
        new DynamicTest(){Head = "Element3"},
    };

    //index selected element
    private int index = 0;
    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        //draw selection list
        testList = testList.Draw(ref index, () => testList.Add(new DynamicTest(){Head = "Element" + (testList.Count+1)}), test => test.Head);
        //draw selected element
        testList.InvokeSelectedFunc(ref index, test =>
        {
            GUILayout.BeginVertical();
            test.Head = GUILayout.TextField( test.Head, GUILayout.Width(100));
            test.Body = GUILayout.TextField( test.Body, GUILayout.Width(100));
            GUILayout.EndVertical();
            return true;
        });
        GUILayout.EndHorizontal();
    }
}
