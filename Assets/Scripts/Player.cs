using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HPHandler hp;
    public List<DNAChip> chips = new List<DNAChip>();
    public float defaultAccuracy = 0.4f;
    public float defaultCritRate = 0.15f;
    void Start()
    {
        hp = GetComponent<HPHandler>();
    }

    void Update()
    {
        
    }

    public float AttackBonuses(float damage) {
        float accuracy = defaultAccuracy;
        float critRate = defaultCritRate;
        for (int i = 0; i < chips.Count; i++) {
            damage += chips[i].attackBonus;
            accuracy = Mathf.Min(1, chips[i].accuracy + accuracy);
            critRate = Mathf.Min(1, chips[i].critRate + critRate);
        }
        if (critRate >= Random.value) {
            Debug.Log("Critical hit with a chance of " + critRate + "!");
            return damage;
        } else {
            return damage * accuracy;            
        }
    }

    public void Hit(float damage) {
        hp.Hit(damage);
    }

    public void GetLoot(DNAChip drop) {
        chips.Add(drop);
        drop.transform.parent = transform;
    }
}
