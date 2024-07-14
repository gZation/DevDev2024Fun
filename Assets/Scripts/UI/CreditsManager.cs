using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour {


    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject startMenu;


    private void Awake() {
        returnButton.onClick.AddListener(() => {
            startMenu.SetActive(true);
            gameObject.SetActive(false);
        });
    }

}
