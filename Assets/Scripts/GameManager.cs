using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public int leftScore;
    public int rightScore;
    public bool humanVsCPU;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GM").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void ResetScore()
    {
        leftScore = rightScore = 0;
    }

    public bool IsGameOver()
    {
        return leftScore > 3 || rightScore > 3;
    }

    public void AddScore(int left, int right)
    {
        leftScore += left;
        rightScore += right;

        Text leftScoreText = GameObject.Find("Player1Score").GetComponent<Text>();
        Text rightScoreText = GameObject.Find("Player2Score").GetComponent<Text>();

        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();

        if (IsGameOver())
        {
            // Load 'game over' scene
            //SceneManager.LoadScene("GameOver");
        }
    }
}
