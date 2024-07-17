using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    #endregion
    [Header("Canvas UI Refs")]
    [SerializeField] private Image healthfill;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private RectTransform healthbar;
    [SerializeField] private Transform cardInventory;
    [SerializeField] private Transform suitUpgrades;
    [SerializeField] private GameObject bossHealth;
    [SerializeField] private Image bossHealthFill;
    [SerializeField] private TextMeshProUGUI bossHealthText;

    [Header("UI Fabs")]
    [SerializeField] private GameObject itemCardFab;
    [SerializeField] private GameObject iconFab;
    
    #region UI Method Update Calls
    public void UpdatePlayerHealth(float currHealth, float maxHealth)
    {
        if (healthfill == null) return;
        healthfill.fillAmount = currHealth / maxHealth;
        healthText.text = $"{(int)currHealth}/{maxHealth}";
    }
    public void UpdatePlayerMaxHealth(float maxHealth)
    {
        if (healthbar == null) return;
        healthbar.offsetMax = new Vector2(maxHealth - 1820, healthbar.offsetMax.y);
        healthText.text = $"{healthfill.fillAmount * (int)maxHealth}/{maxHealth}";
    }
    public void AddNewCard(Item item)
    {
        if (itemCardFab == null || cardInventory == null) return;
        GameObject go = Instantiate(itemCardFab);
        if (go == null) return;
        go.transform.SetParent(cardInventory, false);
        go.GetComponent<ItemCard>().UpdateCardDetails(item);
    }
    public void AddUpgrade(Sprite sprite)
    {
        if (iconFab == null || suitUpgrades == null) return;
        GameObject go = Instantiate(iconFab);
        if (go == null) return;
        go.transform.SetParent(suitUpgrades, false);
        go.GetComponent<Image>().sprite = sprite;
    }
    public void UpdateBossHealth(float currHealth, float maxHealth)
    {
        bossHealthFill.fillAmount = currHealth / maxHealth;
    }
    public void ShowBossHealth()
    {
        bossHealth.SetActive(true);
    }
    public void HideBossHealth()
    {
        bossHealth.SetActive(false);
    }
    #endregion
}
