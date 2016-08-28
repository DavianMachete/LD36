using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Cameras
{
    public class CamZone : MonoBehaviour
    {
        public Transform TargetAnchor;
        public LayerMask CharacterMask;

        void OnTriggerStay(Collider collider)
        {
            if (TargetAnchor == null) return;
            if ((CharacterMask.value | (1 << collider.gameObject.layer)) != CharacterMask.value)
                return;

            var follow = Camera.main.GetComponent<SmoothFollow>();
            if (!follow.enabled) return;

            follow.AnchorTarget = TargetAnchor;
        }

        void OnTriggerExit(Collider collider)
        {
            if (TargetAnchor == null) return;
            if ((CharacterMask.value | (1 << collider.gameObject.layer)) != CharacterMask.value)
                return;

            var follow = Camera.main.GetComponent<SmoothFollow>();
            follow.AnchorTarget = null;
        }
    }
}
