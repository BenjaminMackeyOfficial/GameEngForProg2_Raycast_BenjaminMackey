using UnityEngine;
using static UnityEngine.UI.Image;

public class turret : MonoBehaviour
{
    [SerializeField] float speed;
    private Quaternion targPos = Quaternion.identity;

    void Update()
    {
        LayerMask mask = LayerMask.GetMask("Target");

        RaycastHit hit;
        Iinteractible targ;
        
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, 50, mask) && hit.collider.gameObject.TryGetComponent<Iinteractible>(out targ))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);

            AdjustForTargetLock(hit.transform);
            targ.Interact();
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 50, Color.red);
            IdleSearch();
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targPos, speed * Time.deltaTime);
    }

    private void IdleSearch()
    {
        targPos *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }
    private void AdjustForTargetLock(Transform t)
    {
        Vector3 dir = t.position - transform.position;
        dir.y = 0;

        targPos = Quaternion.LookRotation(dir, Vector3.up);
    }
}
