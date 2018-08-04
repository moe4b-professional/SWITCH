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
	public class PositionRegister : MonoBehaviour
	{
        [NonSerialized]
        public Vector3 value;
        public void UpdateValue()
        {
            value = transform.position;
        }

        public void Restore()
        {
            transform.position = value;
        }

        void Start()
        {
            UpdateValue();
        }
    }
}