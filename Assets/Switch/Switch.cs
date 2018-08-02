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
	public class Switch : MonoBehaviour
	{
        public bool isPlayerOn;

        public Material openMaterial;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                isPlayerOn = true;

                GetComponent<Renderer>().material = openMaterial;
            }
        }

        void OnCollisionExit(Collision col)
        {
            if (col.gameObject.CompareTag("Player"))
                isPlayerOn = false;
        }
    }
}