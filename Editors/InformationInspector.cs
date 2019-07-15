using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Brain.Meshes.Editors
{
    [CustomEditor(typeof(Information))]
    public class InformationInspector:Editor
    {
        Information MyTarget;

        SerializedObject SoTarget;
        private void OnEnable()
        {
            MyTarget = (Information)target;
            SoTarget = new SerializedObject(target);

        }
        public override void OnInspectorGUI()
        {
            GUILayout.TextArea(
                "Some Info about " + MyTarget.name + "\n\n" +
                "Type mesh: " + MyTarget.typeMesh + "\n" +
                "Private name: " + MyTarget.PrivateName + "\n" +
                "Public name: " + MyTarget.PublicName + "\n" +
                "ID: " + MyTarget.Current_ID + "\n\n" +
                "This is Auto-Generated information from MBAE" + "\n" +
                "If you remove this script, MBAE won't work correctly"


                );
            base.OnInspectorGUI();
        }
    }
}
