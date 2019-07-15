using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Brain.Meshes;
using System;


namespace Brain.Meshes
{

   

    [CustomPropertyDrawer(typeof(Radius))]
    [CanEditMultipleObjects]
    public class RadiusDrawer : PropertyDrawer
    {
        SerializedProperty Height, Length, Radius;
        string name;

        string[] Names = new string[] { "_Height", "_Length", "_Radius" };
        bool View = false;
        bool heightView, lengthView;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {



            //get the name before it's gone
            name = property.displayName;

            Height = property.FindPropertyRelative(Names[0]);

            Length = property.FindPropertyRelative(Names[1]);

            Radius = property.FindPropertyRelative(Names[2]);

            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));


            //Check if there is enough space to put the name on the same line (to save space)



            contentPosition.height = 16f;



            EditorGUI.BeginProperty(contentPosition, label, Radius);
            {
                EditorGUI.BeginChangeCheck();
                float newVal0 = EditorGUI.FloatField(contentPosition, new GUIContent("Value"), Radius.floatValue);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal0 - Radius.floatValue) / 2f;

                    Radius.floatValue = newVal0;

                    Height newHeight = Height.GetHeightValue();
                    newHeight.Value += Update;
                    newHeight.Up += Update / 2f;
                    newHeight.Down += Update / 2f;
                    Height.SetHeightValue(newHeight);

                    Length newLength = Length.GetLengthValue();
                    newLength.Value += Update;
                    newLength.Left += Update / 2f;
                    newLength.Right += Update / 2f;
                    Length.SetLengthValue(newLength);
                }
            }
            EditorGUI.EndProperty();

            Rect boolPosition = contentPosition;
            boolPosition.x = 100;

            View = EditorGUI.Toggle(boolPosition, View);
            if (View)
            {
                contentPosition.y += 16f;
                Height newheight = MBAE_GUI.HeightField(contentPosition, Height.GetHeightValue(), new GUIContent("Height"));
                float newHeightValue = newheight.Value - Height.GetHeightValue().Value;
                Radius.floatValue += newHeightValue;
                Height.SetHeightValue(newheight);
                heightView = Height.GetHeightValue().View;
                if (heightView)
                {
                    contentPosition.y += 56f;
                }
                else
                {
                    contentPosition.y += 18f;
                }
                Length newLength = MBAE_GUI.LengthField(contentPosition, Length.GetLengthValue(), new GUIContent("Length"));
                float newLengthValue = newLength.Value - Length.GetLengthValue().Value;
                Radius.floatValue += newLengthValue;
                Length.SetLengthValue(newLength);
                lengthView = Length.GetLengthValue().View;
            }






        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {

            float Height = 0f;
            Height += heightView == true ? 54f : 18f;
            Height += lengthView == true ? 54f : 18f;
            Height += View == true ? 18f : 0f;
            Height += 18f;
            return Height;
        }


    }

}
