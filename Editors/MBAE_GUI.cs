using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Brain.Meshes
{
    public class MBAE_GUI : PropertyDrawer
    {
        public static Height HeightField(Rect position, Height property, GUIContent label)
        {
            position.y += 16f;
            Rect labelPosition = position;
            labelPosition.x = 13f;
            EditorGUI.LabelField(labelPosition, label);
            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUI.FloatField(position, new GUIContent("Value"), property.Value);
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - property.Value) / 2f;

                property.Value = newVal0;
                property.Up += Update;
                property.Down += Update;
            }



            Rect boolPosition = position;
            boolPosition.x = 100;

            property.View = EditorGUI.Toggle(boolPosition, property.View);
            if (property.View)
            {
                position.y += 18f;

                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUI.FloatField(position, new GUIContent("Up"), property.Up);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal01 - property.Up);
                    property.Up = newVal01;
                    property.Value += Update;

                }


                position.y += 18f;



                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUI.FloatField(position, new GUIContent("Down"), property.Down);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal02 - property.Down);
                    property.Down = newVal02;
                    property.Value += Update;

                }


            }
            return property;
        }

        public static Length LengthField(Rect position, Length property, GUIContent label)
        {
            position.y += 16f;
            Rect labelPosition = position;
            labelPosition.x = 13f;
            EditorGUI.LabelField(labelPosition, label);

            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUI.FloatField(position, new GUIContent("Value"), property.Value);
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - property.Value) / 2f;

                property.Value = newVal0;
                property.Left += Update;
                property.Right += Update;
            }

            Rect boolPosition = position;
            boolPosition.x = 100;

            property.View = EditorGUI.Toggle(boolPosition, property.View);
            if (property.View)
            {
                position.y += 18f;

                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUI.FloatField(position, new GUIContent("Left"), property.Left);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal01 - property.Left);
                    property.Left = newVal01;
                    property.Value += Update;

                }
                position.y += 18f;

                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUI.FloatField(position, new GUIContent("Right"), property.Right);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal02 - property.Right);
                    property.Right = newVal02;
                    property.Value += Update;

                }

            }
            return property;

        }
        public static Width WidthField(Rect position, Width property, GUIContent label)
        {
            position.y += 16f;
            Rect labelPosition = position;
            labelPosition.x = 13f;
            EditorGUI.LabelField(labelPosition, label);

            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUI.FloatField(position, new GUIContent("Value"), property.Value);
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - property.Value) / 2f;

                property.Value = newVal0;
                property.Left += Update;
                property.Right += Update;
            }

            Rect boolPosition = position;
            boolPosition.x = 100;

            property.View = EditorGUI.Toggle(boolPosition, property.View);
            if (property.View)
            {
                position.y += 18f;

                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUI.FloatField(position, new GUIContent("Left"), property.Left);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal01 - property.Left);
                    property.Left = newVal01;
                    property.Value += Update;

                }
                position.y += 18f;

                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUI.FloatField(position, new GUIContent("Right"), property.Right);
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal02 - property.Right);
                    property.Right = newVal02;
                    property.Value += Update;

                }

            }
            return property;
        }
        public static Radius RadiusField(Rect position, Radius property, GUIContent label)
        {

            position.y += 16f;
            Rect labelPosition = position;
            labelPosition.x = 13f;
            EditorGUI.LabelField(labelPosition, label);

            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUI.FloatField(position, new GUIContent("Value"), property.Value);
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - property.Value);
                property.Value = newVal0;

                Height newHeight = property.Height;
                newHeight.Value += Update;
                newHeight.Up += Update / 2f;
                newHeight.Down += Update / 2f;
                property.Height = newHeight;

                Length newLength = property.Length;
                newLength.Value += Update;
                newLength.Left += Update / 2f;
                newLength.Right += Update / 2f;
                property.Length = newLength;
            }


            Rect boolPosition = position;
            boolPosition.x = 100;

            property.View = EditorGUI.Toggle(boolPosition, property.View);
            if (property.View)
            {
                position.y += 16f;
                Height newheight = MBAE_GUI.HeightField(position, property.Height, new GUIContent("Height"));
                float newHeightValue = newheight.Value - property.Height.Value;
                property.Value += newHeightValue;
                property.Height = newheight;

                if (property.Height.View)
                {
                    position.y += 56f;
                }
                else
                {
                    position.y += 18f;
                }
                Length newLength = MBAE_GUI.LengthField(position, property.Length, new GUIContent("Length"));
                float newLengthValue = newLength.Value - property.Length.Value;
                property.Value += newLengthValue;
                property.Length = newLength;


            }
            return property;
        }
    }
}

