using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour {


    [SerializeField] private Button startButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject introCutscene;


    private void Awake() {
        startButton.onClick.AddListener(() => {
            gameObject.SetActive(false);
            introCutscene.SetActive(true);
        });

        creditsButton.onClick.AddListener(() => {
            creditsMenu.SetActive(true);
            gameObject.SetActive(false);
        });

        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

}
