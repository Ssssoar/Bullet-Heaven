using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTrigger : MonoBehaviour
{
    public int triggerPoint;
    public MonoBehaviour toTrigger;
    private Life LifeScript;
    private float life;
    private bool above;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
      LifeScript = GetComponent<Life>();
      life = LifeScript.life;
      if (life >= triggerPoint)
      {
        above = true;
      }
      else
      {
        above = false;
      }
    }

    // Update is called once per frame
    void Update()
    {
      life = LifeScript.life;
      if (!triggered){
        if ((above && (life <= triggerPoint))||(!above && (life >= triggerPoint))){
          Triggerable tryTrigger = toTrigger as Triggerable;
          if (tryTrigger != null){
            tryTrigger.Trigger();
            triggered = true;
          }
        }
      }else{
        if (life!=triggerPoint){
          triggered = false;
        }
      }
    }
}