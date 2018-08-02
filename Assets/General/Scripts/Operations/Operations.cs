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
	public static class Operations
	{
        public static void ExecuteAll(GameObject gameObject)
        {
            ExecuteAll(gameObject, true);
        }
        public static void ExecuteAll(GameObject gameObject, bool includeChildern)
        {
            Interface[] operations;

            if (includeChildern)
                operations = gameObject.GetComponentsInChildren<Interface>();
            else
                operations = gameObject.GetComponents<Interface>();

            foreach (var operation in operations)
                Execute(operation);
        }

        public static void Execute(Interface operation)
        {
            operation.Execute();
        }

		public interface Interface
        {
            void Execute();
        }
	}
}