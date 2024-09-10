using UnityEngine;


[CreateAssetMenu(menuName = "Game/SpawnPatternSettings")]
public class SpawnPatternSettings : ScriptableObject
{
    public SpawnEntry[] Entries;

    [System.Serializable]
    public struct SpawnEntry
    {
        public Mob Prefab;
        public Vector2 WorldOffset;
    }
}
