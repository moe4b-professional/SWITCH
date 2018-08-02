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
	public class PlayerTrigger : MonoBehaviour
	{
        public UnityEvent onEnter;
        public UnityEvent onExit;

        void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Player"))
                onEnter.Invoke();
        }

        void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player"))
                onExit.Invoke();
        }
    }
}