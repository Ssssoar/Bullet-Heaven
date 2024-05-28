using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningZone : MonoBehaviour{
  public float warningTime = 3f;
  public float damageTime = 1f;
  private Transform warning;
  private Transform hit;
  private float hitTime;
  private float disableTime;
  // Start is called before the first frame update
  void Start(){
    warning = transform.Find("Warning");
    hit = transform.Find("Hit");
    hitTime = Time.time + warningTime;
    disableTime = hitTime + damageTime;
  }
  // Update is called once per frame
  void Update(){
    if (Time.time >= hitTime){
      warning.gameObject.SetActive(false);
      hit.gameObject.SetActive(true);
    }
    if(Time.time >= disableTime){
      Destroy(gameObject);
    }
  }
}
