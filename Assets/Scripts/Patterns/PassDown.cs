using UnityEngine;

public class PassDown : MonoBehaviour , Shot{
  [HideInInspector]
  public Transform target { get; set; }
    
  private void Start(){
  }
    
  private void Update(){
  }
  
  private void Shoot(){
    for (int i=0;i<transform.childCount;i++){
      SingleCone shotScript = transform.GetChild(i).GetComponent<SingleCone>();
      
      shotScript.Shoot();
    }
  }
}
