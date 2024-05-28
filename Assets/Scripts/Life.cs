using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour{
  public float life = 1f;
  public float maxLife = 1f;
  public string damageTag = "Bullet";
  public string minorHealTag = "Empty";
  private TextMeshPro textMeshProComponent;
  public GameObject textObject;
  private GameObject downHandler;
  private DownSequence downScript;
  public string healTag = "Healing";
  public int healAmmount = 15;
  private SpriteRenderer sprite;
  private int hurtFrames = 15;
  private int hurting = 0;
  private Color hurtColor = new Color(1f,0.5f,0.5f);
  private Color healColor = new Color(0.5f,1f,0.5f);
    private GameObject francisco;
    private Animator animator;
  
  // Start is called before the first frame update
  void Start(){
    if (transform.Find("Text") != null){
      textObject = transform.Find("Text").gameObject;
      sprite = GetComponent<SpriteRenderer>();
            //downHandler = transform.Find("DownHandler").gameObject;
            //downScript = downHandler.GetComponent<DownSequence>();
            francisco = GameObject.Find("Francisco");
            animator = francisco.GetComponent<Animator>();
        }
  }
  
  
  private void OnTriggerEnter2D(Collider2D collision){
    if (collision.gameObject.CompareTag(damageTag)){
      life -= 1;
      TextUpdate();
      if (sprite != null){
        if (hurting == 0){
          sprite.color = hurtColor;
          hurting = hurtFrames;
        }
      }
    }
    if (collision.gameObject.CompareTag(healTag))
    {
      AddLife(healAmmount);
      TextUpdate();
      Destroy(collision.gameObject);
    }
    if (collision.gameObject.CompareTag(minorHealTag))
    {
      AddLife(1);
      TextUpdate();
    }
  }
  
  private void TextUpdate(){
    if (textObject != null){
      textMeshProComponent = textObject.GetComponent<TextMeshPro>();
      textMeshProComponent.text = life.ToString();
    }
  }
  
  public void ResetLife(){
    life = maxLife;
    TextUpdate();
    }
  
  public void drainLifeNoHurt(){
    life -= 1;
    TextUpdate();
  }
  
  public void AddLife(int ammount){
    //Debug.Log("called");
    if (life + ammount <= maxLife){
      life += ammount;
    }else{
      life = maxLife;
    }
    sprite.color = healColor;
    hurting = ammount * hurtFrames;
    TextUpdate();
  }
    // Update is called once per frame
  void Update(){
    if (sprite != null){
      if (hurting > 0){
        hurting -= 1;
      }else{
        if (sprite.color != Color.white){
          sprite.color = Color.white;
        }
      }
    }
    if (life <= -1251)
        {
            animator = francisco.GetComponent<Animator>();
            animator.SetBool("DEAD", true);
        }
  }
}
