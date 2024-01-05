using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    public void Move(Transform objPos, Transform destinyPos)
    {
        objPos.position = destinyPos.position;
    }
}
