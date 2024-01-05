using System.Collections;
using UnityEngine;

public class MovePosOverTime : MonoBehaviour
{
    public Transform pos;

    public float timeLapse;

    public bool ignoreX, ignoreY, ignoreZ;

    void Start()
    {
        StartCoroutine(RefreshPos());
    }

    IEnumerator RefreshPos()
    {
        Vector3 newPos = pos.position;

        if (ignoreX) newPos.x = transform.position.x;
        if (ignoreY) newPos.y = transform.position.y;
        if (ignoreZ) newPos.z = transform.position.z;

        transform.position = newPos;
        yield return new WaitForSeconds(timeLapse);
        StartCoroutine(RefreshPos());
    }

}
