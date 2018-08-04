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
	public class NCCube : MonoBehaviour
	{
        Bounds bounds;

        float pushBackForce = 60f;
        float pushBackRange = 0.6f;

        new Rigidbody rigidbody;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();

            bounds = GetComponent<Renderer>().bounds;
        }

		void Update()
        {
            CheckPushback(Vector3.right);
            CheckPushback(Vector3.left);
        }

        public LayerMask pushBackMask;
        void CheckPushback(Vector3 direction)
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, direction, out hit, pushBackRange + bounds.extents.x, pushBackMask))
            {
                rigidbody.AddForce(-direction * pushBackForce, ForceMode.Acceleration);
            }
        }
	}
}