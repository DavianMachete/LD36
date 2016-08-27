using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Triggers
{
    public class EnableComponentOnTrigger : MonoBehaviour
    {
        public Behaviour Target;
        public LayerMask Mask;
        private bool _triggered;

        void OnTriggerEnter(Collider collider)
        {
            if (_triggered) return;
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            if(Target != null)
                Target.enabled = true;


            _triggered = true;
        }
    }
}
