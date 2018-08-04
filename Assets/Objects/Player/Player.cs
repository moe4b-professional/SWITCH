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
        public Level Level { get { return Level.Instance; } }

        new CapsuleCollider collider;
        new Rigidbody rigidbody;
        [NonSerialized]
        public CustomGravity gravity;

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
            var velocity = rigidbody.velocity;

            velocity.x = animator.velocity.x;

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
            if(control && Level.IsPlaying && onGround && Input.GetButtonDown(jump.inputButton))
            {
                rigidbody.AddForce(Vector3.up * gravity.direction * jump.force * jump.multiplier, ForceMode.VelocityChange);
            }
        }

        Animator animator;
        void ProcessAnimator()
        {
            var input = Input.GetAxis(movement.inputAxis);

            if (!control || !Level.IsPlaying)
                input = 0f;

            var dampTime = Mathf.Approximately(input, 0f) ? 0.5f : 0.2f;

            animator.SetFloat("Speed", input, dampTime, Time.deltaTime);
        }

        void Awake()
        {
            collider = GetComponent<CapsuleCollider>();
            rigidbody = GetComponent<Rigidbody>();
            gravity = GetComponent<CustomGravity>();

            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            ProcessGroundCheck();

            ProcessMovement();
            ProcessJump();

            ProcessRotation();

            ProcessAnimator();
        }

        public LayerMask groundMask;
        public bool onGround;
        void ProcessGroundCheck()
        {
            var offset = 0.1f;

            var start = transform.position + transform.up * (offset);
            var range = offset + 0.1f;

            Debug.DrawRay(start, -transform.up * range);

            if(Physics.Raycast(start, -transform.up, range, groundMask))
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }

        void ProcessRotation()
        {
            var angles = transform.eulerAngles;

            var target = transform.eulerAngles;

            var direction = animator.GetFloat("Speed");

            if (gravity.direction < 0)
            {
                if (direction < 0f)
                    target.y = 270f;
                else
                    target.y = 180f - 90f;

                target.z = 180f;
            }
            else
            {
                target.z = 0f;

                if (direction >= 0f)
                    target.y = 0f + 90f;
                else
                    target.y = 180f + 90f;
            }

            angles.y = Mathf.MoveTowards(angles.y, target.y, 540f * Time.deltaTime);
            angles.z = Mathf.MoveTowards(angles.z, target.z, 180f * Time.deltaTime);

            transform.eulerAngles = angles;
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

            animator.SetFloat("Speed", 2f);

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

        Collision propCollision;
        void OnCollisionStay(Collision collision)
        {
            var angle = Vector3.Angle(transform.forward, -collision.contacts.First().normal);

            if (angle < 20f)
                propCollision = collision;
            else
            {
                if (propCollision != null && propCollision.gameObject == collision.gameObject)
                    propCollision = null;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (propCollision != null && propCollision.gameObject == collision.gameObject)
                propCollision = null;
        }

        float handsWeight = 0f;
        void OnAnimatorIK(int layerIndex)
        {
            handsWeight = Mathf.MoveTowards(handsWeight, propCollision == null ? 0f : 1f, 2 * Time.deltaTime);

            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, handsWeight);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, handsWeight);

            if (propCollision != null)
            {
                animator.SetIKPosition(AvatarIKGoal.RightHand, propCollision.contacts.First().point + Vector3.up * 0.5f + transform.right * 0.4f);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, propCollision.contacts.First().point + Vector3.up * 0.5f + -transform.right * 0.4f);
            }
        }
    }
}