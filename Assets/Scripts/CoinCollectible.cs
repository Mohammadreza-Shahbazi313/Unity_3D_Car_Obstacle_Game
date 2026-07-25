using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
	public int coinValue = 1;
	public float timeBonus = 0f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (gameManager.Instance != null)
				gameManager.Instance.AddScore(coinValue);

			if (gameManager.Instance != null)
				gameManager.Instance.AddTime(timeBonus);

			Destroy(gameObject);
		}
	}
}
