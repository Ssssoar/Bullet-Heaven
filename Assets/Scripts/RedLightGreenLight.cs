using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    public float safeTime = 10f;
    public float healTime = 10f;
    private float changeTime;
    private float startTime;
    private bool healing = false;
    private GameObject francisco;
    private Animator animator;
    private Life lifeScript;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        changeTime = startTime + safeTime;
        francisco = GameObject.Find("Francisco");
        animator = francisco.GetComponent<Animator>();
        lifeScript = francisco.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= changeTime)
        {
            healing = !healing;
            startTime = Time.time;
            if (healing)
            {
                changeTime = startTime + healTime;
                lifeScript.damageTag = "Empty";
                lifeScript.minorHealTag = "Bullet";
                animator.SetBool("Healing", true);
            }
            else
            {
                changeTime = startTime + safeTime;
                lifeScript.damageTag = "Bullet";
                lifeScript.minorHealTag = "Empty";
                animator.SetBool("Healing", false);
            }
        }
    }
    void OnDisable(){
      changeTime = startTime + safeTime;
      lifeScript.damageTag = "Bullet";
      lifeScript.minorHealTag = "Empty";
        francisco = GameObject.Find("Francisco");
        animator = francisco.GetComponent<Animator>();
        animator.SetBool("Heal", false);
    }
    private void OnEnable()
    {
        francisco = GameObject.Find("Francisco");
        animator = francisco.GetComponent<Animator>();
        animator.SetBool("Heal", true);
    }
}
