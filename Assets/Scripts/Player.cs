using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    // Modifiers
    public float speed;
    public Animator animator;
    public float currHealth;
    public float maxHealth = 100;
    // Refs
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;
    private Vector2 mousePosition;
    #region Unity Messages
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        //animator.Play("slash");
    }
    #endregion
    public void ApplyModifier<M>() where M : PlayerModifier 
    {
        GameObject go = new GameObject(typeof(M).ToString());
        go.AddComponent<M>().OnApply();
        go.transform.parent = transform;
    }
    
}
