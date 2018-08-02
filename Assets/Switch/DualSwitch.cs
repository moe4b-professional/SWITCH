using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace DEFAULTNAMESPACE
{
	public class DualSwitch : MonoBehaviour
	{
        public Switch switch1;
        public Door door1;
        	
        public Switch switch2;
        public Door door2;

        void Update()
        {
            if(switch1.isPlayerOn && switch2.isPlayerOn)
            {
                door1.IsOpen = true;
                door2.IsOpen = true;
            }
        }
    }
}