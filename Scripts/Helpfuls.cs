using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Brain.Meshes
{
    [System.Serializable]
    public enum SolidMesh
    {
        One_Sided,
        Two_Sided
    }
    public enum Axis
    {
        XZ,
        XY,
        ZY,
        //XYZ
    }
    [System.Serializable]
    public enum TypeMesh
    {
        Block2D,
        Capsule,
        Cone,
        Cube,
        Cylinder,
        DuplexTrapezium,
        Face,
        Pyramid3,
        Sphere,
        Terrain,
        Tree,
        Torus,
        Visualizer,
        None,

    }
    [System.Serializable]
    public enum Searches
    {
        X, Y
    }
    [System.Serializable]
    public enum Orientation
    {
        Horizontal,
        Vertical,
    };
    [System.Serializable]
    public enum Lean
    {
        Askew,
        Straight,
    }
    [System.Serializable]
    public struct TotalMeshes
    {
        public int Triangle;
        public int Square;
        public int Parallelogram;
        public int Rectangle;
        public int Tetrahedron;
        public int Rhombus;
        public int Pentagon;
        public int Hexagon;
        public int Heptagon;
        public int Octagon;
        public int Nonagon;
        public int Decagon;
        public int Entekagon;
        public int Dodecahedron;
        public int Triskaidekagon;
        public int Circle;

    };

    [System.Serializable]
    public struct Height
    {
        [SerializeField]
        private bool _View;
        [SerializeField]
        private float _Up;
        [SerializeField]
        private float _Down;
        [SerializeField]
        private float _Height;


        public float Value
        {
            get
            {
                return _Height;

            }
            set
            {

                _Height = value;


            }
        }

        public float Up
        {
            get
            {
                return _Up;
            }
            set
            {

                _Up = value;



            }
        }
        public float Down
        {
            get
            {
                return _Down;
            }
            set
            {


                _Down = value;


            }
        }
        public bool View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }
        }

        public Height(float up, float down)
        {
            _Up = up;
            _Down = down;
            _Height = up + down;
            _View = false;
        }
        public Height(float height)
        {
            _Up = height / 2f;
            _Down = height / 2f;
            _Height = height;
            _View = false;
        }
        public static float operator +(Height a, Length b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Height a, Width b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Height a, Radius b)
        {
            return a.Value + b.Value;
        }
        public static Height operator +(Height a, float b)
        {
            return new Height(a.Value + b);
        }
        public static Height operator +(Height a, Height b)
        {
            Height length = new Height(a.Value + b.Value);

            bool c;
            if (a.View == false && b.View == false)
            {
                c = false;
            }
            else
            {
                c = true;
            }

            length.View = c;
            return length;
        }
        public static Height operator *(Height a, Height b)
        {
            Height length = new Height(a.Value * b.Value);

            bool c;
            if (a.View == true && b.View == true)
            {
                c = true;
            }
            else
            {
                c = false;
            }

            length.View = c;
            return length;
        }

        public static implicit operator Length(Height length)
        {
            return new Height(length.Value);
        }
        public static implicit operator Radius(Height length)
        {
            return new Radius(length.Value / 2f);
        }
        public static implicit operator Height(float length)
        {
            return new Height(length);
        }


    }
    [System.Serializable]
    public struct Width
    {
        [SerializeField]
        private bool _View;
        [SerializeField]
        private float _Left;
        [SerializeField]
        private float _Right;
        [SerializeField]
        private float _Width;

        public float Value
        {
            get
            {
                return _Width;

            }
            set
            {

                _Width = value;


            }
        }

        public float Left
        {
            get
            {
                return _Left;
            }
            set
            {
                _Left = value;



            }
        }
        public float Right
        {
            get
            {
                return _Right;
            }
            set
            {

                _Right = value;


            }
        }
        public bool View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }
        }
        public Width(float left, float right)
        {
            _Left = left;
            _Right = right;
            _Width = left + right;
            _View = false;
        }
        public Width(float width)
        {
            _Left = width / 2f;
            _Right = width / 2f;
            _Width = width;
            _View = false;
        }
        public static float operator +(Width a, Radius b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Width a, Length b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Width a, Height b)
        {
            return a.Value + b.Value;
        }
        public static Width operator +(Width a, Width b)
        {
            Width length = new Width(a.Value + b.Value);

            bool c;
            if (a.View == false && b.View == false)
            {
                c = false;
            }
            else
            {
                c = true;
            }

            length.View = c;
            return length;
        }
        public static Width operator *(Width a, Width b)
        {
            Width length = new Width(a.Value * b.Value);

            bool c;
            if (a.View == true && b.View == true)
            {
                c = true;
            }
            else
            {
                c = false;
            }

            length.View = c;
            return length;
        }

        public static implicit operator Length(Width length)
        {
            return new Width(length.Value);
        }
        public static implicit operator Radius(Width length)
        {
            return new Radius(length.Value / 2f);
        }
        public static implicit operator Width(float length)
        {
            return new Width(length);
        }
    }
    [System.Serializable]
    public struct Length
    {
        [SerializeField]
        private bool _View;
        [SerializeField]
        private float _Left;
        [SerializeField]
        private float _Right;
        [SerializeField]
        private float _Length;

        public float Value
        {
            get
            {
                return _Length;

            }
            set
            {

                _Length = value;


            }
        }

        public float Left
        {
            get
            {
                return _Left;
            }
            set
            {

                _Left = value;



            }
        }
        public float Right
        {
            get
            {
                return _Right;
            }
            set
            {


                _Right = value;


            }
        }
        public bool View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }
        }
        public Length(float left, float right)
        {

            _Left = left;
            _Right = right;
            _Length = left + right;
            _View = false;
        }
        public Length(float length)
        {
            _Left = length / 2f;
            _Right = length / 2f;
            _Length = length;
            _View = false;
        }
        public static Length operator +(Length a, float value)
        {
            return new Length(a.Value + value);
        }
        public static float operator +(Length a, Radius b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Length a, Width b)
        {
            return a.Value + b.Value;
        }
        public static float operator +(Length a, Height b)
        {
            return a.Value + b.Value;
        }
        public static Length operator +(Length a, Length b)
        {
            Length length = new Length(a.Value + b.Value);

            bool c;
            if (a.View == false && b.View == false)
            {
                c = false;
            }
            else
            {
                c = true;
            }

            length.View = c;
            return length;
        }
        public static Length operator *(Length a, Length b)
        {
            Length length = new Length(a.Value * b.Value);

            bool c;
            if (a.View == true && b.View == true)
            {
                c = true;
            }
            else
            {
                c = false;
            }

            length.View = c;
            return length;
        }

        public static implicit operator Width(Length length)
        {
            return new Width(length.Value);
        }
        public static implicit operator Radius(Length length)
        {
            return new Radius(length.Value / 2f);
        }
        public static implicit operator Length(float length)
        {
            return new Length(length);
        }


    }
    [System.Serializable]
    public struct Radius
    {
        [SerializeField]
        private bool _View;
        [SerializeField]
        private Length _Length;
        [SerializeField]
        private Height _Height;
        [SerializeField]
        private float _Radius;


        public float Value
        {
            get
            {
                return _Radius;

            }
            set
            {

                _Length.Value = value;


            }
        }

        public Length Length
        {
            get
            {
                return _Length.Value;
            }
            set
            {

                _Length = value;



            }
        }
        public Height Height
        {
            get
            {
                return _Height.Value;
            }
            set
            {


                _Height = value;


            }
        }
        internal bool View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
            }
        }

        public Radius(Length length, Height height)
        {

            _Length = length;
            _Height = height;
            _Radius = (length.Value + height.Value) / 4f;
            _View = false;
        }
        public Radius(float radius)
        {

            _Length = new Length(2 * radius);
            _Height = new Height(2 * radius);
            _Radius = radius;
            _View = false;
        }

        public static implicit operator Radius(float length)
        {
            return new Radius(length);
        }

    }


    

}

