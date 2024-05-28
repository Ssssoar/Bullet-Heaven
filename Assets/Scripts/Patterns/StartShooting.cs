using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShooting : MonoBehaviour
{
  private Transform francisco;
  public GameObject shooter;
  private GameObject toClean;
  // Start is called before the first frame update
  void Start(){
    francisco = transform.parent;
  }

  // Update is called once per frame
  void Update(){
    
  }
  void OnEnable(){
    toClean = Instantiate(shooter);
    Transform camera = GameObject.Find("Main Camera").transform;
    Drama dramaScript = camera.GetComponent<Drama>();
    dramaScript.Trigger();
  }
  void OnDisable(){
    if(toClean != null){
      Destroy(toClean);
    }
  }
}
