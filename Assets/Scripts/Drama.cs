using UnityEngine;

public class Drama : MonoBehaviour , Triggerable
{
    public Transform target;
    public float zoomTime = 1.0f;
    public float panTime = 1.0f;

    private Vector3 startPosition;
    private float startTime;
    [HideInInspector]
    public bool isZooming = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (isZooming)
        {
            // calculate the current time and progress of the zoom
            float currentTime = Time.time - startTime;
            float progress = Mathf.Clamp01(currentTime / zoomTime);

            // calculate the current position of the camera during the zoom
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, progress);

            // calculate the current field of view of the camera during the zoom
            float targetFOV = Mathf.Clamp(Mathf.Lerp(60.0f, 20.0f, progress), 20.0f, 60.0f);
            GetComponent<Camera>().fieldOfView = targetFOV;

            // pan the camera towards the target position
            if (currentTime < panTime)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, currentTime / panTime);
            }
            else
            {
                transform.position = targetPosition;
            }

            // check if zoom is complete
            if (progress >= 1.0f)
            {
                isZooming = false;
            }
        }
    }

  public void Trigger(){
    //Debug.Log("DRAMA!!");
    startPosition = transform.position;
    startTime = Time.time;
    startPosition = transform.position;
    isZooming = true;
  }
  public void TriggerExit(){
  }
}
