using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._Project.Scripts.GameStates
{
    public class GameState : MonoBehaviour
    {
        public Transform CurrentSpawnPoint;

        public Transform[] AllSpawnPoints;


        public void SetSpawnPoint(int index)
        {
            CurrentSpawnPoint = AllSpawnPoints[index];
        }

        public static GameState Get()
        {
            return GameObject.Find("GameState").GetComponent<GameState>();
        }
    }
}
