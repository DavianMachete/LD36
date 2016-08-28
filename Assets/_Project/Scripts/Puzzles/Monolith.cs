using Assets._Project.Scripts.Kinematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Puzzles
{
    public class Monolith : MonoBehaviour
    {
        public GameObject TabletActivator;

        public void ActivateMonolith()
        {
            if(TabletActivator != null)
            {
                TabletActivator.GetComponent<Move>().enabled = true;
            }
        }
    }
}
