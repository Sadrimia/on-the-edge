using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    private void Awake() {
        _menuButton.onClick.AddListener(MenuBack);
    }

    private void MenuBack(){
        SceneManager.LoadScene(0);
    }
}
