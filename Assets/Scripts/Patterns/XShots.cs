using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XShots : MonoBehaviour , Triggerable
{
  private GameObject singleCone;
  private GameObject tempObj;
  private Vector2 direction = Vector2.zero;
  public bool ignorePlayer = false;
  public int ammount = 3;
  public float angleOffset = 0f;
  public GameObject shot;
  private GameObject[] tempObjs;
  [HideInInspector]
  public bool sticky = false;
  // Start is called before the first frame update
  void Start()
  {
  tempObjs = new GameObject[ammount];
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.childCount <= 0){
      //Destroy(gameObject);
      for (int i=0 ; i<ammount ; i++){
        Destroy(tempObjs[i]);
      }
    }
  }
  
  void OnDestroy(){
    Clear();
  }
  
  void Clear(){
    for (int i=0 ; i<ammount ; i++){
      Destroy(tempObjs[i]);
    }
  }
  
  public void Trigger(){
    singleCone = shot;
    
    //get angle towards player
    if (!sticky){
      if(!ignorePlayer){
        direction = GameObject.Find("angel").transform.position - transform.position;
      }else{
        direction = GameObject.Find("North").transform.position - transform.position;
      }
    }
    float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + angleOffset;
    float step = 360/ammount;
    //towardPlayer.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    Clear();
    for (int i=0 ; i<ammount ; i++){
      tempObj = new GameObject("Cone Target");
      tempObjs[i] = tempObj;
      GameObject cone = Instantiate(singleCone,transform);
      
      
      MonoBehaviour coneScript = cone.GetComponent<MonoBehaviour>();
      Shot tryShoot = coneScript as Shot;
      
      
      tempObj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      tempObj.transform.Translate(Vector2.right*3f);
      //Debug.Log(angle);
      angle += step;
      
      tryShoot.target = tempObj.transform;
    }
  }
  
  public void TriggerExit(){
  }
}
