using RootMotion.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Characters.Puppet
{
    public class PuppetController : MonoBehaviour
    {
        public PuppetMaster PuppetMaster;
        public BehaviourPuppet BehaviourPuppet;

        public List<Behaviour> DisableOnLoseBalance = new List<Behaviour>();
        public List<Collider> DisableOnLoseBalanceColliders = new List<Collider>();
        public Rigidbody Rigidbody;

        public void OnBalanceLost()
        {
            //Debug.Log("Balance Lost");
            SetComponentsEnabled(false);
        }

        public void OnRegainBalance()
        {
            //Debug.Log("Balance Regained");
            SetComponentsEnabled(true);
        }


        private void SetComponentsEnabled(bool enabled)
        {
            Rigidbody.isKinematic = !enabled;

            if (DisableOnLoseBalance != null)
                foreach (var component in DisableOnLoseBalance)
                    component.enabled = enabled;

            if(DisableOnLoseBalanceColliders != null)
                foreach (var collider in DisableOnLoseBalanceColliders)
                    collider.enabled = enabled;
        }
    }
}
