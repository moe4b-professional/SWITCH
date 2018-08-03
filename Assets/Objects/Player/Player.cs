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
        CustomGravity gravity;

        public bool control = true;

        public MovementData movement;
        [Serializable]
        public class MovementData
        {
            public float speed;

            public string inputAxis;
        }
        public void ProcessMovement()
        {
            if (!control) return;

            var velocity = rigidbody.velocity;

            velocity.x = Input.GetAxis(movement.inputAxis) * movement.speed;

            rigidbody.velocity = velocity;
        }

        public JumpData jump;
        [Serializable]
        public class JumpData
        {
            public float force;

            public float multiplier = 1f;

            public string inputButton;
        }
        public void ProcessJump()
        {
            if(control && Input.GetButtonDown(jump.inputButton))
            {
                rigidbody.AddForce(Vector3.up * gravity.direction * jump.force * jump.multiplier, ForceMode.VelocityChange);
            }
        }

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            gravity = GetComponent<CustomGravity>();
        }

        void Update()
        {
            ProcessMovement();
            ProcessJump();
        }

        public void NavigateTo(float xPosition)
        {
            navigationCoroutine = StartCoroutine(NavigationProcedure(xPosition));
        }

        Coroutine navigationCoroutine;
        public bool IsNavigating { get { return navigationCoroutine != null; } }
        IEnumerator NavigationProcedure(float xPosition)
        {
            control = false;

            var constraints = rigidbody.constraints;
            rigidbody.constraints = constraints | RigidbodyConstraints.FreezePositionX;

            var target = transform.position;
            target.x = xPosition;

            while (true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, movement.speed * 2f * Time.deltaTime);

                if (Mathf.Approximately(transform.position.x, xPosition))
                    break;
                else
                    yield return new WaitForEndOfFrame();
            }

            rigidbody.constraints = constraints;

            control = true;
            navigationCoroutine = null;
        }
    }
}