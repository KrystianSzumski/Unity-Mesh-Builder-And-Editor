using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    #region Cube
    public class Cube : BaseClass
    {
       
        [SerializeField]
        public Width width = new Width(1f);
        [SerializeField]
        public Length length = new Length(1f);
        [SerializeField]
        public Height height = new Height(1f);
        public new string Name = "Cube " + Existed;
        private Vector3 vertLeftTopFront;
        private Vector3 vertRightTopFront;
        private Vector3 vertRightTopBack;
        private Vector3 vertLeftTopBack;
        

        private float waitN = 3f;
        private float waitD = 3f;
        public int shapeN = 0;

        public Width Width
        {
            get
            {
                return width;
            }
            set
            {
               
                    width = value;
                
            }
        }
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
       

        public Cube() : base()
        {
            type = TypeMesh.Cube;
        }
        public Cube(Vector3 start, Radius radius, int points, string name) : base(start, points, name)
        {
            type = TypeMesh.Cube;
        }
        void MorphToCube()
        {

                //morph to cube//
            if (shapeN == 0)
            {
                vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1, 1, 1) + StartPoint, Time.deltaTime);
                vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, 1, 1) + StartPoint, Time.deltaTime);
                vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 1, -1) + StartPoint, Time.deltaTime);
                vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 1, -1) + StartPoint, Time.deltaTime);
            }
        }
        public void MorphToPyramid()
        {
            if (waitN > 0f)
            {
                waitN -= Time.deltaTime;
            }
            else
            {
                waitN = waitD;




                vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(0, 1, 0) + StartPoint, Time.deltaTime);
                vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(0, 1, 0) + StartPoint, Time.deltaTime);
                vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(0, 1, 0) + StartPoint, Time.deltaTime);
                vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(0, 1, 0) + StartPoint, Time.deltaTime);

                MorphToCube();
            }
        }
        public void MorphToRamp()
        {
            if (waitN > 0f)
            {
                waitN -= Time.deltaTime;
            }
            else
            {
                waitN = waitD;




                vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1, -1, 2) + StartPoint, Time.deltaTime);
                vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, -1, 2) + StartPoint, Time.deltaTime);
                vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 0.5f, -1) + StartPoint, Time.deltaTime);
                vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 0.5f, -1) + StartPoint, Time.deltaTime);

                MorphToCube();
            }

        }
        public void MorphToRoof()
        {
            if (waitN > 0f)
            {
                waitN -= Time.deltaTime;
            }
            else
            {
                waitN = waitD;




                //morph to roof//


                vertLeftTopFront = Vector3.Lerp(vertLeftTopFront, new Vector3(-1, 0.2f, 0) + StartPoint, Time.deltaTime);
                vertRightTopFront = Vector3.Lerp(vertRightTopFront, new Vector3(1, 0.2f, 0) + StartPoint, Time.deltaTime);
                vertRightTopBack = Vector3.Lerp(vertRightTopBack, new Vector3(1, 0.2f, 0) + StartPoint, Time.deltaTime);
                vertLeftTopBack = Vector3.Lerp(vertLeftTopBack, new Vector3(-1, 0.2f, 0) + StartPoint, Time.deltaTime);


                MorphToCube();
            }

        }
        // Use this for initialization
        public void Build()
        {


            Name = "Cube " + Existed;
            Element = new GameObject(PublicName);
            Element.transform.position = StartPoint;
            Element.AddComponent<MeshRenderer>();
            mf = new MeshFilter();
            mf = Element.AddComponent<MeshFilter>();
            mesh = new Mesh();
            mf.sharedMesh = mesh;
            MeshCollider MC = Element.AddComponent<MeshCollider>();

            vertLeftTopFront = new Vector3(-1, 1, 1);
            vertRightTopFront = new Vector3(1, 1, 1);
            vertRightTopBack = new Vector3(1, 1, -1);
            vertLeftTopBack = new Vector3(-1, 1, -1);
            #region blablabla
            //Vertices//
            Vector3[] vertices = new Vector3[]
            {
			//front face//
			vertLeftTopFront,//left top front, 0
			vertRightTopFront,//right top front, 1
            vertRightTopBack,//right top back, 4
			vertLeftTopBack,//left top back, 5
			new Vector3(-1,-1,1),//left bottom front, 2
			new Vector3(1,-1,1),//right bottom front, 3
			new Vector3(1,-1,-1),//right bottom back, 6
			new Vector3(-1,-1,-1),//left bottom back, 7
            };

            //Triangles// 3 points, clockwise determines which side is visible
            int[] triangles = new int[]
            {
			//front face//
			0,1,2,
			0,2,3,

            0,4,5,
            1,0,5,

            1,5,6,
            2,1,6,

            2,6,7,
            3,2,7,

            3,7,0,
            0,7,4,

            6,5,4,
            7,6,4
            };

           

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
          //  mesh.uv = uvs;
            MC.sharedMesh = Mesh.Instantiate(mesh);
            Existed += 1;
            Element.AddInformation(PublicName, Name, type);
            #endregion
        }
    }
    #endregion
}
