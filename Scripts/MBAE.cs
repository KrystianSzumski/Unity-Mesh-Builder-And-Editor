using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    /// <summary>
    /// Mesh Builder And Editor
    /// </summary>
    
    [AddComponentMenu("MBAE/Mesh Builder & Editor")]
   public class MBAE:MonoBehaviour
    {
        
        [SerializeField]
        [HideInInspector]
        public Block2D block2D = new Block2D();
        [SerializeField]
        [HideInInspector]
        public Cone cone = new Cone();
        [SerializeField]
        [HideInInspector]
        public Cube cube = new Cube();
        [SerializeField]
        [HideInInspector]
        public Cylinder cylinder = new Cylinder();
       
        [SerializeField]
        [HideInInspector]
        public DuplexTrapezium duplexTrapezium = new DuplexTrapezium();
        [SerializeField]
        [HideInInspector]
        public Face face = new Face();
        
        [SerializeField]
        [HideInInspector]
        public Torus torus = new Torus();
        [SerializeField]
        [HideInInspector]
        public Visualizer visualizer = new Visualizer();



    }
}
