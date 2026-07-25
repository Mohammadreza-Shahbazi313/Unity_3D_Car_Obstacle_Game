using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
	public GameObject gameOverPanel;
	public Text resultText;
	public Text healthText;

	public int health = 3;
	public float hitCooldown = 1f;

	private bool canTakeHit = true;

	void Start()
	{
		if (gameOverPanel != null)
			gameOverPanel.SetActive(false);

		UpdateHealthUI();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!canTakeHit)
			return;

		if (collision.gameObject.CompareTag ("Obstacle")) {
			canTakeHit = false;
			health--;
			UpdateHealthUI ();

			if (health <= 0) {
				ShowGameOver ();
			} else {
				Invoke ("ResetHit", hitCooldown);
			}
		} else if (collision.gameObject.CompareTag ("Barrel")) {
			health = 0;
			UpdateHealthUI ();
			ShowGameOver ();
			}
	    else if (collision.gameObject.CompareTag("Press"))
		{
			health -= 2;

			if (health < 0)
				health = 0;

			UpdateHealthUI();

			if (health <= 0)
			{
				ShowGameOver();
			}
			else
			{
				Invoke("ResetHit", hitCooldown);
			}
		}
	}

	void ResetHit()
	{
		canTakeHit = true;
	}

	void UpdateHealthUI()
	{
		if (healthText != null)
			healthText.text = "Lives : " + health;
	}

	public void ShowGameOver()
	{
		if (resultText != null)
			resultText.text = "GAME OVER";

		if (gameManager.Instance != null)
			gameManager.Instance.ShowLoseFinalScore();

		if (gameOverPanel != null)
			gameOverPanel.SetActive(true);

		Time.timeScale = 0f;
	}
}