using System;
using UnityEngine;

namespace StarterAssets
{
    public class UpdatePlayerCanvas : MonoBehaviour
    {
        public static event Action<float> PlayerUpdateHealth = delegate { };
        public static event Action ActivateInventory = delegate { };
        public static event Action ActivatePause = delegate { };

        private void UpdateValue(float value)
        {
            PlayerUpdateHealth(value);
        }

        private void ActivateInv()
        {
            SoundController.Instance.PlaySound("Inventory");
            ActivateInventory();
        }

        private void ActivatePau()
        {
            SoundController.Instance.PlaySound("Inventory");
            ActivatePause();
        }

        private void OnEnable()
        {
            GetComponent<StarterAssetsInputs>().Inventory += ActivateInv;
            GetComponent<StarterAssetsInputs>().Pause += ActivatePau;
            GetComponent<StatsSystem>().TriggerHealthHasBeenUpdated += UpdateValue;
        }

        private void OnDisable()
        {
            GetComponent<StatsSystem>().TriggerHealthHasBeenUpdated -= UpdateValue;
            GetComponent<StarterAssetsInputs>().Inventory -= ActivateInv;
            GetComponent<StarterAssetsInputs>().Pause -= ActivatePau;
        }
    }

}
