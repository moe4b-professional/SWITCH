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
	public class JumpPad : MonoBehaviour
	{
        public float multiplier = 2f;

		void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;

            var player = collision.gameObject.GetComponent<Player>();

            player.jump.multiplier = multiplier; 
        }

        void OnCollisionExit(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;

            var player = collision.gameObject.GetComponent<Player>();

            player.jump.multiplier = 1f;
        }
    }
}