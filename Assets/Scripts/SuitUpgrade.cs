using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitUpgrade : Item
{
    [Header("Upgrade Details")]
    [SerializeField] private float attckDmg = 5f;
    [SerializeField] private float attckSpd = 1.04f;
    [SerializeField] private float healthInc = 40f;
    [SerializeField] private float moveSpd = 0.2f;
    [Header("Sprite Refs")]
    [SerializeField] private Sprite attckDmgSprite;
    [SerializeField] private Sprite attckSpdSprite;
    [SerializeField] private Sprite healthIncSprite;
    [SerializeField] private Sprite moveSpdSprite;
    private void Start()
    {
        isCollectible = false;
    }
    protected override void OnPickUp(Player player)
    {
        int r = Random.Range(0, 4);
        switch ((UpgradeType)r)
        {
            case UpgradeType.AttckDmg:
                UIManager.Instance.AddUpgrade(attckDmgSprite);
                player.wrench.damage += attckDmg; 
                break;
            case UpgradeType.AttckSpd:
                UIManager.Instance.AddUpgrade(attckSpdSprite);
                player.AttackCooldown /= attckSpd;
                break;
            case UpgradeType.HealthInc:
                UIManager.Instance.AddUpgrade(healthIncSprite);
                player.MaxHealth += healthInc;
                break;
            case UpgradeType.moveSpd:
                UIManager.Instance.AddUpgrade(moveSpdSprite);
                player.speed += moveSpd;
                break;
        }
    }

    enum UpgradeType
    {
        AttckDmg = 0,
        AttckSpd,
        HealthInc,
        moveSpd
    }
}
