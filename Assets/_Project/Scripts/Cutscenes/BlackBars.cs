using Assets._Project.Scripts.Tweens.Interpolations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.Cutscenes
{
    public class BlackBars : MonoBehaviour
    {
        public Image Upper, Lower;

        private Vector3 _upperIn, _upperOut, _lowerIn, _lowerOut;

        void Start()
        {
            _upperOut = Upper.rectTransform.position;
            _lowerOut = Lower.rectTransform.position;
            _upperIn = _upperOut - new Vector3(0f, Upper.rectTransform.rect.height * 0.5f, 0f);
            _lowerIn = _lowerOut + new Vector3(0f, Lower.rectTransform.rect.height * 0.5f, 0f);
        }

        public void SlideIn()
        {
            StartCoroutine(SlideSlow(true));
        }

        public void SlideOut()
        {
            StartCoroutine(SlideSlow(false));
        }

        private IEnumerator SlideSlow(bool slideIn)
        {
            float duration = 0.5f;
            var interpolation = Interpolation.Cubic;

            float current = 0;

            while (current < duration)
            {
                current += Time.deltaTime;
                if (current > duration)
                    current = duration;

                var progress = interpolation.Apply(current / duration);

                if (slideIn)
                {
                    Upper.rectTransform.position = Vector3.Lerp(_upperOut, _upperIn, progress);
                    Lower.rectTransform.position = Vector3.Lerp(_lowerOut, _lowerIn, progress);
                }
                else
                {
                    Upper.rectTransform.position = Vector3.Lerp(_upperIn, _upperOut, progress);
                    Lower.rectTransform.position = Vector3.Lerp(_lowerIn, _lowerOut, progress);
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
