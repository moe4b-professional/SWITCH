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

        Material neutral;

        new public Renderer renderer;

        Switch SW;

        void Start()
        {
            neutral = renderer.material;

            SW = GetComponent<Switch>();

            SW.OnEnter.AddListener(OnEnter);
            SW.OnExit.AddListener(OnExit);
        }

        void OnEnter()
        {
            UpdateMaterial();
        }

        void OnExit()
        {
            UpdateMaterial();
        }

        void UpdateMaterial()
        {
            renderer.material = SW.Active ? active : neutral;
        }
    }
}