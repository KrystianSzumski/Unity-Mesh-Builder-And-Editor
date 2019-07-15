using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.Drawing;

namespace Brain.Meshes
{
   
    public static class Tools
    {

       
        public static TotalMeshes Reset(this TotalMeshes Total)
        {
            Total.Triangle = 0;
            Total.Square = 0;
            Total.Parallelogram = 0;
            Total.Rectangle = 0;
            Total.Tetrahedron = 0;
            Total.Rhombus = 0;
            Total.Pentagon = 0;
            Total.Hexagon = 0;
            Total.Heptagon = 0;
            Total.Octagon = 0;
            Total.Nonagon = 0;
            Total.Decagon = 0;
            Total.Entekagon = 0;
            Total.Dodecahedron = 0;
            Total.Triskaidekagon = 0;
            Total.Circle = 0;

            return Total;
        }
        public static void VerifyPoints(this BaseClass baseClass)
        {
            if (baseClass.points % 3 == 0)
            {
                Debug.Log("The checking was passed. Good number of points in mesh. :D Congratulations ");
            }
            else
            {
                Debug.LogError("The checking was not passed. :( Property - Number Of Points - must be multiple of 3.");
            }
        }
        public static TypeMesh GetTypeMesh(this BaseClass baseClass)
        {
            return baseClass.type;
        }
        public static void Solution(Vector3 StartPoint, Searches searches, float X, float Y, float Radius)
        {
            if (searches == Searches.X)
            {

            }
            else
            {
                float x = X - StartPoint.x;

                float r = Radius;
                r -= x;
                float ElementOfDelta = Mathf.Sqrt((2f * (-StartPoint.x) * (-StartPoint.x)) - (4f * (StartPoint.x - x)));
                float Y1 = ((-StartPoint.x) - ElementOfDelta) / 2f;
                float Y2 = ((-StartPoint.x) + ElementOfDelta) / 2f;
            }
        }
        public static void CheckingName(this Block2D Object)
        {


            switch (Object.points)
            {
                case 3: Object.Name = "Triangle " + Object.Total.Triangle.ToString(); Object.Total.Triangle += 1; ; break;
                case 4:
                    if (Object.radius.Length.Value == Object.radius.Height.Value || (Object.radius.Length.Left == Object.radius.Length.Right && Object.radius.Height.Up == Object.radius.Height.Down))
                    {
                        if (Object.lean == Lean.Straight)
                        {
                            Object.Name = "Square " + Object.Total.Square.ToString(); Object.Total.Square += 1;
                        }
                        else
                        {

                            Object.Name = "Parallelogram " + Object.Total.Parallelogram.ToString();
                            Object.Total.Parallelogram += 1;
                        }
                    }
                    else if (Object.radius.Length.Value > Object.radius.Height.Value || Object.radius.Length.Value > Object.radius.Height.Value)
                        if (Object.lean == Lean.Straight)
                        {
                            if ((Object.radius.Length.Left + Object.radius.Length.Right) > (Object.radius.Height.Up + Object.radius.Height.Down) || (Object.radius.Length.Left + Object.radius.Length.Right) < (Object.radius.Height.Up + Object.radius.Height.Down))
                            {

                                Object.Name = "Rectangle " + Object.Total.Rectangle.ToString(); Object.Total.Rectangle += 1;
                            }
                            else if ((Object.radius.Length.Left > Object.radius.Length.Right || Object.radius.Length.Left < Object.radius.Length.Right) && (Object.radius.Height.Up > Object.radius.Height.Down || Object.radius.Height.Up < Object.radius.Height.Down))
                            {
                                Object.Name = "Tetrahedron " + Object.Total.Tetrahedron.ToString(); Object.Total.Tetrahedron += 1;
                            }
                        }
                        else
                        {
                            if ((Object.radius.Length.Left + Object.radius.Length.Right) > (Object.radius.Height.Up + Object.radius.Height.Down) || (Object.radius.Length.Left + Object.radius.Length.Right) < (Object.radius.Height.Up + Object.radius.Height.Down))
                            {

                                Object.Name = "Rhombus " + Object.Total.Rhombus.ToString(); Object.Total.Rhombus += 1;
                            }
                            else if ((Object.radius.Length.Left > Object.radius.Length.Right || Object.radius.Length.Left < Object.radius.Length.Right) && (Object.radius.Height.Up > Object.radius.Height.Down || Object.radius.Height.Up < Object.radius.Height.Down))
                            {
                                Object.Name = "Tetrahedron " + Object.Total.Tetrahedron.ToString(); Object.Total.Tetrahedron += 1;
                            }
                        }
            
                    break;
                case 5: Object.Name = "Pentagon " + Object.Total.Pentagon.ToString(); Object.Total.Pentagon += 1; break;
                case 6: Object.Name = "Hexagon " + Object.Total.Hexagon.ToString(); Object.Total.Hexagon += 1; break;
                case 7: Object.Name = "Heptagon " + Object.Total.Heptagon.ToString(); Object.Total.Heptagon += 1; break;
                case 8: Object.Name = "Octagon " + Object.Total.Octagon.ToString(); Object.Total.Octagon += 1; break;
                case 9: Object.Name = "Nonagon " + Object.Total.Nonagon.ToString(); Object.Total.Nonagon += 1; break;
                case 10: Object.Name = "Decagon " + Object.Total.Decagon.ToString(); Object.Total.Decagon += 1; break;
                case 11: Object.Name = "Entekagon " + Object.Total.Entekagon.ToString(); Object.Total.Entekagon += 1; break;
                case 12: Object.Name = "Dodecahedron " + Object.Total.Dodecahedron.ToString(); Object.Total.Dodecahedron += 1; break;
                case 13: Object.Name = "Triskaidekagon " + Object.Total.Triskaidekagon.ToString(); Object.Total.Triskaidekagon += 1; break;
                default: Object.Name = "Circle " + Object.Total.Circle.ToString(); Object.Total.Circle += 1; break;

            }

        }
        public static List<Vector3> GetPointsOfBasePoints(Radius radius,int points, Orientation orientation)
        {
            List<Vector3> list = new List<Vector3>();
            float x;
            float y;
            float z;
            if (orientation == Orientation.Vertical)
            {
                for (int i = 0; i < points; i++)
                {

                    x = radius.Value * Mathf.Sin(2 * Mathf.PI * i / points);
                    y = radius.Value * Mathf.Cos(2 * Mathf.PI * i / points);

                    list.Add(new Vector3(x, y, 0f));
                }
            }
            else
            {
                for (int i = 0; i < points; i++)
                {

                    x = radius.Value * Mathf.Sin(2 * Mathf.PI * i / points);
                    z = radius.Value * Mathf.Cos(2 * Mathf.PI * i / points);

                    list.Add(new Vector3(x, 0f, z));
                }
            }
            return list;
        }
       
        
        
       
       

