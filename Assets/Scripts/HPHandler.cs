using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
    public float currentHP = 10;
    public bool isAlive = true;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Hit(float damage) {
        currentHP -= damage;

        if (currentHP <= 0) {
            Death();
        }
    }

    public void Death() {
        isAlive = false;
        Debug.Log(this.gameObject.name + " is dead!");
        if (this.gameObject.GetComponent<PlayerMovement>() == null) {
            Destroy(this.gameObject);
        }
    }
}
