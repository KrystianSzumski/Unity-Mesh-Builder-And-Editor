using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    public class Visualizer {
        private List<Vector3> vertices;
        private Color color;
        private float radius;
        private GameObject Element;
        
        public List<Vector3> Vertices
        {
            get
            {
                try
                {
                     vertices = vertices == null ? throw new NullReferenceException() : vertices;
                }catch(NullReferenceException nullValue)
                {
                    Debug.Log(nullValue);
                }
                return vertices;
            }
            set
            {
                vertices = value;
            }
        }
        public Color Color
        {
            get
            {
                try
                {
                     color = color == null ? throw new NullReferenceException() : color;
                }
                catch (NullReferenceException nullValue)
                {
                    Debug.Log(nullValue);
                    return Color.white;
                }
                return color;
            }
            set
            {
                color = value;
            }
        }
        public float Radius
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

        public void Visualize()
        {
            int Existed = 0;
            Element = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Element.name = "Point " + Existed.ToString();
        }
        
       
    }
}
