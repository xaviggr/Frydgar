using UnityEngine;

public class AttackController : MonoBehaviour
{
    private void Slash()
    {
        StarterAssets.AnimController.Instance.AnimPlayAttack();
    }

    private void OnEnable()
    {
        StarterAssets.StarterAssetsInputs.Instance.Attack += Slash;
    }

    private void OnDisable()
    {
        StarterAssets.StarterAssetsInputs.Instance.Attack -= Slash;
    }
}
