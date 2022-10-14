using UnityEngine;
using UnityEngine.UI;

public class TapToStart : MonoBehaviour
{
    [SerializeField] private GameObject _startingPanel;
    [SerializeField] private Button _startsButton;

    private void Awake() {
        _startsButton.onClick.AddListener(GameStarts);
        Time.timeScale = 0;
    }

    private void GameStarts(){
        GameManager.gm.stopwatchOn = true;
        _startingPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
