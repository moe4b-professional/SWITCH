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

        public bool IsOpen = false;

        float openSpeed = 5f;

        float startingHeight;

        void Start()
        {
            startingHeight = transform.position.y;
        }

        void Update()
        {
            if (IsOpen)
                MoveToHeight(openHeight);
            else
                MoveToHeight(startingHeight);
        }

        void MoveToHeight(float height)
        {
            var targetPosition = transform.position;

            targetPosition.y = height;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, openSpeed * Time.deltaTime);
        }
	}
}