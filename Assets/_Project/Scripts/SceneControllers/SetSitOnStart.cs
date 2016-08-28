using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.SceneControllers
{
    public class SetSitOnStart : MonoBehaviour
    {
        public Animator Animator;

        void Start()
        {
            Animator.SetBool("sitting", true);
        }
    }
}
