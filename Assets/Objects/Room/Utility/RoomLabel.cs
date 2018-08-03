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
    [RequireComponent(typeof(Text))]
	public class RoomLabel : MonoBehaviour
	{
        public Room room;
        
        void Start()
        {
            GetComponent<Text>().text = room.name.ToUpper();
        }		
	}
}