using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool stopwatchOn {get;set;} = true;
    public TimeSpan result {get; set;}
    public float maybeHighScore{get; set;}
    public float[] results {get; private set;} = new float[3];

    private void Awake() {
        if(gm == null){
            gm = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        results[0] = PlayerPrefs.GetFloat("Result1", 0f);
        results[1] = PlayerPrefs.GetFloat("Result2", 0f);
        results[2] = PlayerPrefs.GetFloat("Result3", 0f);
    }

    public void SetBestScore(){
        if(maybeHighScore > results[0] && results[0] == 0){
            results[0] = maybeHighScore;
        }else if(maybeHighScore > results[1] && results[0] != 0){
            results[1] = maybeHighScore;
        }else if(maybeHighScore > results[2] && results[0] != 0 && results[1] != 0){
            results[2] = maybeHighScore;
        }
        Array.Sort(results);
        Array.Reverse(results);
        PlayerPrefs.SetFloat("Result1", results[0]);
        PlayerPrefs.SetFloat("Result2", results[1]);
        PlayerPrefs.SetFloat("Result3", results[2]);
    }
}
