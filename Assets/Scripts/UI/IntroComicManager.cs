using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroComicManager : MonoBehaviour {


    [SerializeField] private Button continueButton;
    [SerializeField] private string level1;


    private void Awake() {
        continueButton.onClick.AddListener(() => {
            SceneManager.LoadScene(level1);
        });

        StartCoroutine(ShowContinueButton());
    }

    IEnumerator ShowContinueButton() {
        yield return new WaitForSeconds(3f);
        continueButton.gameObject.SetActive(true);
    }

}
