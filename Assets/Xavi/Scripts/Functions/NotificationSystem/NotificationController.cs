using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NotificationController : MonoBehaviour
{
    private static NotificationController _instance;
    public static NotificationController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<NotificationController>();
            }
            return _instance;
        }
    }

    public GameObject prefab_notif;

    public void AddNotification(String text, float DelayToDestroy)
    {
        GameObject notif = Instantiate(prefab_notif,transform);
        notif.GetComponentInChildren<DisplayData>().UpdateValue(text);

        StartCoroutine(DestroyNotification(notif, DelayToDestroy));
    }

    private IEnumerator DestroyNotification(GameObject notification ,float Delay)
    {
        yield return new WaitForSeconds(Delay);
        Destroy(notification);
    }
}
