using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Project.Scripts.SceneControllers
{
    public class TitleSceneController : MonoBehaviour
    {
        public string GotoScene;

        public void Update()
        {
            if (Input.GetButtonDown("Respawn"))
            {
                SceneManager.LoadScene(GotoScene);
            }
        }
    }
}
