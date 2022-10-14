using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{
    private float _currentTime = 0;
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    private void Update() {
        if(GameManager.gm.stopwatchOn){
            _currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            GameManager.gm.result = time;
            _currentTimeText.text = time.ToString(@"ss\:ff");
            GameManager.gm.maybeHighScore = _currentTime;
        }
        
    }
}
