using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBattle enemyBattle;
    public HPHandler hp;
    void Start()
    {
        enemyBattle = GetComponent<EnemyBattle>();
        hp = GetComponent<HPHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.isAlive) {
            enemyBattle.Action();
        }
    }

    public void Hit(int damage) {
        Debug.Log("Hit?");
        hp.Hit(damage);
    }
}
