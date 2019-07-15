using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Brain.Meshes
{
    public interface IBaseObject
    {
        string Name { get; }
        int TotalObjects { get;}
        
        
           

    }
    public abstract class BaseClass
    {
        static System.Exception[] exceptions = new System.Exception[]
       {
        new System.Exception("Number of points must be more than 3 ")
       };

        public GameObject Element;
        public MeshFilter mf;
        public Mesh mesh;

        List<Vector3> Vertices = new List<Vector3>();
        List<int> Triagles = new List<int>();

        public  string Name { get; set; }
        public string PublicName { get; set; } = "New Object " + Existed;
        [SerializeField]
        public Vector3 StartPoint = new Vector3(0f, 0f, 0f);
        [SerializeField]
        public int points = 3;
        [SerializeField]
        public Lean lean;
        [SerializeField]
        public Orientation orientation;
        [SerializeField]
        public TypeMesh type { get; protected set; }
        [SerializeField]
        public SolidMesh solid;

        

        
        [SerializeField]
        public TotalMeshes Total;
        [SerializeField]
        public MeshCollider meshCollider;

        public static int Existed = 0;
        
        public BaseClass(Vector3 v, int p, string n, TotalMeshes t,Lean le)
        {
           
            Total = t;
            PublicName = n;
            points = p;
            lean = le;
            StartPoint = v;
        }
        public BaseClass(Vector3 s,int p,string n)
        {
            StartPoint = s;
            
            points = p;
            PublicName = n;
           // type = this.GetTypeClass();
        }
        
       
       
        public BaseClass()
        {
            //type = this.GetTypeClass();
        }


        
        public int TotalObjects
        {
            get
            {
                return Existed;
            }
        }
        
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value >= 3)
                {
                    points = value;
                }
                else
                {
                    Debug.LogException(exceptions[0]);
                }
            }
        }
        /*
      
        /*
        public static object this[string propertyName]
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(BaseClass);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(BaseClass);
                System.Reflection.PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
                BaseClass baseClass = new Ba
                SerializedObject serializedObject = new UnityEditor.SerializedObject(BaseClass);
                object ss = BaseClass.CreateInstance(type.ToString())
                SerializedProperty serializedPropertyMyInt = serializedObject.FindProperty("myInt");
                SerializedObject serializedObject = new UnityEditor.SerializedObject(obj);

            }

        }*/
    }

 
}
