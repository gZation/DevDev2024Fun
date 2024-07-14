using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : ProximityAttacker, IDamagable {

    [Header("Enemy Logic")]
    [SerializeField] protected float health = 50;
    [SerializeField] protected Image healthFill;
    [SerializeField] private Item[] itemDrops;
    private float startingHealth;

    protected override void Awake()
    {
        base.Awake();
        startingHealth = health;
    }

    public virtual void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            DropRandomItem();
            Destroy(gameObject);
        }
        healthFill.enabled = true;
        healthFill.fillAmount = health / startingHealth;
    }

    public void DropRandomItem()
    {
        float total = 0f;
        foreach (Item item in itemDrops)
        {
            total += item.Weight;
        }
        total *= 2f;
        float rand = Random.Range(0, total);
        foreach (Item item in itemDrops)
        {
            rand -= item.Weight;
            if (rand <= 0)
            {
                GameObject go = Instantiate(item).gameObject;
                go.transform.position = transform.position + Vector3.up * 3f;
                go.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Impulse);
                return;
            }
        }
    }

}
