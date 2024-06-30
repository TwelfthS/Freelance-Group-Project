using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    float dirX = 0;
    float dirZ = 0;
    float moveSpeed = 7;
    public HPHandler hp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = GetComponent<HPHandler>();
    }

    void Update()
    {
        if (hp.isAlive) {
            dirX = Input.GetAxisRaw("Horizontal");
            dirZ = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector3(dirX * moveSpeed, 0, dirZ * moveSpeed);        
        } else if (rb.velocity != Vector3.zero) {
            rb.velocity = Vector3.zero;
        }

    }
}
