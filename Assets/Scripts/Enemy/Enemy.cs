using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HPHandler hp;
    public DetectionZone detectionZone;
    public Player player;
    public bool seesPlayer = false;
    public Rigidbody rb;
    public float moveSpeed = 3;
    public int damage = 4;
    public float attackCooldown = 0;
    private float maxCooldown = 1;
    public DNAChip drop;
    public float moneyDrop;
    void Start()
    {
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

    public void Hit(float damage) {
        hp.Hit(damage);
    }

    public void Action() {
        if (seesPlayer && player.hp.isAlive) {
            Cooldown();
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < 1 && attackCooldown <= 0) {
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
            player = detectionZone.player.GetComponent<Player>();
        }
    }

    private void AttackPlayer(float damage) {
        Debug.Log("You got hit!");
        player.Hit(damage);
    }

    public void LeaveLoot() {
        if (drop != null) {
            player.GetLoot(drop, moneyDrop);
        }
    }
}
