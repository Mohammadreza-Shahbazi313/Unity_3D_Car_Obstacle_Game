using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
	public static gameManager Instance;

	public int score = 0;
	public Text scoreText;

	public Text winFinalScoreText;
	public Text loseFinalScoreText;

	public GameObject pauseScreenUI;
	public GameObject onScreenUI;
	public Text timerText;
	public float levelTimeLimit = 15f;
	private float timeRemaining;
	private bool timerRunning = true;
	public PlayerCollision playerCollision;	

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
	}
		
	private void Start()
	{
    ResetTimer();

    UpdateScoreUI();

	onScreenUI.SetActive(true);

	}

	private void Update()
	{
		if (timerRunning && Time.timeScale > 0f)
{
	timeRemaining -= Time.deltaTime;

	if (timeRemaining <= 0f)
	{
		timeRemaining = 0f;
		timerRunning = false;
		UpdateTimerUI();

		if (playerCollision != null)
			playerCollision.ShowGameOver();
	}
	else
	{
		UpdateTimerUI();
	}
}
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartGame();
		}

	
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1f)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
			
		}
	}
		
	public void AddScore(int value)
	{
		score += value;
		UpdateScoreUI();
	}

	public void ResetScore()
	{
		score = 0;
		UpdateScoreUI();
	}

	private void UpdateScoreUI()
	{
		if (scoreText != null)
			scoreText.text = "Score : " + score;
	}

	private void UpdateTimerUI()
	{
	if (timerText != null)
		timerText.text = "Time : " + timeRemaining.ToString("0.0");
	}
	
	public void ResetTimer()
	{
	timeRemaining = levelTimeLimit;
	timerRunning = true;
	UpdateTimerUI();
	}

	public void AddTime(float value)
	{
	timeRemaining += value;
	UpdateTimerUI();
	}

	public void ShowWinFinalScore()
	{
		if (winFinalScoreText != null)
			winFinalScoreText.text = "Score : " + score;
	}

	public void ShowLoseFinalScore()
	{
		if (loseFinalScoreText != null)
			loseFinalScoreText.text = "Score : " + score;
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;

		if (pauseScreenUI != null)
			pauseScreenUI.SetActive(true);

		if (onScreenUI != null)
			onScreenUI.SetActive(false);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;

		if (pauseScreenUI != null)
			pauseScreenUI.SetActive(false);

		if (onScreenUI != null)
			onScreenUI.SetActive(true);
	}


	public void RestartGame()
	{
		Time.timeScale = 1f;

		ResetScore();
		ResetTimer();
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;

		ResetScore();
		ResetTimer();

		SceneManager.LoadScene("MainMenu");
	}
	public void NextLevel()
	{
		Time.timeScale = 1f;

		ResetScore();
		ResetTimer();

		SceneManager.LoadScene("Level02");
	}


	
}