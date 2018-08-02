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
	public class Door : MonoBehaviour
	{
        public float openHeight;

        public bool isOpen = false;

        public float startingHeight;

        public float speed = 5f;

        void Start()
        {
            startingHeight = transform.position.y;
        }

        void Update()
        {
            if (isOpen)
                MoveTo(openHeight);
            else
                MoveTo(startingHeight);
        }

        void MoveTo(float height)
        {
            var targetPosition = transform.position;
            targetPosition.y = height;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
	}
}