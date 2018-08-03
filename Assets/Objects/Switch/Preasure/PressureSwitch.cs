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
	public class PressureSwitch : Switch
	{
        public PressureSwitchType type = PressureSwitchType.Toggle;

        List<GameObject> activeGameObjects = new List<GameObject>();
        public override bool Active { get { return activeGameObjects.Count > 0; } }

        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        void OnCollisionEnter(Collision collision)
        {
            if (!enabled) return;

            if (activeGameObjects.Contains(collision.gameObject)) return;

            if (IsActivator(collision.gameObject))
            {
                activeGameObjects.Add(collision.gameObject);

                TriggerActivity();

                OnEnter.Invoke();
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (!enabled) return;

            if (!activeGameObjects.Contains(collision.gameObject)) return;

            if (IsActivator(collision.gameObject))
            {
                if (type == PressureSwitchType.Hold)
                    activeGameObjects.Remove(collision.gameObject);

                TriggerActivity();

                OnExit.Invoke();
            }
        }
    }

    public enum PressureSwitchType
    {
        Hold, Toggle
    }
}