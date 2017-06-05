using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Leg_Controller_1))]
public class LegControllerEditor_1 : Editor
{
    public override void OnInspectorGUI()
    {
        Leg_Controller_1 lc = (Leg_Controller_1)target;
        if (GUILayout.Button("hook"))
        {
            lc.Hook();
        }


        DrawDefaultInspector();
    }
}
