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
            var value = new Bounds(transform.position, Vector3.zero);

            foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
                value.Encapsulate(renderer.bounds);

            Vector3 localCenter = value.center - transform.position;
            value.center = localCenter;

            Bounds = value;
        }

        void Start()
        {
            CalculateBounds();
        }
	}
}