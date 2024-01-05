using UnityEngine;

public class EnableObjOnAwake : MonoBehaviour
{
    public GameObject[] objects;

    void Awake()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }

}
