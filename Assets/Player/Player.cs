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
    public class Player : MonoBehaviour
    {
        Rigidbody rb;

        public float speed = 4f;

        public float jumpPower = 5f;

        public float direction = 1f;

        public string moveAxis = "Horizontal";
        public string jumpAxis = "Jump";

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            var moveInput = Input.GetAxis(moveAxis);

            var velocity = rb.velocity;

            velocity.z = moveInput * speed;

            rb.velocity = velocity;

            if (Input.GetButton(jumpAxis))
                rb.AddForce(Vector3.up * direction * jumpPower, ForceMode.VelocityChange);

            rb.AddForce(Vector3.up * direction * Physics.gravity.y, ForceMode.Acceleration);
        }
	}
}