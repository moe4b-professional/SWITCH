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
	public class DoorSwitchControl : MonoBehaviour
	{
        public Switch[] switches;
        public Door[] doors;

        void Start()
        {
            foreach (var sw in switches)
                sw.OnEnter.AddListener(OnSwitchActivated);
        }

        void OnSwitchActivated()
        {
            bool allSwitchesActive = true;

            foreach (var sw in switches)
            {
                if(!sw.Active)
                {
                    allSwitchesActive = false;
                    break;
                }
            }

            if(allSwitchesActive)
            {
                foreach (var door in doors)
                    door.isOpen = true;

                foreach (var sw in switches)
                    sw.enabled = false;
            }
        }
	}
}