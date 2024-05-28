using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class HealBullet : MonoBehaviour, Triggerable
{
    private GameObject parent;
    private GameObject toRecover;
    private MoveForward moveScript;
    public void Trigger()
    { 
        Vector2 direction = new Vector3(0, 0, 0) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        moveScript.speed = 5;
        parent.tag = "Healing";
    }
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        moveScript = parent.GetComponent<MoveForward>();
        toRecover = GameObject.Find("Francisco");

    }

    // Update is called once per frame
    void Update()
    {

    }
  public void TriggerExit(){
  }
}
