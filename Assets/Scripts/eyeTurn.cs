using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeTurn : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D rb; // Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        // get the Rigidbody2D component
        target = GameObject.Find("angel").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
