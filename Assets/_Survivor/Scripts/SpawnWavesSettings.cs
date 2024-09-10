using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/SpawnWaves")]
public class SpawnWavesSettings : ScriptableObject
{
    public Wave[] Waves;

    [Serializable]
    public struct Wave
    {
        public float TimeSinceLastWave;
        public SpawnPatternSettings SpawnPattern;
    }
}
