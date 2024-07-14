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

    [Header("Prefab Refs")]
    [SerializeField] private GameObject itemCardFab;
    

    #region UI Method Update Calls
    public void UpdatePlayerHealth(float currHealth, float maxHealth)
    {
        if (healthfill == null) return;
        healthfill.fillAmount = currHealth / maxHealth;
        healthText.text = $"{currHealth}/{maxHealth}";
    }
    public void UpdatePlayerMaxHealth(float maxHealth)
    {
        if (healthbar == null) return;
        healthbar.offsetMax = new Vector2(maxHealth * 2 - 1900, healthbar.offsetMax.y);
        healthText.text = $"{healthfill.fillAmount * maxHealth}/{maxHealth}";
    }
    public void AddNewCard(Item item)
    {
        if (itemCardFab == null || cardInventory == null) return;
        GameObject go = Instantiate(itemCardFab);
        if (go == null) return;
        go.transform.SetParent(cardInventory, false);
        go.GetComponent<ItemCard>().UpdateCardDetails(item);
    }
    #endregion
}
