using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour, IDamagable
{

    public static event EventHandler<EventArgs> OnPlayerSlash;


    [Header("Player Stats")]
    public float speed;
    [SerializeField] private float currHealth;
    [SerializeField] private float maxHealth;
    public float CurrHealth
    {
        get => currHealth;
        set
        {
            currHealth = value;
            UIManager.Instance.UpdatePlayerHealth(currHealth, maxHealth);   
        }
    }
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            if (maxHealth < currHealth)
            {
                CurrHealth = value;
            }
            if (maxHealth <= 0)
            {
                maxHealth = 1;
            }
            UIManager.Instance.UpdatePlayerMaxHealth(maxHealth);
        }
    }

    [Header("Player References")]
    public Damager wrench;
    public List<Item> collectedItems;

    [Header("Modifier Bools")]
    public bool infiMove;

    // private Refs
    private Rigidbody rb;
    private Animator animator;
    private Vector3 movement = Vector3.zero;
    private Vector2 mousePosition;
    
    #region Unity Messages
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        UIManager.Instance.UpdatePlayerHealth(currHealth, maxHealth);
        UIManager.Instance.UpdatePlayerMaxHealth(maxHealth);
    }
    private void FixedUpdate()
    {
        // TODO: Mouse Facing
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Quaternion targetRotation = Quaternion.LookRotation(new Vector3(mousePosition.x, 0, mousePosition.y));

        if (movement == Vector3.zero)
        {
            animator.SetBool("moving", false);
            return;
        }
        animator.SetBool("moving", true);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime * speed
            );
        rb.MoveRotation(targetRotation);
    }
    #endregion
    #region Actions
    public void OnMove(InputValue value)
    {
        if (infiMove && (value.Get<Vector2>() == Vector2.zero || value.Get<Vector2>().magnitude < 1f)) 
        {
            return;
        }
        movement = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
    public void OnSlash(InputValue value)
    {
        // TODO: VFX Slash
        animator.Play("slash");
        OnPlayerSlash?.Invoke(this, EventArgs.Empty);
    }
    #endregion
    public void Damage(float amount)
    {
        CurrHealth -= amount;
        if (CurrHealth <= 0)
        {
            OnPlayerDeath();
            Debug.Log("Player Is Dead");
        }
    }
    public void OnPlayerDeath()
    {

    }
    public void ApplyModifier<M, D>(D data) 
        where M : PlayerModifier<D> 
        where D : ModifierData
    {
        GameObject go = new GameObject(typeof(M).ToString());
        go.transform.parent = transform;
        go.AddComponent<M>().OnApply(data);
        
    }
}
