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
	public class GravityFlipper : MonoBehaviour
	{
        public float delay = 2f;

		void OnCollisionEnter(Collision collision)
        {
            if (processes.ContainsKey(collision.gameObject)) return;

            if (!IsActivator(collision.gameObject)) return;

            var customGravity = collision.gameObject.GetComponent<CustomGravity>();

            if (customGravity == null) return;

            var coroutine = StartCoroutine(DelayProcedure(customGravity));
            processes.Add(collision.gameObject, coroutine);
        }

        bool IsActivator(GameObject gameObject)
        {
            if (gameObject.CompareTag("Prop")) return true;
            if (gameObject.CompareTag("Player")) return true;

            return false;
        }

        Dictionary<GameObject, Coroutine> processes = new Dictionary<GameObject, Coroutine>();
        IEnumerator DelayProcedure(CustomGravity target)
        {
            var timer = 0f;

            while(timer != delay)
            {
                timer = Mathf.MoveTowards(timer, delay, Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            Action(target);
            processes.Remove(target.gameObject);
        }

        void Action(CustomGravity target)
        {
            target.direction *= -1;
        }

        void OnCollisionExit(Collision collision)
        {
            if(processes.ContainsKey(collision.gameObject))
            {
                StopCoroutine(processes[collision.gameObject]);
                processes.Remove(collision.gameObject);
            }
        }
	}
}