using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Button _restartButton;

    public event System.Action RestartRequested;

    void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartClicked);
    }

    void OnRestartClicked()
    {
        RestartRequested?.Invoke();
    }

}
