using UnityEngine;

public class Disable : MonoBehaviour
{
    private void Awake()
    {

    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
}
