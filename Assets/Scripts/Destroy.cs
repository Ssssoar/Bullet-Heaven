using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Destroy : MonoBehaviour, Triggerable
{
    private GameObject parent;
    public void Trigger()
    {
        DestroyImmediate(parent);
    }
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        
        //REMEMBER TO DELETE OR COMMENT THIS LINE BEFORE FINAL RELEASE
        //Debug.Log(parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
  public void TriggerExit(){
  }
}
