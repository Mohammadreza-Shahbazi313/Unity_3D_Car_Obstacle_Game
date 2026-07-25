using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowtoWin : MonoBehaviour
{
	public GameObject winPanel;
	public Text resultText;

	private void Start()
	{
		if (winPanel != null)
			winPanel.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (resultText != null)
				resultText.text = "YOU WIN !";

			if (gameManager.Instance != null)
				gameManager.Instance.ShowWinFinalScore();

			if (winPanel != null)
				winPanel.SetActive(true);

			Time.timeScale = 0f;
		}
	}

	public void restartGame()
	{
		Time.timeScale = 1f;

		if (gameManager.Instance != null)
			gameManager.Instance.ResetScore();

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;

		if (gameManager.Instance != null)
			gameManager.Instance.ResetScore();

		SceneManager.LoadScene("MainMenu");
	}
}