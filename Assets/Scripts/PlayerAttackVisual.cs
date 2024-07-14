using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerAttackVisual : MonoBehaviour {


    [SerializeField] private TrailRenderer trailRenderer;


    private VisualEffect visualEffect;


    private void Awake() {
        trailRenderer.enabled = false;
    }

    private void Start() {
        Player.OnPlayerSlash += Player_OnPlayerSlash;
    }

    private void Player_OnPlayerSlash(object sender, System.EventArgs e) {
        trailRenderer.enabled = true;
        StartCoroutine(SlashCountdown());
    }

    IEnumerator SlashCountdown() {
        yield return new WaitForSeconds(.15f);
        trailRenderer.enabled = false;
    }
}
