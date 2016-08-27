using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Cameras
{
    public class LookAt : MonoBehaviour
    {
        public Transform Target;
        public float Damping = 0.15f;

        void LateUpdate()
        {
            if (Target == null) return;

            var f = Target.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(f), Damping);
        }
    }
}
