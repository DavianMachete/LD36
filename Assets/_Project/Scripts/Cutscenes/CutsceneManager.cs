using Assets._Project.Scripts.Cameras;
using Assets._Project.Scripts.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

namespace Assets._Project.Scripts.Cutscenes
{
    public class CutsceneManager : MonoBehaviour
    {
        public CharacterMaster Character;
        public Transform CharacterCamTarget;

        public Cutscene1Params CS1Params;
        public CutscenePuzzleSolvedParams PuzzleSolvedParams;
        public EndCutsceneParams EndParams;

        private Dictionary<string, Func<IEnumerator>> _cutscenes;

        void Start()
        {
            _cutscenes = new Dictionary<string, Func<IEnumerator>>();
            _cutscenes.Add("cutscene_1", () => Cutscene1());
            _cutscenes.Add("cutscene_2", () => Cutscene2());
            _cutscenes.Add("puzzle_solved", () => CutscenePuzzleSolved());
            _cutscenes.Add("ending", () => CutsceneEnding());
        }

        public static CutsceneManager Get()
        {
            return GameObject.Find("CutSceneManager").GetComponent<CutsceneManager>();
        }

        public void PlayCutscene(string name)
        {
            if (_cutscenes.ContainsKey(name))
            {
                StartCoroutine(PlayCutscene(_cutscenes[name]));
                return;
            }
            Debug.LogError("Tried to play cutscene " + name + ", but it doesn't exist");
        }

        private IEnumerator PlayCutscene(Func<IEnumerator> cutsceneCallback)
        {
            Character.SitDown();
            ShowCutsceneBorders();
            yield return cutsceneCallback();
            HideCutsceneBorders();
            Character.StopSittingDown();
        }

        private void HideCutsceneBorders()
        {
            // TODO:
        }

        private void ShowCutsceneBorders()
        {
            // TODO:
        }

        private IEnumerator Cutscene1()
        {
            yield return new WaitForEndOfFrame();
            Character.DisableControl();
            SetCameraTarget(CS1Params.Monolith.transform.GetChild(0)); // TODO: won't work later
            yield return new WaitForSeconds(2f);
            yield return new WaitForSeconds(SetPlayerCamera());
            Character.EnableControl();
        }

        private IEnumerator Cutscene2()
        {
            yield return new WaitForEndOfFrame();
            Character.DisableControl();
            SetCameraTarget(CS1Params.Monolith.transform.GetChild(0)); // TODO: won't work later
            yield return new WaitForSeconds(1f);
            yield return new WaitForSeconds(SetPlayerCamera(1f));
            Character.EnableControl();
        }

        private IEnumerator CutscenePuzzleSolved()
        {
            yield return new WaitForEndOfFrame();
            SetCameraTarget(PuzzleSolvedParams.Door);
            yield return new WaitForSeconds(3f);
            yield return new WaitForSeconds(SetPlayerCamera(0.5f));
        }

        private IEnumerator CutsceneEnding()
        {
            yield return new WaitForEndOfFrame();
            Character.DisableControl();

            for (int i = 0; i < EndParams.TorchesRoot.transform.childCount; i++)
            {
                var torch = EndParams.TorchesRoot.transform.GetChild(i).gameObject;
                torch.transform.GetChild(0).gameObject.SetActive(true);
                SetCameraTarget(torch.transform);                
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(SetPlayerCamera(6f));

            SceneManager.LoadScene(EndParams.GameOverScene);
        }


        private Vector3 _lastPlayerCamPosition;
        private Quaternion _lastPlayerCamRotation;

        private void SetCameraTarget(Transform transform)
        {
            var cam = Camera.main;
            cam.GetComponent<DepthOfField>().focalTransform = transform;
            cam.GetComponent<SmoothFollow>().enabled = false;
            cam.GetComponent<LookAt>().enabled = true;
            cam.GetComponent<LookAt>().Target = transform;
            _lastPlayerCamPosition = cam.transform.position;
            _lastPlayerCamRotation = cam.transform.rotation;
        }

        private float SetPlayerCamera(float lerpDuration = 2f)
        {
            var cam = Camera.main;
            cam.GetComponent<PositionLerp>().Lerp(cam.transform.position, _lastPlayerCamPosition, cam.transform.rotation, _lastPlayerCamRotation, lerpDuration);
            StartCoroutine(SetPlayerCameraAfter(lerpDuration));

            return lerpDuration;
        }

        private IEnumerator SetPlayerCameraAfter(float duration)
        {
            yield return new WaitForSeconds(duration);

            var cam = Camera.main;

            cam.GetComponent<DepthOfField>().focalTransform = CharacterCamTarget;
            cam.GetComponent<SmoothFollow>().target = CharacterCamTarget;
            cam.GetComponent<SmoothFollow>().enabled = true;
            cam.GetComponent<LookAt>().enabled = false;
        }
    }

    [Serializable]
    public class Cutscene1Params
    {
        public GameObject Monolith;
    }
    [Serializable]
    public class CutscenePuzzleSolvedParams
    {
        public Transform Door;
    }
    [Serializable]
    public class EndCutsceneParams
    {
        public Transform TorchesRoot;
        public string GameOverScene;
    }
}
