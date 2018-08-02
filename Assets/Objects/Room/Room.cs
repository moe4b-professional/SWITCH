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

using UnityEngine.Events;

namespace DEFAULTNAMESPACE
{
    public class Room : MonoBehaviour
    {
        public Door[] doors;

        public Bounds Bounds { get; protected set; }
        void CalculateBounds()
        {
            Bounds = new Bounds();

            var renderers = GetComponentsInChildren<Renderer>();

            foreach (var renderer in renderers)
                Bounds.Encapsulate(renderer.bounds);
        }

        void Awake()
        {
            CalculateBounds();
        }
	}
}