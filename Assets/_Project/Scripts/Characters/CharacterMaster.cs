using Assets._Project.Scripts.Characters.Control;
using Assets._Project.Scripts.Characters.Puppet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using Assets._Project.Scripts.Cameras;
using Assets._Project.Scripts.GameStates;

namespace Assets._Project.Scripts.Characters
{
    public class CharacterMaster : MonoBehaviour
    {
        public PuppetController PuppetController;
        public CharacterUserControl UserControl;
        public CharacterControlComponent CharacterControl;
        public Animator Animator;

        public void DisableControl()
        {
            //Debug.Log("Disable control");
            UserControl.enabled = false;
            CharacterControl.enabled = false;
        }

        public void RestartAt(Transform target)
        {
            StartCoroutine(SlowRestart(target));
        }

        private IEnumerator SlowRestart(Transform target)
        {
            ResetPuppet(target);
            Camera.main.GetComponent<SmoothFollow>().Reset(target);
            DisableControl();
            yield return new WaitForSeconds(2);
            EnableControl();
        }

        private void ResetPuppet(Transform target)
        {
            PuppetController.BehaviourPuppet.Reset(target.position, target.rotation);
            PuppetController.PuppetMaster.Resurrect();
            PuppetController.BehaviourPuppet.Resurrect();
            // clear forces
            foreach(var muscle in PuppetController.PuppetMaster.muscles)
            {
                muscle.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                muscle.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            PuppetController.OnRegainBalance();

        }

        public void EnableControl()
        {
            //Debug.Log("Enable control");
            UserControl.enabled = true;
            CharacterControl.enabled = true;
        }

        public void SitDown()
        {
            Animator.SetBool("sitting", true);
        }

        public void StopSittingDown()
        {
            Animator.SetBool("sitting", false);
        }

        public void Update()
        {
            if (Input.GetButtonDown("Respawn"))
            {
                RestartAt(GameState.Get().CurrentSpawnPoint);
            }
        }
    }
}
