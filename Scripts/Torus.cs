using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    
    public class Torus : BaseClass
    {

        [SerializeField]
        public Radius innerRadius = new Radius(0.5f);
        
        [SerializeField]
        public Radius outerRadius = new Radius(1f);

        [SerializeField]
        public Height height = new Height(1f);
        public new string Name = "Torus " + Existed;

        public int FOC = 10;

        
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
        public Radius InnerRadius
        {
            get
            {
                return innerRadius;
            }
            set
            {
                if (value.Value > 0f)
                {
                    innerRadius = value;
                }
                else
                {
                    Debug.LogWarning(InnerRadius + " must be positive");
                }
            }
        }
        public Radius OuterRadius
        {
            get
            {
                return outerRadius;
            }
            set
            {
                if (value.Value > 0f)
                {
                    outerRadius = value;
                }
                else
                {
                    Debug.LogWarning(OuterRadius + " must be positive");
                }
            }
        }

        public Torus():base()
        {
            type = TypeMesh.Torus;
        }
        public Torus(Vector3 s, Radius radius,Radius Inner,Radius Outer, int frequency, int points, string name)
           : base(s,points, name)
        {
            this.FOC = frequency;
            InnerRadius = Inner;
            OuterRadius = Outer;
            type = TypeMesh.Torus;
        }
        public Torus(Vector3 s, Radius radius, int points, string name)
          : base(s, points, name)
        {
            type = TypeMesh.Torus;
        }
    

        public void Build()
        {
           

            Total.Reset();
            Name = "Torus " + Existed;
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
            float x = 0f;
            float y = 0f;




            if (orientation == Orientation.Horizontal)
            {


                //Lis Of Points Of This Triangle
                List<Vector3> LOPOTT = new List<Vector3>();
                List<List<Vector3>> ListOfCircles = new List<List<Vector3>>();
                for (int i = 0; i < points; i++)
                {
                    ListOfCircles.Add(new List<Vector3>());
                }


                float ThislittleX = InnerRadius.Value + StartPoint.x;
                float ThislittleZ = 0f;

                float ThisbigX = InnerRadius.Value + StartPoint.x;
                float ThisbigZ = 0f;


                Vector3 CenterOf2D = new Vector3(StartPoint.x + ((ThislittleX + ThisbigX) / 2f), StartPoint.y, StartPoint.z + ((ThislittleZ + ThisbigZ) / 2f));


                for (int i = 0; i < points; i++)
                {

                    x = outerRadius.Value * Mathf.Sin(2 * Mathf.PI * i / points);
                    y = outerRadius.Value * Mathf.Cos(2 * Mathf.PI * i / points);

                    LOPOTT.Add(new Vector3(x + CenterOf2D.x, y + CenterOf2D.y, CenterOf2D.z));
                }
                for (int a = 0; a < points; a++)
                {
                    Vector3 ThisVector = LOPOTT[a];
                    float X = (ThisVector.x - StartPoint.x);
                    X *= X;
                    float Z = (ThisVector.z - StartPoint.z);
                    Z *= Z;

                    float RADIUS = Mathf.Sqrt(X + Z);

                    for (int c = 0; c < FOC; c++)
                    {

                        float ThisX = RADIUS * Mathf.Sin((2 * Mathf.PI * c / FOC));
                        float ThisZ = RADIUS * Mathf.Cos((2 * Mathf.PI * c / FOC));
                        List<Vector3> ooo = ListOfCircles[a];
                        ooo.Add(new Vector3(ThisX + StartPoint.x, ThisVector.y, ThisZ + StartPoint.z));
                    }

                }





                for (int o = 0; o < FOC; o++)
                {


                    Vector3[] Vectors = new Vector3[points];

                    for (int a = 0; a < points; a++)
                    {
                        List<Vector3> oop = ListOfCircles[a];
                        Vectors[a] = oop[o];
                    }



                    for (int a = 0; a < points; a++)
                    {
                        verticiesList.Add(Vectors[a]);
                    }

                }
            }


            Vector3[] verticies = verticiesList.ToArray();
            Debug.Log(verticiesList.Count.ToString());
            foreach (var a in verticies)
            {
                Debug.Log("X " + a.x.ToString() + " Y " + a.y.ToString() + " Z " + a.z.ToString());
            }
            /*
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {


            };*/
            //triangles
            List<int> trianglesList = new List<int> { };

            for (int i = 0; i < FOC; i++)
            {
                int c = i * points;
                if (i < FOC - 1)
                {
                    for (int a = 0; a < points; a++)
                    {
                        if (a < points - 1)
                        {
                            trianglesList.Add(a + 1 + c);
                            trianglesList.Add(a + points + c);
                            trianglesList.Add(a + c);

                            trianglesList.Add(a + 1 + c);
                            trianglesList.Add(a + points + 1 + c);
                            trianglesList.Add(a + points + c);
                        }
                        else
                        {
                            trianglesList.Add(a + points + c);
                            trianglesList.Add(a + c);
                            trianglesList.Add(points - a - 1 + points + c);


                            trianglesList.Add(a + c);
                            trianglesList.Add(points - a - 1 + c);
                            trianglesList.Add(points - a + points - 1 + c);
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < points; a++)
                    {
                        if (a < points - 1)
                        {
                            trianglesList.Add(c + a + 1);
                            trianglesList.Add(a);
                            trianglesList.Add(a + c);

                            trianglesList.Add(a + 1);
                            trianglesList.Add(a);
                            trianglesList.Add(c + a + 1);

                        }
                        else
                        {
                            trianglesList.Add(a + c);
                            trianglesList.Add(c);
                            trianglesList.Add(0);


                            trianglesList.Add(a);
                            trianglesList.Add(a + c);
                            trianglesList.Add(0);
                        }
                    }

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
            mesh.uv = uvs;
            mesh.normals = normals;
            mesh.triangles = triangles;
            
            Existed += 1;
            MC.sharedMesh = Mesh.Instantiate(mesh);
            Element.AddInformation(PublicName, Name, type);
            #endregion


        }


    }
}
