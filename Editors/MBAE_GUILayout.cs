using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


namespace Brain.Meshes
{
    public class MBAE_GUILayout : PropertyDrawer
    {
        public static Height HeightField(Height height,GUIContent label, float margin)
        {

            int labelWidth = 0;
            foreach (char a in label.text)
            {
                labelWidth++;
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width((labelWidth * 8.25f) - margin / 3f));
            height.View = EditorGUILayout.Toggle(height.View, GUILayout.Width(40f - margin / 3f));
            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUILayout.FloatField(new GUIContent("Value"), height.Value, GUILayout.Width(Screen.width - 40f - (labelWidth * 8.25f) - 43f - margin / 3f));
            if (EditorGUI.EndChangeCheck())
            {
                
                float Update = (newVal0 - height.Value) / 2f;

                height.Value = newVal0;
                height.Up += Update;
                height.Down += Update;
            }


            EditorGUILayout.EndHorizontal();

            if (height.View)
            {
                EditorGUILayout.BeginVertical();
                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUILayout.FloatField(new GUIContent("Up"), height.Up, GUILayout.Width(Screen.width - 35 - margin));
                if (EditorGUI.EndChangeCheck())
                {

                    float Update = (newVal01 - height.Up);
                    height.Up = newVal01;
                    if (height.Value > (height.Up + height.Down))
                    {
                        height.Value = height.Up + height.Down;
                    }
                    else
                    {

                        height.Value += Update;
                    }

                }
                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUILayout.FloatField(new GUIContent("Down"), height.Down, GUILayout.Width(Screen.width - 35 - margin));
                if (EditorGUI.EndChangeCheck())
                {
                    
                    float Update = (newVal02 - height.Down);
                    height.Down = newVal02;
                    if (height.Value > (height.Up + height.Down))
                    {
                        height.Value = height.Up + height.Down;
                    }
                    else
                    {

                        height.Value += Update;
                    }

                }
                EditorGUILayout.EndVertical();
            }
            return height;

        }
        public static Width WidthField(Width width, GUIContent label, float margin)
        {
            int labelWidth = 0;
            foreach (char a in label.text)
            {
                labelWidth++;
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width((labelWidth * 8.25f) - margin / 3f));
            width.View = EditorGUILayout.Toggle(width.View, GUILayout.Width(40f - margin / 3f));
            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUILayout.FloatField(new GUIContent("Value"), width.Value, GUILayout.Width(Screen.width - 40f - (labelWidth * 8.25f) - 43f - margin / 3f));
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - width.Value) / 2f;

                width.Value = newVal0;
                width.Left += Update;
                width.Right += Update;
            }


            EditorGUILayout.EndHorizontal();

            if (width.View)
            {
                EditorGUILayout.BeginVertical();
                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUILayout.FloatField(new GUIContent("Left"), width.Left,GUILayout.Width(Screen.width - 35 - margin));
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal01 - width.Left);
                    width.Left = newVal01;
                    if (width.Value > (width.Right + width.Left))
                    {
                        width.Value = width.Right + width.Left;
                    }
                    else
                    {

                        width.Value += Update;
                    }

                }
                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUILayout.FloatField(new GUIContent("Right"), width.Right, GUILayout.Width(Screen.width - 35 - margin));
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal02 - width.Right);
                    width.Right = newVal02;
                    if (width.Value > (width.Right + width.Left))
                    {
                        width.Value = width.Right + width.Left;
                    }
                    else
                    {

                        width.Value += Update;
                    }

                }
                EditorGUILayout.EndVertical();
            }
            return width;

        }
        public static Length LengthField(Length length, GUIContent label, float margin)
        {
            int labelWidth = 0;
            foreach (char a in label.text)
            {
                labelWidth++;
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width((labelWidth * 8.25f) - margin / 3f) );
            length.View = EditorGUILayout.Toggle(length.View, GUILayout.Width(40f - margin / 3f));
            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUILayout.FloatField(new GUIContent("Value"), length.Value, GUILayout.Width(Screen.width - 40f - (labelWidth * 8.25f) - 43f - margin / 3f));
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - length.Value) / 2f;

                length.Value = newVal0;
                length.Left += Update;
                length.Right += Update;
            }


            EditorGUILayout.EndHorizontal();

            if (length.View)
            {
                EditorGUILayout.BeginVertical();
                EditorGUI.BeginChangeCheck();
                float newVal01 = EditorGUILayout.FloatField(new GUIContent("Left"), length.Left, GUILayout.Width(Screen.width - 35 -margin));
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal01 - length.Left);
                    length.Left = newVal01;
                    if (length.Value > (length.Right + length.Left))
                    {
                        length.Value = length.Right + length.Left;
                    }
                    else
                    {

                        length.Value += Update;
                    }

                }
                EditorGUI.BeginChangeCheck();
                float newVal02 = EditorGUILayout.FloatField(new GUIContent("Right"), length.Right, GUILayout.Width(Screen.width - 35 -margin));
                if (EditorGUI.EndChangeCheck())
                {
                    float Update = (newVal02 - length.Right);
                    length.Right = newVal02;
                    if (length.Value > (length.Right + length.Left))
                    {
                        length.Value = length.Right + length.Left;
                    }
                    else
                    {

                        length.Value += Update;
                    }

                }
                EditorGUILayout.EndVertical();
            }
            return length;

        }
        public static Radius RadiusField(Radius property, GUIContent label, float margin)
        {
            int labelWidth = 0;
            foreach(char a in label.text)
            {
                labelWidth++;
            }
          
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(labelWidth *8.25f-margin/2f));
            property.View = EditorGUILayout.Toggle(property.View, GUILayout.Width(40f - margin/2f));

            EditorGUI.BeginChangeCheck();
            float newVal0 = EditorGUILayout.FloatField(new GUIContent("Value"), property.Value, GUILayout.Width(Screen.width - 40f - (labelWidth*8.25f) - 43f - margin / 3f));
            if (EditorGUI.EndChangeCheck())
            {
                float Update = (newVal0 - property.Value);
                property.Value = newVal0;
                
                property.Height += new Height(Update);


                property.Length = new Length(Update);
            }
            EditorGUILayout.EndHorizontal();

            
            if (property.View)
            {
                
                Height newheight = MBAE_GUILayout.HeightField(property.Height, new GUIContent("Height"),margin);
                float newHeightValue = newheight.Value - property.Height.Value;
                
                property.Height = newheight;
                if ( property.Value> (property.Height.Value + property.Length.Value))
                {
                    property.Value = property.Height.Value + property.Length.Value;
                }
                else
                {

                    property.Height += newHeightValue;
                }

                Length newLength = MBAE_GUILayout.LengthField(property.Length, new GUIContent("Length"),margin);
                float newLengthValue = newLength.Value - property.Length.Value;
                property.Length = newLength;
                if (property.Value > (property.Height.Value + property.Length.Value))
                {
                    property.Value = property.Height.Value + property.Length.Value;
                }
                else
                {

                    property.Length += newLengthValue;
                }


            }
            return property;
        }
    }
}
