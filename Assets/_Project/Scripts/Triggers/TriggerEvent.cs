using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Project.Scripts.Triggers
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent Event;
        public LayerMask Mask;

        public bool AllowRetrigger = false;
        private bool _triggered;

        void OnTriggerEnter(Collider collider)
        {
            if (_triggered) return;
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            if(Event != null)
                Event.Invoke();

            _triggered = true;
        }

        void OnTriggerExit(Collider collider)
        {
            if (!AllowRetrigger) return;
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            _triggered = false;
        }
    }
}
