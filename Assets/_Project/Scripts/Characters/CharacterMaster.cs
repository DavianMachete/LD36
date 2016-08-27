using Assets._Project.Scripts.Characters.Control;
using Assets._Project.Scripts.Characters.Puppet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
            Debug.Log("Disable control");
            UserControl.enabled = false;
            CharacterControl.enabled = false;
        }

        public void EnableControl()
        {
            Debug.Log("Enable control");
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
    }
}
