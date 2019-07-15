using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    
    public class Cone : BaseClass
    {
        [SerializeField]
        public Radius radius = new Radius(1f);
        
        [SerializeField]
        public Height height = new Height(1f);
        public new string Name = "Cone " + Existed;

        // [SerializeField]
        //  new Width width = new Width(0f);
        //  [SerializeField]
        //  new Height height = new Height(0f);

        float C_x;
        float C_z;
        float ix = 0f;
        float iz = 0f;

        
        public Height Height
        {
            get
            {
                return height;
            }
            set
            {
                if (radius.Value > 0f)
                {
                    height.Value = 0f;
                }
                else
                {
                    height = value;
                }
            }
        }
        public Radius Radius
        {
            get
            {
                return radius;
            }
            set
            {
                
                    radius = value;
                
            }
        }

        public Cone() : base()
        {
            type = TypeMesh.Cone;
        }
        public Cone(Vector3 start, Radius radius,Height height, int points, string name) : base(start,points, name)
        {
            Radius = radius;
            Height = height;
            type = TypeMesh.Cone;
        }


        public void Build()
        {




            Name = "Cone " + TotalObjects.ToString();
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
            List<Vector3> verticiesList2 = new List<Vector3> { };
            float x;// = radius.Value * Mathf.Sin((2 * Mathf.PI * (points - 1) / points)) / 2f;

            float z;//= radius.Value * Mathf.Cos((2 * Mathf.PI * (points - 1) / points)) / 2f;
            verticiesList.Add(new Vector3(0f, height.Value, 0f));
            verticiesList2.Add(verticiesList[0]);
            for (int i = 0; i < points; i++)
            {
                x = radius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                z = radius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                verticiesList2.Add(new Vector3(x, 0f, z));
            }
            if (points > 3)
            {
                List<Vector3> MainVectors = new List<Vector3> { };
                //Liczydło
                int Abacus = points / 3;

                for (int i = 1; i < Abacus * 3; i += Abacus)
                {
                    MainVectors.Add(verticiesList2[i]);
                }

                for (int i = 0; i < 3; i++)
                {
                    ix += MainVectors[i].x;

                    iz += MainVectors[i].z;
                }
                C_x = ix / 3;
                C_z = iz / 3;
                verticiesList.Add(new Vector3(C_x, 0f, C_z));
            }
            for (int i = 0; i < points; i++)
            {
                x = radius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                z = radius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                verticiesList.Add(new Vector3(x, 0f, z));
            }
            Vector3[] verticies = verticiesList.ToArray();
            /*
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {


            };*/
            //triangles
            List<int> trianglesList = new List<int> { };
            for (int i = 1; i <= points; i++)
            {
                if (points == 3)
                {
                    if (i < points - 1)
                    {
                        trianglesList.Add(0);
                        trianglesList.Add(i + 1);
                        trianglesList.Add(i + 2);
                    }
                    else
                    {
                        trianglesList.Add(0);
                        trianglesList.Add(points);
                        trianglesList.Add(points - i);
                    }
                }
                else
                {
                    if (i < points)
                    {
                        trianglesList.Add(0);
                        trianglesList.Add(i + 1);
                        trianglesList.Add(i + 2);
                    }
                    else
                    {
                        trianglesList.Add(0);
                        trianglesList.Add(points + 1);
                        trianglesList.Add(2);
                    }
                }
            }
            if (points == 3)
            {
                for (int i = points; i >= 2; i--)
                {
                    trianglesList.Add(i);
                }
            }
            else
            {
                for (int i = points + 1; i >= 2; i--)
                {
                    if (i > 2)
                    {
                        trianglesList.Add(i);
                        trianglesList.Add(i - 1);
                        trianglesList.Add(1);
                    }
                    else
                    {
                        trianglesList.Add(i);
                        trianglesList.Add(points + 1);
                        trianglesList.Add(1);
                    }
                }

            }

            int[] triangles = trianglesList.ToArray();
            //normals
            /*List<Vector3> normalsList = new List<Vector3> { };
            for (int i = 0; i < verticies.Length; i++)
            {
                normalsList.Add(-Vector3.forward);
            }
            Vector3[] normals = normalsList.ToArray();*/

            //UVs//
            Vector2[] uvs = new Vector2[verticies.Length];

            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(verticies[i].x, verticies[i].z);
            }


            mesh.Clear();
            mesh.vertices = verticies;
            mesh.uv = uvs;
            //mesh.normals = normals;
            mesh.triangles = triangles;
            MC.sharedMesh = Mesh.Instantiate(mesh);

            Existed += 1;
            Element.AddInformation(PublicName, Name, type);
            #endregion
        }


    }
}


  
