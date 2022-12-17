using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    public float sfxVolume = 1f;
    public float musVolume = 1f;
    public float animationSpeed = 1f;
    public int difficulty = 1;

    public float[] difficultyRadii = { 300f, 600f, 900f };
    public float enemySpawnRateMultiplier = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null) // Remove extra instances
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
