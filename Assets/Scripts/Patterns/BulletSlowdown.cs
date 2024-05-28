using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlowdown : MonoBehaviour{
  public float startSpeed;
  public float endSpeed;
  public float slowTime;
  
  private float startTime;
  private float speedDifference;
  private float speed;
  private float endTime;
  private bool done = false;
  // Start is called before the first frame update
  void Start(){
    startTime = Time.time;
    endTime = (Time.time + slowTime);
    speedDifference = startSpeed - endSpeed;
  }
  // Update is called once per frame
  void Update(){
    if (done){
      return;
    }
    //How far along the slowDown we are represented as a portion of 1
    float farAlong = 1-(slowTime-(Time.time - startTime) / slowTime);
    float updateSpeed;
    if (farAlong >= 1){
      done = true;
      updateSpeed = endSpeed;
    }else{
      double toAdd = - Math.Sqrt((double)farAlong) + 1;
      
      updateSpeed = endSpeed + (speedDifference*((float)toAdd));
    }
    MoveForward[] childScripts = transform.GetComponentsInChildren<MoveForward>();
    for (int i = 0 ; i < childScripts.Length ; i++){
      childScripts[i].speed = updateSpeed;
    }
  }
}
