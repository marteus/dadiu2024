using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] GameOverScreen _gameOver;

    [Header("Debug")]
    [SerializeField] LevelConfig _defaultLevel;

    enum GameState
    {
        Playing,
        GameOver,
    }

    GameState _currentState;

    void Start()
    {
        if (Level.CurrentLevel == null)
        {
            _defaultLevel.LoadLevel();
            return;
        }

        _gameOver.gameObject.SetActive(false);
        _gameOver.RestartRequested += () => Level.CurrentLevel.LoadLevel();

        _hero.Health.Died.AddListener(()=>
        {
            _gameOver.gameObject.SetActive(true);
            _currentState = GameState.GameOver;
        });

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _hero.Health.TakeDamage(1000);
        }
    }

}
