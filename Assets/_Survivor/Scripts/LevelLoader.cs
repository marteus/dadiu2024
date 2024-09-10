using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public LevelConfig Level;

    void Awake()
    {
        Assert.IsNotNull(Level, "Missing Level");
        Level.LoadLevel();
    }


}
