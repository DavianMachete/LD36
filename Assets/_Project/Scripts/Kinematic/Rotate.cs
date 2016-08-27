using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Kinematic
{
    public class Rotate : MonoBehaviour
    {
        public float Speed = 0.1f;
        public bool X, Y, Z = true;

        private Rigidbody _body;

        void Start()
        {
            _body = GetComponent<Rigidbody>();
            _body.isKinematic = true;
        }

        void FixedUpdate()
        {
            float rotation = Speed * Time.deltaTime;

            if (X)
                _body.MoveRotation(transform.rotation * Quaternion.Euler(rotation, 0f, 0f));
            if (Y)
                _body.MoveRotation(transform.rotation * Quaternion.Euler(0, rotation, 0f));
            if (Z)
                _body.MoveRotation(transform.rotation * Quaternion.Euler(0, 0f, rotation));
        }
    }
}
