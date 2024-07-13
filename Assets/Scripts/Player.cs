using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Player Stats")]
    public float speed;
    public float currHealth;
    public float maxHealth = 100;
    [Header("Player References")]
    
    public Damager wrench;

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
    private void FixedUpdate()
    {
        // TODO: Mouse Facing
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //Quaternion targetRotation = Quaternion.LookRotation(new Vector3(mousePosition.x, 0, mousePosition.y));

        if (movement == Vector3.zero)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime
            );
        rb.MoveRotation(targetRotation);
    }
    #endregion
    #region Actions
    public void OnMove(InputValue value)
    {
        movement = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
    public void OnSlash(InputValue value)
    {
        // TODO: VFX Slash
        animator.Play("slash");
    }
    #endregion
    public void Damage(float amount)
    {
        currHealth -= amount;
        // TODO: UPDATE UI HERE
        if (currHealth <= 0)
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
