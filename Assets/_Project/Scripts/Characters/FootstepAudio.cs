using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Characters
{
    public class FootstepAudio : MonoBehaviour
    {
        public AudioClip Step1, Step2;

        public void PlayStep(AnimationEvent ev)
        {
            GetComponent<AudioSource>().PlayOneShot(ev.intParameter == 1 ? Step1 : Step2);
        }
    }
}
