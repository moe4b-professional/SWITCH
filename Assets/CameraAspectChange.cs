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
	public class CameraAspectChange : MonoBehaviour
	{
        Camera cam;
        void Start()
        {
            cam = GetComponent<Camera>();
        }

        public float Depth
        {
            get
            {
                return cam.transform.position.z;
            }
            set
            {
                var pos = cam.transform.position;

                pos.z = value;

                cam.transform.position = pos;
            }
        }

		void Update()
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                if (Depth == -20f)
                    Depth = -28f;
                else
                    Depth = -20f;
            }
        }
	}
}