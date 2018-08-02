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
        new Rigidbody rigidbody;

        public float direction = 1f;

        public MovementData movement;
        [Serializable]
        public class MovementData
        {
            public float speed;

            public string inputAxis;
        }
        public void ProcessMovement()
        {
            var velocity = rigidbody.velocity;

            velocity.x = Input.GetAxis(movement.inputAxis) * movement.speed;

            rigidbody.velocity = velocity;
        }

        public JumpData jump;
        [Serializable]
        public class JumpData
        {
            public float force;

            public string inputButton;
        }
        public void ProcessJump()
        {
            if(Input.GetButtonDown(jump.inputButton))
            {
                rigidbody.AddForce(Vector3.up * direction * jump.force, ForceMode.VelocityChange);
            }
        }

        public void ProcessGravity()
        {
            rigidbody.AddForce(Vector3.up * direction * Physics.gravity.y, ForceMode.Acceleration);
        }

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            ProcessGravity();
            ProcessMovement();
            ProcessJump();
        }
	}
}