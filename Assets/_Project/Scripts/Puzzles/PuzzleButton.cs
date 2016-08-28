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


        public event ButtonPushed OnPushed;

        private bool _canBePushed;
        private PositionLerp _lerp;
        private Vector3 _initialPosition;
        private bool _characterIsInside = false;

        void Start()
        {
            _initialPosition = PhysicalButton.transform.position;
            _lerp = PhysicalButton.gameObject.AddComponent<PositionLerp>();
            _canBePushed = true;
        }

        public void Reset()
        {
            var wasPushed = Pushed;
            Pushed = false;

            if (wasPushed)
            {
                var collider = GetComponent<BoxCollider>();
                // check if the character is in the button
                if (!_characterIsInside)
                {
                    _lerp.Lerp(_initialPosition + new Vector3(0f, -2f, 0f), _initialPosition, PhysicalButton.rotation, PhysicalButton.rotation, 1f);
                    _canBePushed = true;
                }
                else
                {
                    //Debug.Log("Character is in " + gameObject.name + " waiting for exit");
                }
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (!_canBePushed) return;
            if (Pushed) return;
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            _lerp.Lerp(_initialPosition, _initialPosition + new Vector3(0f, -2f, 0f), PhysicalButton.rotation, PhysicalButton.rotation, 1f);

            Pushed = true;

            if (OnPushed != null)
                OnPushed();

            _canBePushed = false;
        }

        void OnTriggerStay(Collider collider)
        {
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;
            _characterIsInside = true;        
        }

        void LateUpdate()
        {
            _characterIsInside = false;
        }

        void OnTriggerExit(Collider collider)
        {
            if ((Mask.value | (1 << collider.gameObject.layer)) != Mask.value)
                return;

            if (!_canBePushed && !Pushed)
            {
                _lerp.Lerp(_initialPosition + new Vector3(0f, -2f, 0f), _initialPosition, PhysicalButton.rotation, PhysicalButton.rotation, 1f);
                _canBePushed = true;
                //Debug.Log("Character exiting " + gameObject.name + ", pushin up butn");
            }
        }
    }

    public delegate void ButtonPushed();
}
