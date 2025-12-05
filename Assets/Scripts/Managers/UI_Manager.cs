using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
