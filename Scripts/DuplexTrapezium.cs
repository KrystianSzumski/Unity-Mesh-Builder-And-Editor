using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    #region Duplex_Trapezium
    public class DuplexTrapezium : BaseClass
    {

        [SerializeField]
        public float upperWidth = 0.5f;
        [SerializeField]
        public Radius bottomRadius = new Radius(1f);
        [SerializeField]
        public Radius topRadius = new Radius(1f);
        [SerializeField]
        public Height height = new Height(1f);

        public Height Height
        {
            get
            {
                return height;
            }
            set
            {

                height = value;

            }
        }


        public Radius TopRadius
        {
            get
            {
                return topRadius;
            }
            set
            {
                if (value.Value > 0f)
                {
                    topRadius = value;
                }
                else
                {
                    Debug.LogWarning(topRadius + " must be positive !");
                }
            }
        }
        public Radius BottomRadius
        {
            get
            {
                return bottomRadius;
            }
            set
            {
                if (value.Value > 0f)
                {
                    bottomRadius = value;
                }
                else
                {
                    Debug.LogWarning(bottomRadius + " must be positive !");
                }
            }
        }


        public DuplexTrapezium() : base()
        {
            type = TypeMesh.DuplexTrapezium;
        }
        public DuplexTrapezium(Vector3 start, Length length, Width width, Height height, int points, string name) : base(start, points, name)
        {
            type = TypeMesh.DuplexTrapezium;
        }
        //float upperWidth = 0.5f;

        Vector3 RightDownFront;
        Vector3 RightUpFront;

        Vector3 RightDownBack;
        Vector3 RightUpBack;

        Vector3 LeftDownFront;
        Vector3 LeftUpFront;

        Vector3 LeftDownBack;
        Vector3 LeftUpBack;
        /*
        Vector3 RightMiddleFront;
        Vector3 LeftMiddleFront;

        Vector3 RightMiddleBack;
        Vector3 LeftMiddleBack;
        */
        Vector3 UpperCenter;
        Vector3 BottomCenter;
        Vector3 LeftCenter;
        Vector3 RightCenter;


        // Use this for initialization
        public void Build()
        {
            Name = "Duplex Trapeze " + TotalObjects.ToString();
            RightDownFront = new Vector3(BottomRadius.Length.Right, 0f, 0f);
            RightUpFront = new Vector3(TopRadius.Length.Right * upperWidth, Height.Value, 0f);

            RightDownBack = new Vector3(BottomRadius.Length.Right, 0f, BottomRadius.Height.Value);
            RightUpBack = new Vector3(TopRadius.Length.Right * upperWidth, Height.Value, TopRadius.Height.Value);

            LeftDownFront = new Vector3(-BottomRadius.Length.Left, 0f, 0f);
            LeftUpFront = new Vector3(-TopRadius.Length.Left * upperWidth, Height.Value, 0f);

            LeftDownBack = new Vector3(-BottomRadius.Length.Left, 0f, BottomRadius.Height.Value);
            LeftUpBack = new Vector3(-TopRadius.Length.Left * upperWidth, Height.Value, TopRadius.Height.Value);
            /*
            RightMiddleFront = new Vector3(BottomRadius.Length.Right / 2f, 0f, 0f);
            LeftMiddleFront = new Vector3(-BottomRadius.Length.Left / 2f, 0f, 0f);

            RightMiddleBack = new Vector3(BottomRadius.Length.Right / 2f, 0f, BottomRadius.Height.Value);
            LeftMiddleBack = new Vector3(-BottomRadius.Length.Left / 2f, 0f, BottomRadius.Height.Value);
            */
            UpperCenter = new Vector3(TopRadius.Length.Value / 2f, Height.Value, TopRadius.Height.Value / 2f);
            BottomCenter = new Vector3(BottomRadius.Length.Value / 2f, 0f, BottomRadius.Height.Value / 2f);
            LeftCenter = new Vector3(-BottomRadius.Length.Right / 2f, Height.Value / 2f, BottomRadius.Height.Value / 2f);
            RightCenter = new Vector3(BottomRadius.Length.Right / 2f, Height.Value / 2f, BottomRadius.Height.Value / 2f);
            Element = new GameObject(PublicName);
            Element.transform.position = StartPoint;
            Element.AddComponent<MeshRenderer>();
            mf = new MeshFilter();
            mf = Element.AddComponent<MeshFilter>();
            mesh = new Mesh();
            mf.sharedMesh = mesh;
            MeshCollider MC = Element.AddComponent<MeshCollider>();


            #region blablabla
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {
         //  RightMiddleFront,
         // RightMiddleBack,
           RightDownFront,
           RightDownBack,
           RightUpFront,
           RightUpBack,
           LeftUpFront,
           LeftUpBack,
           LeftDownFront,
           LeftDownBack,


                //   LeftMiddleFront,
                //  LeftMiddleBack

            };
            //Triangles// 3 points, clockwise determines which side is visible
            List<int> triangles = new List<int>();

            for (int a = 0; a < 5; a += 2)
            {
                if (a < 10)
                {
                    triangles.Add(a + 2);
                    triangles.Add(a + 1);
                    triangles.Add(a);

                    triangles.Add(a + 3);
                    triangles.Add(a + 1);
                    triangles.Add(a + 2);
                }


            }
            triangles.Add(7);
            triangles.Add(6);
            triangles.Add(0);

            triangles.Add(1);
            triangles.Add(7);
            triangles.Add(0);

            triangles.Add(4);
            triangles.Add(2);
            triangles.Add(0);

            triangles.Add(6);
            triangles.Add(4);
            triangles.Add(0);

            triangles.Add(1);
            triangles.Add(3);
            triangles.Add(5);

            triangles.Add(1);
            triangles.Add(5);
            triangles.Add(7);

            //UVs//
            Vector2[] uvs = new Vector2[vertices.Length];

            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
            }

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.uv = uvs;
            mesh.triangles = triangles.ToArray();
            MC.sharedMesh = Mesh.Instantiate(mesh);
            Existed += 1;
            Element.AddInformation(PublicName, Name, type);
            #endregion
        }

    }
    #endregion
}
