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
	public class LaserSource : MonoBehaviour
	{
        public LineRenderer line;
        public Vector3 Point1
        {
            get
            {
                return line.GetPosition(0);
            }
            set
            {
                line.SetPosition(0, value);
            }
        }
        public Vector3 Point2
        {
            get
            {
                return line.GetPosition(1);
            }
            set
            {
                line.SetPosition(1, value);
            }
        }

        public Vector3 Direction { get { return transform.up; } }

        public const float Range = 200f;

        public LayerMask mask = Physics.DefaultRaycastLayers;

        RaycastHit hit;

        void Start()
        {
            line.useWorldSpace = true;
        }

        void Update()
        {
            Point1 = transform.position;

            if(Physics.Raycast(transform.position, Direction, out hit, Range, mask, QueryTriggerInteraction.Ignore))
            {
                line.enabled = true;
                Point2 = hit.point;

                ProcessHit();
            }
            else
            {
                Point2 = transform.position + Direction * Range;
            }
        }

        LaserSwitch activatedSwitch;
        void ProcessHit()
        {
            var newSwitch = hit.transform.GetComponent<LaserSwitch>();

            if (newSwitch == null)
            {
                if(activatedSwitch != null)
                {
                    activatedSwitch.SetActive(false);
                    activatedSwitch = null;
                }
            }
            else
            {
                if (activatedSwitch != null)
                    activatedSwitch.SetActive(false);

                activatedSwitch = newSwitch;
                newSwitch.SetActive(true);
            }
        }
	}
}