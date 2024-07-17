using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField] private float speed;
    private void FixedUpdate()
    {
        Vector3 desitination = transform.position + Vector3.forward;
        transform.position = Vector3.MoveTowards(transform.position, desitination, speed * Time.deltaTime);
    }
}
