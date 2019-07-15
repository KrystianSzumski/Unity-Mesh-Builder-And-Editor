using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    #region 2D_Block
   
    public partial class Block2D : BaseClass
    {
        public Radius radius = new Radius(1f);
        public new string Name = "2D_Shape " + Existed;

        public Block2D() : base()
        {
            type = TypeMesh.Block2D;
        }
        public Block2D(Vector3 start,Radius radius,int points,string name) : base(start,points, name)
        {
            type = TypeMesh.Block2D;
        }
       
        public void Build()
        {
            
            Total.Reset();
            this.CheckingName();
            Element = new GameObject(PublicName);
            Element.transform.position = StartPoint;
            Element.AddComponent<MeshRenderer>();
            mf = new MeshFilter();
            mf = Element.AddComponent<MeshFilter>();
            mesh = new Mesh();
            mf.sharedMesh = mesh;
            MeshCollider MC = Element.AddComponent<MeshCollider>();
            
            #region balblabla
            //verticies
            List<Vector3> verticiesList = new List<Vector3> { };
            float x;
            float y;
            for (int i = 0; i < points; i++)
            {
                x = radius.Value * Mathf.Sin((2 * Mathf.PI * i) / points);
                y = radius.Value * Mathf.Cos((2 * Mathf.PI * i) / points);
                verticiesList.Add(new Vector3(x, y, 0f));
            }
            Vector3[] verticies = verticiesList.ToArray();
            /*
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {


            };*/
            //triangles
            List<int> trianglesList = new List<int> { };
            for (int i = 0; i < (points - 2); i++)
            {
                trianglesList.Add(0);
                trianglesList.Add(i + 1);
                trianglesList.Add(i + 2);
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
            MC.sharedMesh = Mesh.Instantiate(mesh);
            Existed += 1;

            Element.AddInformation(PublicName, Name, type);
            #endregion;
        }
    }
    #endregion
}
