using UnityEngine;
using UnityEngine.Assertions;

public class Level : MonoBehaviour
{
    public static LevelConfig CurrentLevel { get; private set; }

    [RuntimeInitializeOnLoadMethod]
    static void ResetDomain()
    {
        CurrentLevel = null;
    }

    [SerializeField] LevelConfig _config;


    void Awake()
    {
        Assert.IsNotNull(_config, "Missing level config");
       CurrentLevel = _config;
    }

    void Start()
    {
        var hero = Hero.Instance;
        Assert.IsNotNull(hero, "missing hero");

        var spawnPoint = FindAnyObjectByType<HeroSpawnPoint>();
        Assert.IsNotNull(spawnPoint, "Missing HeroSpawnPoint");
        hero.Teleport(spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

}
