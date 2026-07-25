using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour
{
	public float speed = 10f;
	public float rotationSpeed = 100f;
	public float wheelRotationSpeed = 600f;

	public Transform frontLeftWheel;
	public Transform frontRightWheel;
	public Transform rearLeftWheel;
	public Transform rearRightWheel;

	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float moveInput = Input.GetAxis("Vertical");
		float turnInput = Input.GetAxis("Horizontal");

		Vector3 move =
			transform.forward *
			moveInput *
			speed *
			Time.fixedDeltaTime;

		rb.MovePosition(rb.position + move);

		Quaternion turn =
			Quaternion.Euler
			(0f,turnInput * rotationSpeed * Time.fixedDeltaTime,0f);
				

		rb.MoveRotation(rb.rotation * turn);

		if (moveInput != 0)
		{
			float rotation = -moveInput * wheelRotationSpeed * Time.fixedDeltaTime;

			frontLeftWheel.Rotate(rotation, 0f, 0f);
			frontRightWheel.Rotate(rotation, 0f, 0f);
			rearLeftWheel.Rotate(rotation, 0f, 0f);
			rearRightWheel.Rotate(rotation, 0f, 0f);
		}
	}
}