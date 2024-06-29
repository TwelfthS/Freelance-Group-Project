using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HPHandler hp;
    public List<DNAChip> chips = new List<DNAChip>();
    void Start()
    {
        hp = GetComponent<HPHandler>();
    }

    void Update()
    {
        
    }

    public float AttackBonuses(float damage) {
        for (int i = 0; i < chips.Count; i++) {
            damage += chips[i].attackBonus;
        }
        return damage;
    }

    public void Hit(float damage) {
        hp.Hit(damage);
    }

    public void GetLoot(DNAChip drop) {
        chips.Add(drop);
        drop.transform.parent = transform;
    }
}
