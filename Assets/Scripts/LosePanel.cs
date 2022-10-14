using UnityEngine;
using TMPro;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loseResultText;

    private void Awake() {
        _loseResultText.text = GameManager.gm.result.ToString(@"ss\:ff");
    }
}
