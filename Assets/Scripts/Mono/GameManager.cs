using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Manager must be a singleton
    public static GameManager Instance { get; private set; }

    [SerializeField] public Bird bird;
    [SerializeField] public TextMeshProUGUI scoreText;

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

    private void Pause()
    {
        Time.timeScale = 0f;
        bird.enabled = false;
    }

    public void GameOver()
    {
        Pause();
    }

    public void Reset()
    {
        bird.Reset();
        Score = 0;
        scoreText.SetText(Score.ToString());
    }

    public void AddScore()
    {
        ++Score;
        scoreText.SetText(Score.ToString());
    }

}
