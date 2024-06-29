using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public EnemyBattle enemyBattle;
    public HPHandler hp;
    public DetectionZone detectionZone;
    public GameObject player;
    public bool seesPlayer = false;
    public Rigidbody rb;
    public float moveSpeed = 5;
    public int damage = 4;
    public float attackCooldown = 0;
    private float maxCooldown = 1;
    void Start()
    {
        // enemyBattle = GetComponent<EnemyBattle>();
        hp = GetComponent<HPHandler>();
        detectionZone = GetComponent<DetectionZone>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (hp.isAlive) {
            Action();
        }
    }

    public void Hit(int damage) {
        hp.Hit(damage);
    }

    // public void StartCombat() {
    //     inCombat = true;
    // }

    // public void StopCombat() {
    //     inCombat = false;
    // }

    public void Action() {
        if (seesPlayer) {
            Cooldown();
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < 1 && attackCooldown <= 0) {
                AttackPlayer(damage);
                attackCooldown = maxCooldown;
            }
            moveToPlayer(distance);
        } else {
            // Debug.Log(this.gameObject.name + " looking for player...");
            checkForPlayer();
        }
    }

    private void Cooldown() {
        if (attackCooldown > 0) {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void moveToPlayer(float currentDistance) {
        if (currentDistance > 1) {
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            rb.velocity = new Vector3(dir.x * moveSpeed, 0, dir.z * moveSpeed);            
        } else {
            rb.velocity = Vector3.zero;
        }

    }

    private void checkForPlayer() {
        if (detectionZone.seesPlayer) {
            seesPlayer = true;
            player = detectionZone.player;
            player.GetComponent<PlayerBattle>().SetEnemy(this.gameObject);
        }
    }

    private void AttackPlayer(int damage) {
        player.GetComponent<HPHandler>().Hit(damage);
        Debug.Log("You got hit!");
    }
}
