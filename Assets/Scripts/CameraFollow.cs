using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform playerTarget;
	private Vector3 offset = new Vector3(0f, 4f, -10f);

	void LateUpdate()
	{
		if (playerTarget == null)
			return;

		transform.position = playerTarget.position + offset;
	}
}
