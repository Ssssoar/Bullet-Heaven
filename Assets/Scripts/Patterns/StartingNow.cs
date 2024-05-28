using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingNow : MonoBehaviour, Triggerable
{
  private Drama dramaScript;
  // Start is called before the first frame update
  void Start(){
    dramaScript = GameObject.Find("Main Camera").GetComponent<Drama>();
  }

  // Update is called once per frame
  void Update(){
  }
  
  public void Trigger(){
    Debug.Log("Drama?");
    dramaScript.Trigger();
  }
  
  public void TriggerExit(){
  }
}
