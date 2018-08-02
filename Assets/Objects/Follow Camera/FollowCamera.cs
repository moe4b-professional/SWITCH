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
	public class FollowCamera : MonoBehaviour
	{
        public float speed = 10f;

		public virtual void MoveTo(float xPosition)
        {
            movementCoroutine = StartCoroutine(MovementProcedure(xPosition));
        }

        Coroutine movementCoroutine;
        public bool IsMoving { get { return movementCoroutine != null; } }
        IEnumerator MovementProcedure(float xPosition)
        {
            var target = transform.position;
            target.x = xPosition;

            while(true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                if (Mathf.Approximately(transform.position.x, xPosition))
                    break;
                else
                    yield return new WaitForEndOfFrame();
            }

            movementCoroutine = null;
        }
	}
}