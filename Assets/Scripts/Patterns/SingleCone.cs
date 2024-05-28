using UnityEngine;

public class SingleCone : MonoBehaviour , Shot{
  public GameObject[] bullets;
  public float[] scales;
  //public GameObject bulletPrefab;
  public float curvature = 0;
  public bool simmetry = false;
  public float angleSpread;
  public int branches = 5;
  public float bulletSpeed = 5f;
  public float delay = 0f;
  public bool onPlayerDistance = false;
  public float jumpDistance = 4f;
  [HideInInspector]
  public Transform target { get; set; }
  private float shootTime;
  private float step;
  private Quaternion currentAngle;
  private bool shot = false;
  private Transform firePoint;
  private GameObject tempObj;
    
  private void Start(){
    //Vector3 angles = transform.rotation.eulerAngles;
    //angles.z -= angleSpread/2;
    //Quaternion newRot = Quaternion.Euler(angles);
    //transform.rotation = newRot;
    shootTime = Time.time + delay;
  }
    
  private void Update(){
    if (!shot){
      if (Time.time >= shootTime){
        Shoot();
        shot = true;
      }
    }else{
      if (transform.childCount <= 0){
        Destroy(gameObject);
        Destroy(tempObj);
      }
    }
  }
  
  private void OnDestroy(){
    Destroy(tempObj);
  }

    public void Shoot(){
    //allow to keep target if set by creator, otherwise make it player
    if (!target){
      target = GameObject.Find("angel").transform;
    }
    
    //rotate the object to face target.
    if (target == null) return;
    Vector2 direction = target.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    //assign firePoint all the elements of the original transform
    tempObj = new GameObject("Temp Cone Angle");
    firePoint = tempObj.transform;
    firePoint.position = transform.position;
    firePoint.rotation = transform.rotation;
    firePoint.localScale = transform.localScale;
      
    //Define the step between bullet and bullet
    if (branches!= 1){
      //point firePoint to first bullet angle
      firePoint.eulerAngles -= new Vector3(0f,0f,angleSpread/2);
      //define step between each branch
      step = angleSpread / (branches-1);
    }else{
      step = 0;
    }

    int length = bullets.Length;
    int scaleLength = scales.Length;
    for (int i = 0; i < branches; i++){
      GameObject bullet = Instantiate(bullets[i%length], firePoint.position, firePoint.rotation, gameObject.transform);
      bullet.transform.localScale = new Vector3(scales[i%scaleLength] , scales[i%scaleLength] , 1f); 
      bullet.transform.Translate(Vector2.right * 1.5f);
      MoveForward moveScript = bullet.GetComponent<MoveForward>();
      if (moveScript != null){
        moveScript.speed = bulletSpeed;
        if (!simmetry){
          moveScript.curvature = curvature;
        }else{
          if (i+1 < (1+(float)branches)/2){
            moveScript.curvature = curvature;
          }
          if (i+1 == (1+(float)branches)/2){
            moveScript.curvature = 0;
          }
          if (i+1 > (1+(float)branches)/2){
            moveScript.curvature = -curvature;
          }
        }
      }
      JumpForward jumpScript = bullet.GetComponent<JumpForward>();
      if (jumpScript != null){
        if (!onPlayerDistance){
          jumpScript.distanceToMove = jumpDistance - 1.5f;
        }else{
          Transform angelTransform = GameObject.Find("angel").transform;
          jumpScript.distanceToMove = Vector2.Distance(angelTransform.position, transform.position) - 1.5f;
        }
      }
      if (i!= branches-1){
        firePoint.eulerAngles += new Vector3(0f,0f,step);
      }
    }
  }
}
