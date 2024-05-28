using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public float speed;              // the speed of the object's movement
	public float curvature = 0f;     // the amount of curvature to apply to the object's movement

	void FixedUpdate()
	{
		// Calculate the direction of movement based on the object's rotation
		Vector2 direction = new Vector2(
			Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),
			Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad)
		);

		// Calculate the distance to move this frame
		float distanceToMove = speed * Time.deltaTime;

		// Move the object in the specified direction
		transform.position += (Vector3)direction.normalized * distanceToMove;

		// Apply the curvature value as a modification on the Z axis rotation of the object's transform
		transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + curvature);
	}
}
