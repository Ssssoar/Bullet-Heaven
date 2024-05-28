using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FranDrain : MonoBehaviour{
  private GameObject francisco;
  public float tickDownTime = 0.5f;
  public float initialDelay = 2.5f;
  private Life lifeScript;
  private float nextTick;
   private Animator animator;
    // Start is called before the first frame update
    void Start(){
    francisco = GameObject.Find("Francisco");
    lifeScript = francisco.GetComponent<Life>();
    nextTick = Time.time + tickDownTime + initialDelay;
        animator = francisco.GetComponent<Animator>();
    }
  
  void OnEnable()
    {
        francisco = GameObject.Find("Francisco");
        animator = francisco.GetComponent<Animator>();
        lifeScript = francisco.GetComponent<Life>();
    lifeScript.damageTag = "Empty";
        animator.SetBool("Shield", true);
    }
  
  void OnDisable(){
    francisco = GameObject.Find("Francisco");
        animator = francisco.GetComponent<Animator>();
        lifeScript = francisco.GetComponent<Life>();
    lifeScript.damageTag = "Bullet";
        animator.SetBool("Shield", false);
    }

  // Update is called once per frame
  void Update(){
    if (lifeScript.damageTag != "Empty"){
      lifeScript.damageTag = "Empty";
    }
    if (Time.time >= nextTick){
      nextTick += tickDownTime;
      lifeScript.drainLifeNoHurt();
    }
  }
}
