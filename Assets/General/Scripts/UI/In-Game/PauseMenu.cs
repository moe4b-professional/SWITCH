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
	public class PauseMenu : MonoBehaviour
	{
        public bool active = false;
        public void SetActive(bool value)
        {
            active = value;
            gameObject.SetActive(active);
        }

		void Update()
        {
            
        }
	}
}