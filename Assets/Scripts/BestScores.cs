using UnityEngine;
using TMPro;
using System;

public class BestScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _result1;
    [SerializeField] private TextMeshProUGUI _result2;
    [SerializeField] private TextMeshProUGUI _result3;

    private void Awake() {
        SetResult1();
        SetResult2();
        SetResult3();
    }

    private void SetResult1(){
        TimeSpan time = TimeSpan.FromSeconds(GameManager.gm.results[0]);
        _result1.text = "<color=white>1: </color>" + time.ToString(@"ss\:ff");
    }
    private void SetResult2(){
        TimeSpan time = TimeSpan.FromSeconds(GameManager.gm.results[1]);
        _result2.text = "<color=white>2: </color>" + time.ToString(@"ss\:ff");
    }
    private void SetResult3(){
        TimeSpan time = TimeSpan.FromSeconds(GameManager.gm.results[2]);
        _result3.text = "<color=white>3: </color>" + time.ToString(@"ss\:ff");
    }

}
