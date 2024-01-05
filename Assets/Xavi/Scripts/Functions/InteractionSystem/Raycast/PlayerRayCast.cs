using UnityEngine;

public class PlayerRayCast : InteractionRaycast
{
    public Camera cam;
    [SerializeField] InteractionReceiver interaction_ontarget;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, this.distance, this.layermask))
        {
            if (hit.transform.gameObject.TryGetComponent(out InteractionReceiver IR))
            {
                if (IR != interaction_ontarget)
                {
                    if (interaction_ontarget == null)
                    {
                        interaction_ontarget = IR;
                        interaction_ontarget.Receive(null);
                    }
                    else
                    {
                        interaction_ontarget.Out(null);
                        interaction_ontarget = IR;
                        interaction_ontarget.Receive(null);
                    }
                }

            }
            else if (interaction_ontarget != null)
            {
                interaction_ontarget.Out(null);
                interaction_ontarget = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = cam.transform.TransformDirection(Vector3.forward) * this.distance;
        Gizmos.DrawRay(cam.transform.position, direction);
    }

    private void ActivateInteraction()
    {
        if (interaction_ontarget != null)
        {
            if (interaction_ontarget.gameObject.TryGetComponent(out InteractionAction i))
            {
                foreach (InteractionAction action in interaction_ontarget.gameObject.GetComponents<InteractionAction>())
                {
                    action.Act(this.gameObject);
                }
            }
        }
    }

    private void OnEnable()
    {
        this.GetComponent<StarterAssets.StarterAssetsInputs>().Interact += ActivateInteraction;
    }

    private void OnDisable()
    {
        this.GetComponent<StarterAssets.StarterAssetsInputs>().Interact -= ActivateInteraction;
    }
}
