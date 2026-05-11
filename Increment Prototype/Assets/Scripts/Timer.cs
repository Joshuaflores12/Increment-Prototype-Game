using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float time = 300f; // 5 minutes in seconds
    public TextMeshProUGUI timerText;

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "00:00";
        }
    }
}
