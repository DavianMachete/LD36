using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.Puzzles
{
    public class ButtonPuzzle : MonoBehaviour
    {
        public Behaviour EnableOnCompleted;


        public PuzzleButton Button1;
        public PuzzleButton Button2;
        public PuzzleButton Button3;
        public PuzzleButton Button4;

        private PuzzleButton[] _allButtons;

        private bool _cleared;

        void Start()
        {
            _allButtons = new[]
            {
                Button1,
                Button2,
                Button3,
                Button4
            };
        }

        void Update()
        {
            if (_cleared) return;

            if(_allButtons.Any(x => x.Pushed))
            {
                if (PuzzleSolved())
                {
                    OpenDoor();
                    return;
                }

                if (ValidSoFar())
                {
                    // await other pushes
                }
                else
                {
                    ResetButtons();
                }
            }
        }

        private void ResetButtons()
        {
            foreach(var button in _allButtons)
            {
                button.Reset();
            }
        }

        private bool ValidSoFar()
        {
            return true; // TODO:
        }

        private void OpenDoor()
        {
            EnableOnCompleted.enabled = true;
        }

        private bool PuzzleSolved()
        {
            // TODO: order... should be section 1, 2, then 3 and 4 should show on the door
            return _allButtons.All(x => x.Pushed);
        }
    }
}