        public static Texture2D GetTexture(this Bitmap bitmap)
        {
            Texture2D texture = new Texture2D(bitmap.Width, bitmap.Height);
            for(int x =0; x < texture.width; x++)
            {
                for(int y = 0; y < texture.height; y++)
                {
                    UnityEngine.Color color = new UnityEngine.Color();
                    System.Drawing.Color color2 = new System.Drawing.Color();
                    color2 =  bitmap.GetPixel(x, y);
                    color.a = color2.A;
                    color.b = color2.B;
                    color.g = color2.G;
                    color.r = color2.R;
                    texture.SetPixel(x, y, color);
                }
            }
            return texture;
        }
        

    /// <summary>
    /// This can be used to classes from Bain.Meshes DLL
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static TypeMesh GetTypeClass(this object type)
     {

         Type typ = type.GetType();
         TypeMesh thisType = TypeMesh.None;
         switch (typ.ToString())
         {
             case "Cone":
                 thisType = TypeMesh.Cone;
                 break;
             case "Cube":
                 thisType = TypeMesh.Cube;
                 break;
             case "Cylinder":
                 thisType = TypeMesh.Cylinder;
                 break;
             
                 
             case "DuplexTrapezium":
                 thisType = TypeMesh.DuplexTrapezium;
                 break;
             case "Pyramid3":
                 thisType = TypeMesh.Pyramid3;
                 break;



         }
         return thisType;
     }
    public static object GetInfoOnInspector(this object obj)
        {
            switch (obj.GetType().ToString())
            {
                case "Cone":
                    Cone cone = new Cone();
                    cone = (Cone)obj;

                    break;
                case "Cube":
                    
                    break;
                case "Cylinder":
                    
                    break;
                case "DoubleDuplexTrapeze":
                   ;
                    break;
                case "DuplexTrapezium":
               
                    break;
                case "Pyramid3":
                    
                    break;
            }
            return obj;
        }
        
       public static List<Vector3> AddCircle(this List<Vector3> list, Vector3 StartPoint,Radius radius,float Angle,float AngleGrowth,Axis axis,int points)
        {
            float x, y, z;
            float value1 = 0, value2 = 0 ;
           // for(float i = 0; i < Angle; i += AngleGrowth)
           // {
                for (int i = 0; i < points; i++)
                {
                float thisAngle = Angle * i/ points;
                if(thisAngle>=0 && thisAngle <= 90)
                {
                    value1 = radius.Length.Right;
                    value2 = radius.Height.Up;
                }else if(thisAngle > 90 && thisAngle <= 180)
                {
                    value1 = radius.Height.Up;
                    value2 = radius.Length.Left;
                }else if(thisAngle > 180 && thisAngle <= 270)
                {
                    value1 = radius.Length.Left;
                    value2 = radius.Height.Down;
                }
                else if(thisAngle > 270 && thisAngle < 360)
                {
                    value1 = radius.Height.Down;
                    value2 = radius.Length.Right;
                }
                switch (axis)
                {
                    case Axis.XY:
                        x = value1 * Mathf.Sin((Angle * i) / points);
                        y = value2 *Mathf.Sin((Angle * i) / points);
                        list.Add(new Vector3(x + StartPoint.x, y + StartPoint.y, 0f + StartPoint.z));
                        break;
                    case Axis.XZ:
                        x = value1 * Mathf.Sin((Angle * i) / points);
                        z = value2 * Mathf.Sin((Angle * i) / points);
                        list.Add(new Vector3(x + StartPoint.x, 0f + StartPoint.y, z + StartPoint.z));
                        break;
                    case Axis.ZY:
                        z = value1 * Mathf.Sin((Angle * i) / points);
                        y = value2 * Mathf.Sin((Angle * i) / points);
                        list.Add(new Vector3(0f+StartPoint.x, y + StartPoint.y, z + StartPoint.z));
                        break;
                }
                    
                    
                }
           // }
            return list;
        }

