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
    public class RoomsList : MonoBehaviour
    {
        public List<Room> list;

        public Room GetNext(Room current)
        {
            try
            {
                var index = list.IndexOf(current);

                return list[index + 1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Room GetPrevious(Room current)
        {
            try
            {
                var index = list.IndexOf(current);

                return list[index - 1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void TeleportPlayers(int roomIndex)
        {
            TeleportPlayers(list[roomIndex]);
        }
        public void TeleportPlayers(Room room)
        {
            var player1 = Level.Instance.player1;
            var player2 = Level.Instance.player2;

            SetXPosition(player1.transform, room.GetEntranceXPosition() - 0.3f, -9f);
            SetXPosition(player2.transform, room.GetEntranceXPosition() + 0.3f, 9f);

            player1.gravity.direction = 1;
            player2.gravity.direction = -1;

            var followCamera = Level.Instance.FollowCamera;

            SetXPosition(followCamera.transform, room.transform.position.x, 0f);
        }

        void SetXPosition(Transform transform, float value, float y)
        {
            var position = transform.position;

            position.x = value;
            position.y = y;

            transform.position = position;
        }
	}
}