using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    private void Awake() {
        _startButton.onClick.AddListener(StartGameScene);
    }

    private void StartGameScene(){
        SceneManager.LoadScene(1);
    }
}
