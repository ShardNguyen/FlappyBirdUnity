using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Manager must be a singleton
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void AddScore()
    {
        ++Score;
        Debug.Log(Score);
    }
}
