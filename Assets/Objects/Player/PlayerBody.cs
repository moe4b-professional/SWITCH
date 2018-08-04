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
	public class PlayerBody : MonoBehaviour
	{
        public event Action<int> AnimatorIKEvent;
        void OnAnimatorIK(int layerIndex)
        {
            if (AnimatorIKEvent != null) AnimatorIKEvent.Invoke(layerIndex);
        }

    }
}