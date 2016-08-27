using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Cameras
{
    public class PositionLerp : MonoBehaviour
    {
        private bool _lerping;
        private float _duration = 0f;
        private float _current;
        private Vector3 _start, _target;
        private Quaternion _startRotation, _targetRotation;

        public void Lerp(Vector3 start, Vector3 target, Quaternion startRotation, Quaternion targetRotation, float duration)
        {
            _lerping = true;
            _duration = duration;
            _current = 0f;
            _start = start;
            _target = target;
            _startRotation = startRotation;
            _targetRotation = targetRotation;
        }

        public void Update()
        {
            if (_current >= _duration)
                return;

            _current += Time.deltaTime;

            if (_current > _duration)
                _current = _duration;

            float progress = Mathf.SmoothStep(0f, 1f, _current / _duration);

            transform.position = Vector3.Lerp(_start, _target, progress);
            transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, progress);
        }
    }
}
