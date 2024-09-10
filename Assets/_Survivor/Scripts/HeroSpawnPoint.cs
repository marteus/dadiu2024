using UnityEngine;

public class HeroSpawnPoint : MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position + Vector3.up * 0.5f, Vector3.one);
    }

}
