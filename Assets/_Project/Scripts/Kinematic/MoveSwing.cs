using Assets._Project.Scripts.Tweens.Interpolations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Kinematic
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveSwing : MonoBehaviour
    {
        public Vector3 RelativeOffset;
        public float Duration = 1f;

        public float StartDelay = 0f;

        public InterpolationType Type;

        private Vector3 _target;
        private Vector3 _start;
        private Rigidbody _rigidbody;

        private bool _in;

        private float _current = 0f;


        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;

            _start = transform.position;
            _target = _start + RelativeOffset;
            _in = true;
        }

        void FixedUpdate()
        {
            if(StartDelay > 0f)
            {
                StartDelay -= Time.deltaTime;
                return;
            }

            _current += Time.deltaTime;

            if (_current > Duration)
            {
                _current = 0f;
                _in = !_in;
            }
            if (_current > Duration)
                _current = Duration;

            var progress = _current / Duration;

            var interpolation = Interpolation.Get(Type);

            if (_in)
            {
                _rigidbody.MovePosition(Vector3.Lerp(_start, _target, interpolation.Apply(progress)));
            }
            else
            {
                _rigidbody.MovePosition(Vector3.Lerp(_target, _start, interpolation.Apply(progress)));
            }
        }
    }
}
