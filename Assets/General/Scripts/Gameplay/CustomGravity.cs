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
    [RequireComponent(typeof(Rigidbody))]
	public class CustomGravity : MonoBehaviour
	{
        [Range(-1, 1)]
        public int direction = 1;

        float multiplier = 1.4f;

        new Rigidbody rigidbody;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            rigidbody.useGravity = false;
        }

        void FixedUpdate()
        {
            rigidbody.AddForce(Physics.gravity * direction * multiplier, ForceMode.Acceleration);
        }
	}
}