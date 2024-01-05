using UnityEngine;

public class UpdatePlayerInv : MonoBehaviour
{
    private bool activated = false;
    public GameObject dialog_inv;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Switch()
    {
        activated = !activated;
        dialog_inv.SetActive(activated);
        Cursor.visible = activated;
        StarterAssets.ThirdPersonController.Instance.LockCameraPosition = activated;
        StarterAssets.StarterAssetsInputs.Instance.cursorInputForLook = !activated;
        StarterAssets.StarterAssetsInputs.Instance.cursorLocked = !activated;
    }

    private void OnEnable()
    {
        StarterAssets.UpdatePlayerCanvas.ActivateInventory += Switch;
    }

    private void OnDisable()
    {
        StarterAssets.UpdatePlayerCanvas.ActivateInventory -= Switch;
    }
}
