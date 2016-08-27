using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Cutscenes
{
    public class CutsceneTrigger : MonoBehaviour
    {
        public string CutSceneName;
        private bool _trigged;

        void OnTriggerEnter(Collider collider)
        {
            if (_trigged) return;

            CutsceneManager.Get().PlayCutscene(CutSceneName);
            _trigged = true;
        }
    }
}
