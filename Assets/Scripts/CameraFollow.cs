using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    private Camera _camera;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _target.position + _offset, Time.deltaTime * _speed);
    }
}
