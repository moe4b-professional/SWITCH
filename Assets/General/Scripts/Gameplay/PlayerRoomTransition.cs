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
	public class PlayerRoomTransition : MonoBehaviour
	{
        public Level Level { get { return Level.Instance; } }
        public FollowCamera followCamera { get { return Level.FollowCamera; } }
        public Player Player1 { get { return Level.player1; } }
        public Player Player2 { get { return Level.player2; } }

        public float speed = 5f;

        public Room current;
        public Room target;

        void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                if(coroutine == null)
                {
                    coroutine = StartCoroutine(Procedure());
                }
            }
        }

        Coroutine coroutine;
        IEnumerator Procedure()
        {
            Player1.control = Player2.control = false;

            followCamera.MoveTo(target.transform.position.x);
            var playerXTarget = target.transform.position.x - (target.Bounds.extents.x - 5f);
            Player1.NavigateTo(playerXTarget);
            Player2.NavigateTo(playerXTarget);

            while (true)
            {
                if (Player1.IsNavigating || Player2.IsNavigating || followCamera.IsMoving)
                    yield return new WaitForEndOfFrame();
                else
                    break;
            }

            Player1.control = Player2.control = true;

            foreach (var door in current.doors)
                door.isOpen = false;
        }
    }
}