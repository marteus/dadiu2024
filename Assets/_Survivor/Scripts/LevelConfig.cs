using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Game/Level")]
public class LevelConfig : ScriptableObject
{
    public string SceneName;


    public async void LoadLevel()
    {
        Debug.Log("Loading level " + name, this);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        var scene = SceneManager.GetSceneByName(SceneName);
        while (!scene.isLoaded)
        {
            await Task.Yield();
        }
        bool loaded = SceneManager.SetActiveScene(scene);
    }
}
