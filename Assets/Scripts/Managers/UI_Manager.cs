using global::UnityEngine;
using global::TMPro;

public class UI_Manager : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private TMPro.TextMeshProUGUI scoreUI;
    global::GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
