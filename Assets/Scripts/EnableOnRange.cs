using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnRange : MonoBehaviour
{
  public float max;
  public float min;
  public GameObject toToggle;
  private Life lifeScript;
  private float life;
  // Start is called before the first frame update
  void Start(){
    lifeScript = transform.parent.GetComponent<Life>();
  }

  // Update is called once per frame
  void Update(){
    life = lifeScript.life;
    toToggle.SetActive((life <= max) && (life >= min));
  }
}
