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
	public class InGameUI : MonoBehaviour
	{
        public Level Level { get { return Level.Instance; } }

        public PauseMenu pauseMenu;

        void Update()
        {
            if(!pauseMenu.active && Input.GetKeyDown(KeyCode.Escape))
            {
                if (Level.IsPlaying)
                {
                    pauseMenu.SetActive(true);
                }
            }
        }
	}
}