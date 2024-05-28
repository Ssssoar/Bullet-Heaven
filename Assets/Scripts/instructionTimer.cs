using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionTimer : MonoBehaviour
{
    public float time;
    private float activateTime;
    // Start is called before the first frame update
    void Start()
    {
        activateTime = Time.time + time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject francisco = GameObject.Find("Francisco");
        Life lifeScript = francisco.GetComponent<Life>();
        GameObject bullet = GameObject.Find("Bullet_Player(Clone)");
        if (bullet != null) {
            activateTime = Time.time + time;
            Transform text = transform.Find("Text");
            text.gameObject.SetActive(false);
        }
        if ((lifeScript.life == 1000)&&(Time.time>= activateTime))
        {
            Transform text = transform.Find("Text");
            text.gameObject.SetActive(true);
        }
    }
}
