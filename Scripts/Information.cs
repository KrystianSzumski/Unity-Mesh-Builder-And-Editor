using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Brain.Meshes
{
    
   
    public class Information : MonoBehaviour
    {
        public static List<Information> InfoList = new List<Information>();
        public TypeMesh typeMesh;
        public static int ID = 0;
        public int Current_ID { get; set; }

        public string PublicName { get; set; }
        public string PrivateName { get; set; }
        //public string Tag { get; set; }

        public Information( string privateName, string publicName, int ID, /*string tag,*/ TypeMesh type)
        {
            PrivateName = privateName;
            PublicName = publicName;
           // Tag = tag;
            Current_ID = ID;
            typeMesh = type;
            InfoList.Add(new Information( privateName,publicName, ID, /*tag,*/type));
        }
        public Information()
        {

        }
        public static Information GetObjectInfo(int ID)
        {
            var InfoQueue = from info in InfoList
                            where info.Current_ID == ID
                            select info;

            return (Information)InfoQueue;

        }
        public Information GetInfo
        {
            get
            {
                return gameObject.GetComponent<Information>();
            }

        }
    }
}
