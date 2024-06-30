using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HPHandler hp;
    public List<DNAChip> chips = new List<DNAChip>(); // equipped chips
    public InventoryManager inventory;
    public float defaultAccuracy = 0.4f;
    public float defaultCritRate = 0.15f;
    void Start()
    {
        hp = GetComponent<HPHandler>();
        inventory = GetComponent<InventoryManager>();
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
        inventory.AddChip(drop);
        drop.transform.parent = transform;
    }

    public void EquipChip(DNAChip chipToEquip) {
        if (chips.Contains(chipToEquip)) {
            chips.Remove(chipToEquip);
            Debug.Log("Chip " + chipToEquip + " unequipped!");
        } else {
            chips.Add(chipToEquip);
            Debug.Log("Chip " + chipToEquip + " equipped!");
        }
    }

    public void UnequipChip(DNAChip chipToUnequip) {
        chips.Remove(chipToUnequip);
    }
}
