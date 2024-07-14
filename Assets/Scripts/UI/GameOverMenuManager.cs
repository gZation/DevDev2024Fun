using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuManager : MonoBehaviour {


    [SerializeField] private Button mainMenuButton;
    [SerializeField] private string mainMenuScene;


    private void Awake() {
        mainMenuButton.onClick.AddListener(() => {
            SceneManager.LoadScene(mainMenuScene);
        });
    }

}
