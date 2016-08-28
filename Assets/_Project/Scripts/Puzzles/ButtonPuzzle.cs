using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Project.Scripts.Puzzles
{
    public class ButtonPuzzle : MonoBehaviour
    {
        public Behaviour EnableOnCompleted;

        public UnityEvent OnPuzzleSucceded;

        public PuzzleButton Button1;
        public PuzzleButton Button2;
        public PuzzleButton Button3;
        public PuzzleButton Button4;

        private PuzzleButton[] _allButtons;

        private bool _cleared;
        private List<int> _pushQueue;

        void Start()
        {
            _pushQueue = new List<int>();
            _allButtons = new[]
            {
                Button1,
                Button2,
                Button3,
                Button4
            };

            int index = 0;
            foreach (var button in _allButtons)
            {
                int ii = index;
                button.OnPushed += () => ButtonPushed(ii);
                index++;
            }
        }

        private void ButtonPushed(int index)
        {
            _pushQueue.Add(index);
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
            //Debug.Log("Failed - Resetting buttons");
            _pushQueue.Clear();
            foreach(var button in _allButtons)
            {
                button.Reset();
            }
        }

        private bool ValidSoFar()
        {
            for (int i = 0; i < _pushQueue.Count; i++)
            {
                if (i != _pushQueue[i])
                    return false;
            }
            return true;
        }

        private void OpenDoor()
        {
            EnableOnCompleted.enabled = true;
            _cleared = true;

            if (OnPuzzleSucceded != null)
            {
                OnPuzzleSucceded.Invoke();
            }
        }

        private bool PuzzleSolved()
        {
            return _allButtons.All(x => x.Pushed) &&
                    ValidSoFar() &&
                    _allButtons.Length == _pushQueue.Count;
        }
    }
}
