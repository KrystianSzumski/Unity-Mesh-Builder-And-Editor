using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



namespace Brain.Meshes
{
    #region Cylinder


    public class Cylinder : BaseClass
    {
        
        [SerializeField]
        public Radius topRadius = new Radius(1f);
        [SerializeField]
        public Radius bottomRadius = new Radius(1f);

        [SerializeField]
        public Height height = new Height(1f);
        public new string Name = "Cylinder " + Existed;

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
                topRadius = value;
                
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
                    Debug.LogError(BottomRadius + " will be positive !");
                }

            }
        }

        public Cylinder() : base()
        {
            type = TypeMesh.Cylinder;
        }
        public Cylinder(Vector3 start, Radius radius, int points, string name) : base(start, points, name)
        {
            type = TypeMesh.Cylinder;
        }
        public void Build()
        {
            if (points % 4 == 0)
            {
                Debug.LogWarning("Sorry this option is not working. Please choose number of points which is multiple of 3");
                return;
                
            }
            Total.Reset();

            Name = "Cylinder " + Existed;
            Element = new GameObject(PublicName);
            Element.transform.position = StartPoint;
            Element.AddComponent<MeshRenderer>();
            mf = new MeshFilter();
            mf = Element.AddComponent<MeshFilter>();
            mesh = new Mesh();
            mf.sharedMesh = mesh;
            MeshCollider MC = Element.AddComponent<MeshCollider>();
            

            #region blablabla
            //verticies
            List<Vector3> verticiesList = new List<Vector3> { };
            float x;
            float y;
            
            if (orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < points; i++)
                {
                    x = BottomRadius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                    y = BottomRadius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                    verticiesList.Add(new Vector3(x, y, 0f));
                }

                for (int i = 0; i < points; i++)
                {
                    x = TopRadius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                    y = TopRadius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                    verticiesList.Add(new Vector3(x, y, height.Value));
                }

                float X = (verticiesList[0].x + verticiesList[points / 3 - 1].x + verticiesList[points * 2 / 3 - 1].x) / 3f;
                float Y = (verticiesList[0].y + verticiesList[points / 3 - 1].y + verticiesList[points * 2 / 3 - 1].y) / 3f;
                float Z = (verticiesList[0].z + verticiesList[points / 3 - 1].z + verticiesList[points * 2 / 3 - 1].z) / 3f;

                verticiesList.Add(new Vector3(X, Y, 0f));
                verticiesList.Add(new Vector3(X, Y, height.Value));
            }
            else
            {
                for (int i = 0; i < points; i++)
                {
                    x = BottomRadius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                    y = BottomRadius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                    verticiesList.Add(new Vector3(x, y, 0f));
                }

                for (int i = 0; i < points; i++)
                {
                    x = TopRadius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                    y = TopRadius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                    verticiesList.Add(new Vector3(x,  height.Value,y));
                }

                float X = (verticiesList[0].x + verticiesList[points / 3 - 1].x + verticiesList[points * 2 / 3 - 1].x) / 3f;
                float Y = (verticiesList[0].y + verticiesList[points / 3 - 1].y + verticiesList[points * 2 / 3 - 1].y) / 3f;
                float Z = (verticiesList[0].z + verticiesList[points / 3 - 1].z + verticiesList[points * 2 / 3 - 1].z) / 3f;

                verticiesList.Add(new Vector3(X, 0f, Y));
                verticiesList.Add(new Vector3(X, height.Value, Y));
               
            }
            Vector3[] verticies = verticiesList.ToArray();
            /*
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {


            };*/
            //triangles
            List<int> trianglesList = new List<int> { };
            //IF TRIANGLE
            if (points == 3)
            {
                //FRONTSIDE & BACKSIDE
                trianglesList.Add(0);
                trianglesList.Add(1);
                trianglesList.Add(2);

                trianglesList.Add(5);
                trianglesList.Add(4);
                trianglesList.Add(3);
            }
            else if (points % 3 == 0)
            {

                
                for (int i = 0; i < (points - 1); i++)
                {
                    trianglesList.Add(2 * points);
                    trianglesList.Add(i);
                    trianglesList.Add(i + 1);

                    trianglesList.Add(i + 1+points);
                    trianglesList.Add(i+points);
                    trianglesList.Add(2 * points+1);
                }
                trianglesList.Add(2 * points);
                trianglesList.Add(points - 1);
                trianglesList.Add(0);

                trianglesList.Add(0+points);
                trianglesList.Add(points - 1+points);
                trianglesList.Add(2 * points+1);


            }
            //SIDES
            for (int i = 0; i < points; i++)
            {
                if (i < points - 1)
                {
                    trianglesList.Add(i);
                    trianglesList.Add(i + points);
                    trianglesList.Add(i + 1);

                    trianglesList.Add(i + points);
                    trianglesList.Add(i + points + 1);
                    trianglesList.Add(i + 1);

                }
                else
                {
                    trianglesList.Add(0);
                    trianglesList.Add(points-1);
                    trianglesList.Add(points);

                    trianglesList.Add(points);
                    trianglesList.Add(points -1);
                    trianglesList.Add(2 * points - 1);
                }
            }
            int[] triangles = trianglesList.ToArray();
            //normals
            List<Vector3> normalsList = new List<Vector3> { };
            for (int i = 0; i < verticies.Length; i++)
            {
                normalsList.Add(-Vector3.forward);
            }
            Vector3[] normals = normalsList.ToArray();

            //UVs//
            Vector2[] uvs = new Vector2[verticies.Length];

            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(verticies[i].x, verticies[i].z);
            }


            mesh.Clear();
            mesh.vertices = verticies;
            mesh.triangles = triangles;
            mesh.uv = uvs;
            mesh.normals = normals;
            

            MC.sharedMesh = Mesh.Instantiate(mesh);
            Existed += 1;
            Element.AddInformation(PublicName, Name, type);
            #endregion

        }


    }

    #endregion
}

