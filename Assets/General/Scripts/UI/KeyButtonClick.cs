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
	public class KeyButtonClick : MonoBehaviour
	{
        public KeyCode key = KeyCode.Escape;

        Button button;

        void Start()
        {
            button = GetComponent<Button>();
        }

        void Update()
        {
            if (Input.GetKeyDown(key))
                button.onClick.Invoke();
        }
	}
}