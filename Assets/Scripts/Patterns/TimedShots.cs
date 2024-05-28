using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedShots : MonoBehaviour , Triggerable
{
  public float timeBetweenShots = 1f;
  public int shotsPerVolley = 1;
  public float timeBetweenVolleys = 1f;
  public float initialDelay = 2f;
  public bool sticky = false;
  private float nextFireTime;
  private int shotsLeft;
  // Start is called before the first frame update
  void Start(){
    shotsLeft = shotsPerVolley;
    nextFireTime = Time.time + initialDelay;
  }

  // Update is called once per frame
  void Update(){
    if (shotsLeft > 0){
      if (Time.time >= nextFireTime){
        nextFireTime += timeBetweenShots;
        Trigger();
        shotsLeft -= 1;
      }
    }else{
      nextFireTime = Time.time + timeBetweenVolleys;
      shotsLeft = shotsPerVolley;
    }
  }
  
  public void Trigger(){
    XShots shotsScript = GetComponent<XShots>();
    if (sticky&&(shotsLeft != shotsPerVolley)){
      shotsScript.sticky = true;
    }else{
      shotsScript.sticky = false;
    }
    shotsScript.Trigger();
  }
  
  public void TriggerExit(){
  }
}
