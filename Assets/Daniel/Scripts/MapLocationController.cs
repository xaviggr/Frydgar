using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Location
{
    public string id;
    public bool discovered;
    public Transform destinyPos;
    public GameObject hudObj;
}

public class MapLocationController : MonoBehaviour
{
    public GameObject player;

    public List<Location> mapLocations;
    public Dictionary<string, Location> mapLocation = new Dictionary<string, Location>();

    private static MapLocationController _instance;
    public static MapLocationController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MapLocationController>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        InitLocations();
    }

    private void InitLocations()
    {
        for (int i = 0; i < mapLocations.Count; i++)
        {
            mapLocation.Add(mapLocations[i].id, mapLocations[i]);
            if (!mapLocations[i].discovered) mapLocations[i].hudObj.SetActive(false);
        }
    }

    public void DiscoverLocation(string id, bool discovered)
    {
        if(!mapLocation[id].discovered)
        {
            mapLocation[id].discovered = discovered;
            mapLocation[id].hudObj.SetActive(discovered);

            String message;

            if (discovered)
            {
                message = "Has descubierto '" + id + "'";
            }
            else
            {
                message = "El localizador '" + id + "' ya no esta disponible en el mapa";
            }

            NotificationController.Instance.AddNotification(message,4);
        }
    }

    public void GoToLocationID(string id)
    {
        StartCoroutine(DisableThirdPersonController(2));
        player.transform.position = mapLocation[id].destinyPos.position;
        NotificationController.Instance.AddNotification("Has sido trasladado a '" + id + "'", 8);
    }

    public void GoToPos(Vector3 pos, float TimeDelay)
    {
        StartCoroutine(DisableThirdPersonController(TimeDelay));
        player.transform.position = pos;
    }

    private IEnumerator DisableThirdPersonController(float Delay)
    {
        StarterAssets.ThirdPersonController.Instance.enabled = false;
        yield return new WaitForSeconds(Delay);
        StarterAssets.ThirdPersonController.Instance.enabled = true;
    }
}
