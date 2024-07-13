using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;
    private Quaternion directionFacing;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value)
    {
        movement = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
    //public void OnLook(InputValue value)
    //{
    //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    //    Quaternion.LookRotation(new Vector3(mousePosition.x, transform.position.y, mousePosition.y));
    //}
    private void FixedUpdate()
    {
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
}
