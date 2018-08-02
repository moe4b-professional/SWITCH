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
    public class SwitchMaterialControl : MonoBehaviour
    {
        public Material active;

        public Renderer[] renderers;

        void Start()
        {
            GetComponent<Switch>().OnEnter.AddListener(OnEnter);
        }

        void OnEnter()
        {
            Set(active);
        }

        void Set(Material material)
        {
            foreach (var renderer in renderers)
                renderer.material = material;
        }
	}
}