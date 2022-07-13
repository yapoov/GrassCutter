using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    Text loadingText;

    void Awake()
    {
        loadingText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        float textCol;
        textCol = Mathf.PingPong(Time.time * 1, 1f);
        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, textCol);
    }
}
