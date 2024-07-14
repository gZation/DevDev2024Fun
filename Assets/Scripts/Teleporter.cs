using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private string NextScene;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(NextScene);      
    }
}