        #region PropertyValue
        public static Radius GetRadiusValue(this SerializedProperty property)
        {
            SerializedProperty Height, Length, Radius,View;
            View = property.FindPropertyRelative("_View");
            Height = property.FindPropertyRelative("_Height");
            Length = property.FindPropertyRelative("_Length");
            Radius = property.FindPropertyRelative("_Radius");

            Radius radius = new Radius();
            radius.View = View.boolValue;
            radius.Height = Height.GetHeightValue();
            radius.Length = Length.GetLengthValue();

            return radius;
        }
        public static SerializedProperty SetRadiusValue(this SerializedProperty property,Radius radius)
        {
            
            property.FindPropertyRelative("_View").boolValue = radius.View;
            property.FindPropertyRelative("_Height").SetHeightValue(radius.Height);
            property.FindPropertyRelative("_Length").SetLengthValue(radius.Length);
            property.FindPropertyRelative("_Radius").floatValue = radius.Value;
            
            return property;
        }
        public static Length GetLengthValue(this SerializedProperty property)
        {
            SerializedProperty First, Second, Sum,View;
            View = property.FindPropertyRelative("_View");
            First = property.FindPropertyRelative("_Left");
            Second = property.FindPropertyRelative("_Right");
            Sum = property.FindPropertyRelative("_Length");

            Length length = new Length();
            length.View = View.boolValue;
            length.Left = First.floatValue;
            length.Right = Second.floatValue;
            length.Value = Sum.floatValue;

            return length;

        }
        public static SerializedProperty SetLengthValue(this SerializedProperty property,Length length)
        {

            property.FindPropertyRelative("_View").boolValue = length.View;
            property.FindPropertyRelative("_Left").floatValue = length.Left;
            property.FindPropertyRelative("_Right").floatValue = length.Right;
            property.FindPropertyRelative("_Length").floatValue = length.Value;

            return property;

        }
        public static Width GetWidthValue(this SerializedProperty property)
        {
            SerializedProperty First, Second, Sum, View;
            View = property.FindPropertyRelative("_View");
            First = property.FindPropertyRelative("_Left");
            Second = property.FindPropertyRelative("_Right");
            Sum = property.FindPropertyRelative("_Width");

            Width width = new Width();
            width.View = View.boolValue;
            width.Left = First.floatValue;
            width.Right = Second.floatValue;
            width.Value = Sum.floatValue;

            return width;

        }
        public static SerializedProperty SetWidthValue(this SerializedProperty property,Width width)
        {

            property.FindPropertyRelative("_View").boolValue = width.View;
            property.FindPropertyRelative("_Left").floatValue = width.Left;
            property.FindPropertyRelative("_Right").floatValue = width.Right;
            property.FindPropertyRelative("_Width").floatValue = width.Value;
            
            return property;

        }
        public static Height GetHeightValue(this SerializedProperty property)
        {

            SerializedProperty First, Second,Sum, View;
            View = property.FindPropertyRelative("_View");
            First = property.FindPropertyRelative("_Up");
            Second = property.FindPropertyRelative("_Down");
            Sum = property.FindPropertyRelative("_Height");


            Height height = new Height();
            height.View = View.boolValue;
            height.Up = First.floatValue; ;
            height.Down = Second.floatValue;
            height.Value = Sum.floatValue;
            return height;

        }
        public static SerializedProperty SetHeightValue(this SerializedProperty property,Height height)
        {
            property.FindPropertyRelative("_View").boolValue = height.View;
            property.FindPropertyRelative("_Up").floatValue = height.Up;
            property.FindPropertyRelative("_Down").floatValue = height.Down;
            property.FindPropertyRelative("_Height").floatValue = height.Value;
            return property;

        }
        public static void AddInformation(this GameObject gameObject,string PublicName,string PrivateName,Brain.Meshes.TypeMesh type)
        {
            Information Info = new Information();
            Info = gameObject.AddComponent<Information>();
            Info.PublicName = PublicName;
            Info.PrivateName = PrivateName;
            Info.typeMesh = type;
            Info.Current_ID = Information.ID;
            Information.ID += 1;
        }
        #endregion
        
        




    }
}
