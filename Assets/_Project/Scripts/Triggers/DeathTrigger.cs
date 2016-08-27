using Assets._Project.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Triggers
{
    public class DeathTrigger : MonoBehaviour
    {
        public Transform RestartPosition;

        void OnTriggerEnter(Collider collider)
        {
            if (collider.transform.root.GetComponent<CharacterMaster>() == null) return;

            collider.transform.root.GetComponent<CharacterMaster>()
                .RestartAt(RestartPosition);
        }
    }
}
