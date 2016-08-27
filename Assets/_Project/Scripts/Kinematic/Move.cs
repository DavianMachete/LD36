using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Kinematic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Move : MonoBehaviour
    {
        public Vector3 RelativeOffset;
        public float Duration = 1f;

        private Vector3 _target;
        private Vector3 _start;
        private Rigidbody _rigidbody;

        private float _current = 0f;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;

            _start = transform.position;
            _target = _start + RelativeOffset;
        }

        void FixedUpdate()
        {
            if (_current >= Duration)
                return;

            _current += Time.deltaTime;

            if(_current >= Duration)
                _current = Duration;

            var progress = _current / Duration;

            _rigidbody.MovePosition(Vector3.Lerp(_start, _target, progress));
        }
    }
}
