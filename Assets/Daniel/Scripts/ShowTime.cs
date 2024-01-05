using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{
    public TimeSystem ts;

    public Text text;

    void OnEnable()
    {
        ts.UpdateTime += UpdateTime;

    }
    void OnDisable()
    {
        ts.UpdateTime -= UpdateTime;
    }

    public void UpdateTime(float hour, float minute)
    {
        text.text = hour + ":" + minute;
    }

}
