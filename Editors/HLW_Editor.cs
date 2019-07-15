using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Brain.Meshes;
using System;

namespace Brain.Meshes
{


    [CustomPropertyDrawer(typeof(Length))]
    [CustomPropertyDrawer(typeof(Width))]
    [CustomPropertyDrawer(typeof(Height))]
    [CanEditMultipleObjects]
    public class HLW_Editor : PropertyDrawer
    {
        SerializedProperty First, Second, Sum;
        string name;
        string[] Names = new string[] { "_Up", "_Down", "_Height" };
        string[] VisibleNames = new string[] { "Up", "Down", "Height" };
        bool View = false;


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {



            //get the name before it's gone
            name = property.displayName;

            switch (property.type)
            {
                case "Height":

                    break;
                case "Length":
                    Names[0] = "_Left";
                    Names[1] = "_Right";
                    Names[2] = "_Length";
                    VisibleNames[0] = "Left";
                    VisibleNames[1] = "Right";
                    VisibleNames[2] = "Length";
                    break;
                case "Width":
                    Names[0] = "_Left";
                    Names[1] = "_Right";
                    Names[2] = "_Width";
                    VisibleNames[0] = "Left";
                    VisibleNames[1] = "Right";
                    VisibleNames[2] = "Width";
                    break;


            }

            First = property.FindPropertyRelative(Names[0]);
            Second = property.FindPropertyRelative(Names[1]);
            Sum = property.FindPropertyRelative(Names[2]);
            /*
            First = property.FindPropertyRelative("_Up");
            Second = property.FindPropertyRelative("_Down");
            Sum = property.FindPropertyRelative("_Height");
*/





            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));


            //Check if there is enough space to put the name on the same line (to save space)



            contentPosition.height = 16f;



            EditorGUI.BeginProperty(contentPosition, label, Sum);
            {
                EditorGUI.BeginChangeCheck();
                float newVal0 = EditorGUI.FloatField(contentPosition, new GUIContent("Value"), Sum.floatValue);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal0 - Sum.floatValue) / 2f;

                    Sum.floatValue = newVal0;
                    First.floatValue += Update;
                    Second.floatValue += Update;
                }
            }
            EditorGUI.EndProperty();

            Rect boolPosition = contentPosition;
            boolPosition.x = 100;

            View = EditorGUI.Toggle(boolPosition, View);
            if (View)
            {
                contentPosition.y += 18f;

                EditorGUI.BeginProperty(contentPosition, label, First);
                {

                    EditorGUI.BeginChangeCheck();
                    float newVal01 = EditorGUI.FloatField(contentPosition, new GUIContent(VisibleNames[0]), First.floatValue);
                    if (EditorGUI.EndChangeCheck())
                    {
                        float Update = (newVal01 - First.floatValue);
                        First.floatValue = newVal01;
                        Sum.floatValue += Update;

                    }
                }
                EditorGUI.EndProperty();

                contentPosition.y += 18f;


                EditorGUI.BeginProperty(contentPosition, label, Second);
                {
                    EditorGUI.BeginChangeCheck();
                    float newVal02 = EditorGUI.FloatField(contentPosition, new GUIContent(VisibleNames[1]), Second.floatValue);
                    if (EditorGUI.EndChangeCheck())
                    {
                        float Update = (newVal02 - Second.floatValue);
                        Second.floatValue = newVal02;
                        Sum.floatValue += Update;

                    }
                }
                EditorGUI.EndProperty();
            }






        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return View ? 54f : 18f;
        }
    }

}
