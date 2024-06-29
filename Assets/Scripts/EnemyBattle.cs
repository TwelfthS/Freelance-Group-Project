using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public DetectionZone detectionZone;
    public GameObject player;
    public bool seesPlayer = false;
    public Rigidbody2D rb;
    public float moveSpeed = 5;
    public int damage = 4;
    public float attackCooldown = 0;
    private float maxCooldown = 1;
    private bool inCombat = false;
    void Start()
    {
        detectionZone = GetComponent<DetectionZone>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (inCombat) {
            Action();
        }
    }

    public void StartCombat() {
        inCombat = true;
    }

    public void StopCombat() {
        inCombat = false;
    }

    public void Action() {
        if (seesPlayer) {
            Cooldown();
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance < 3 && attackCooldown <= 0) {
                AttackPlayer(damage);
                attackCooldown = maxCooldown;
            }
            moveToPlayer(distance);
        } else {
            checkForPlayer();
        }
    }

    private void Cooldown() {
        if (attackCooldown > 0) {
            attackCooldown -= Time.deltaTime;
        }
    }

    private void moveToPlayer(float currentDistance) {
        if (currentDistance > 3) {
            Vector2 dir = player.transform.position - transform.position;
            dir.Normalize();
            rb.velocity = new Vector2(dir.x * moveSpeed, dir.y * moveSpeed);            
        } else {
            rb.velocity = Vector2.zero;
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
