using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstRoom : MonoBehaviour
{
    private void Start()
    {
        
        StartCoroutine(CheckForFinalRoom());
    }
    private IEnumerator CheckForFinalRoom()
    {
        yield return new WaitForSeconds(0.001f);
        if (GameObject.FindGameObjectsWithTag("FinalRoom").Length == 0)
        {
            // Reload the Scene if the final room is missing
            Debug.Log("was loaded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
