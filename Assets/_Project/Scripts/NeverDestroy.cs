using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class NeverDestroy : MonoBehaviour
    {
        void Start()
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
