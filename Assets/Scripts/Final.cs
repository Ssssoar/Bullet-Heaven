using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour{
  public float time = 2;
  private GameObject cameraGameObj;
  private float activateTime;
  private Transform text;
    private float timer = 1f;
    public GameObject explode;
    private float explodeTime;
  // Start is called before the first frame update
  void Start(){
    cameraGameObj = GameObject.Find("Main Camera");
    text = cameraGameObj.transform.Find("Text");
    }

  // Update is called once per frame
  void Update(){
    if (Time.time >= activateTime){
      text.gameObject.SetActive(true);
    }
    if (Time.time >= explodeTime)
        {
            explodeTime = Time.time + timer;
            Transform text = cameraGameObj.transform.Find("Text");
            explode.SetActive(false);
            explode.SetActive(true);
        }
  }
  
  void OnEnable(){
    cameraGameObj = GameObject.Find("Main Camera");
    Drama dramaScript = cameraGameObj.GetComponent<Drama>();
    dramaScript.Trigger();
    CameraFollow cameraScript = cameraGameObj.GetComponent<CameraFollow>();
    cameraScript.target = GameObject.Find("Francisco").transform;
    Transform text = cameraGameObj.transform.Find("Text");
    text.gameObject.SetActive(true);
    activateTime = Time.time + time;
        explode.SetActive(true);
        explodeTime = Time.time + timer;
  }
}
