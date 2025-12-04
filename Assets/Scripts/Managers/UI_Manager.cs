using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI scoreOutline;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
        scoreOutline.text = scoreUI.text;
    }
}
