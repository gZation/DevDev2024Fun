using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0f, -10f * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
