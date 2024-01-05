using UnityEngine;

public class UpdatePauseMenu : MonoBehaviour
{
    private bool activated = false;
    public GameObject Menu;

    private void Switch()
    {
        activated = !activated;
        Menu.SetActive(activated);
        Cursor.visible = activated;
        StarterAssets.ThirdPersonController.Instance.LockCameraPosition = activated;
        StarterAssets.StarterAssetsInputs.Instance.cursorInputForLook = !activated;
        StarterAssets.StarterAssetsInputs.Instance.cursorLocked = !activated;
    }

    private void OnEnable()
    {
        StarterAssets.UpdatePlayerCanvas.ActivatePause += Switch;
    }

    private void OnDisable()
    {
        StarterAssets.UpdatePlayerCanvas.ActivatePause -= Switch;
    }
}
