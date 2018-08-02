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
    public class Switch : MonoBehaviour
    {
        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        public SwitchType type = SwitchType.Toggle;

        List<GameObject> activeGameObjects = new List<GameObject>();
        public bool Active { get { return activeGameObjects.Count > 0; } }

        void OnCollisionEnter(Collision collision)
        {
            if (!enabled) return;

            if (activeGameObjects.Contains(collision.gameObject)) return;

            if (IsActivator(collision.gameObject))
            {
                activeGameObjects.Add(collision.gameObject);
                OnEnter.Invoke();
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (!enabled) return;

            if (!activeGameObjects.Contains(collision.gameObject)) return;

            if (IsActivator(collision.gameObject))
            {
                if (type == SwitchType.Hold)
                    activeGameObjects.Remove(collision.gameObject);

                OnExit.Invoke();
            }
        }

        bool IsActivator(GameObject gameObject)
        {
            return gameObject.CompareTag("Player") || gameObject.CompareTag("Prop");
        }
    }

    public enum SwitchType
    {
        Hold, Toggle
    }
}