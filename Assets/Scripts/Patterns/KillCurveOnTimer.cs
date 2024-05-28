using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class KillCurveOnTimer : MonoBehaviour{
  public float time = 1f;
  private float killTime;
  private bool done = false;
  // Start is called before the first frame update
  void Start(){
    killTime = Time.time + time;
  }
  // Update is called once per frame
  void Update(){
    if (!done){
      if (Time.time >= killTime){
        for (int i=0;i<transform.childCount;i++){
          MoveForward moveScript = transform.GetChild(i).GetComponent<MoveForward>();
          moveScript.curvature = 0;
        }
      }
    }
  }
}
