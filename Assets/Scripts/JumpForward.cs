using UnityEngine;

public class JumpForward : MonoBehaviour
{
	public float distanceToMove = 4f;
  private bool moved = false;

	void Start(){
		// Calculate the direction of movement based on the object's rotation
    if (!moved){
      Vector2 direction = new Vector2(
        Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),
        Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad)
      );
      // Move the object in the specified direction
      transform.position += (Vector3)direction.normalized * distanceToMove;
    }
	}
}
