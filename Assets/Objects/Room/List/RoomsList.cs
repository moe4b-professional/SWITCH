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
	}
}