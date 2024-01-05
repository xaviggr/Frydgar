using System;
using System.Collections;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public float timeScale;

    public float hour;
    public float minute;

    public float sunAngle;

    public Transform sun;

    public event Action<float, float> UpdateTime;

    void Start()
    {
        UpdateTime(hour, minute);
        StartCoroutine(TimePassing());
    }

    void FixedUpdate()
    {
        if (hour > 24)
        {
            hour = 0;
        }
        if (minute > 60)
        {
            minute = 0;
            hour++;
        }

        sunAngle = (hour + minute / 60) * 360 / 24;

        sun.transform.eulerAngles = new Vector3(sunAngle, sun.transform.rotation.y, sun.transform.rotation.z);

    }

    IEnumerator TimePassing()
    {
        yield return new WaitForSeconds(timeScale);
        minute++;
        UpdateTime(hour, minute);
        StartCoroutine(TimePassing());
    }

}
