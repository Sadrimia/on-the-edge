using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ball"){
            GameManager.gm.stopwatchOn = false;
            if(!Vibrator.vibrationIsOff){
                Vibrator.Vibrate(150);
            }
            _losePanel.SetActive(true);
            GameManager.gm.SetBestScore();
        }
    }
}
