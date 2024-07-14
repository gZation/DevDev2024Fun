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
    [SerializeField] private GameObject title;


    private void Awake() {
        startButton.onClick.AddListener(() => {
            Hide();
            introCutscene.SetActive(true);
        });

        creditsButton.onClick.AddListener(() => {
            creditsMenu.SetActive(true);
            Hide();
        });

        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
        title.gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
        title.gameObject.SetActive(false);
    }

}
