using UnityEngine;

public class BulletClean : MonoBehaviour
{
  private void  Update()
  {
    //Empty update, because Unity is silly like that.
  }
  private void OnTriggerStay2D(Collider2D collision)
  {
    //Debug.Log("triggered");
    if (collision.gameObject.CompareTag("Boundary")|| collision.gameObject.CompareTag("Shootable"))
    {
      //Debug.Log("Collision detected with boundary object");
      Destroy(gameObject);
    }
  }
}
