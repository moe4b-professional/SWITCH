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
	public class RoomSelectButton : MonoBehaviour
	{
        public int index = 0;

        public GameObject menu;

		void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            Level.Instance.roomsList.TeleportPlayers(index);

            menu.SetActive(false);
            Level.Instance.InGameUI.pauseMenu.SetActive(false);
        }
	}
}