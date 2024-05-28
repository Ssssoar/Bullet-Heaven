using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownSequence : MonoBehaviour, Triggerable
{
    public Transform spawnPoint;
  public int toRecover;
  private int counter = 0;
  public GameObject enemy;
  public float freezeTime = 1f;
  private GameObject player;
  private Life playerLifeScript;
  private Life enemyLifeScript;
  private float unfreeze = 0;
  private PlayerMovement moveScript;
  
  public void Trigger(){
    counter = 100;
    playerLifeScript.ResetLife();
    GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
    for (int i=0;i<bullets.Length;i++){
      Destroy(bullets[i]);
    }
    unfreeze = Time.time + freezeTime;
    moveScript.speed = 0;
  }
  // Start is called before the first frame update
  void Start(){
    enemyLifeScript = enemy.GetComponent<Life>();
    player = transform.parent.gameObject;
    playerLifeScript = player.GetComponent<Life>();
    moveScript = player.GetComponent<PlayerMovement>();
  }
  // Update is called once per frame
  void Update(){
    if ((unfreeze != 0)&&(Time.time >= unfreeze)){
      unfreeze = 0;
      moveScript.speed = 5;
            player.transform.position = spawnPoint.position;
    }
    //Debug.Log("Counter" + counter);
    if (counter != 0){
      counter = counter - 1;
      enemyLifeScript.AddLife(1);
    }
  }
  
  public void TriggerExit(){
  }
  
}
