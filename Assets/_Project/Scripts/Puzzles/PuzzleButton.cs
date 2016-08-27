using Assets._Project.Scripts.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Puzzles
{
    public class PuzzleButton : MonoBehaviour
    {
        public bool Pushed;

        public LayerMask Mask;
        public Transform PhysicalButton;

        private bool _canBePushed;
        private PositionLerp _lerp;
        private Vector3 _initialPosition;

        void Start()
        {
            _initialPosition = PhysicalButton.transform.position;
            _lerp = PhysicalButton.gameObject.AddComponent<PositionLerp>();
            _canBePushed = true;
        }

        public void Reset()
        {
            Pushed = false;
        }

        void OnTriggerEnter(Collider collider)
        {
            if (!_canBePushed) return;
            if (Pushed) return;
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            _lerp.Lerp(_initialPosition, _initialPosition + new Vector3(0f, -2f, 0f), PhysicalButton.rotation, PhysicalButton.rotation, 2f);

            Pushed = true;
            _canBePushed = false;
        }

        void OnTriggerExit(Collider collider)
        {
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            if (!_canBePushed && !Pushed)
            {
                _lerp.Lerp(_initialPosition + new Vector3(0f, -2f, 0f), _initialPosition, PhysicalButton.rotation, PhysicalButton.rotation, 2f);
                _canBePushed = true;
            }
        }
    }
}
