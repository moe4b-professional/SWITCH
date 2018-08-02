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

        bool active;
        public bool Active { get { return active; } }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                active = true;
                OnEnter.Invoke();
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (type == SwitchType.Hold)
                    active = false;

                OnExit.Invoke();
            }
        }
    }

    public enum SwitchType
    {
        Hold, Toggle
    }
}