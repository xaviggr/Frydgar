using UnityEngine;

public class CreatureRaycast : InteractionRaycast
{
    public GameObject player;
    public CreatureVision cv;
    public Animator _animator;

    void OnEnable()
    {
        cv.AddTarget += AddTarget;
        cv.RemoveTarget += RemoveTarget;
    }

    void OnDisable()
    {
        cv.AddTarget -= AddTarget;
        cv.RemoveTarget -= RemoveTarget;
    }

    public void AddTarget(GameObject obj)
    {
        player = obj;
    }

    public void RemoveTarget(GameObject obj)
    {
        player = null;
    }

    void Update()
    {
        if (player != null)
        {
            RaycastHit hit;

            Vector3 dir = player.transform.position - transform.position;
            dir += new Vector3(0, 1, 0);

            if (Physics.Raycast(transform.position, dir, out hit, distance, layermask))
            {
                if (hit.transform == player.transform)
                {
                    _animator.SetBool("isPatrolling", false);
                    _animator.SetBool("isPursuiting", true);
                }
            }
        }
        else
        {
            _animator.SetBool("isPatrolling", true);
            _animator.SetBool("isPursuiting", false);
        }
    }

    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        if (player != null)
        {
            Gizmos.color = Color.red;
            Vector3 dir = player.transform.position - transform.position;
            dir += new Vector3(0, 1, 0);
            Gizmos.DrawRay(transform.position, dir);
        }
    }
}