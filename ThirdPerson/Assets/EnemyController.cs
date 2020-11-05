using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float meleeRange = 1.0f;

    public LayerMask playerLayer;
    public LayerMask environmentLayer;

    [Header("References")]
    [SerializeField]
    PlayerController player;
    [SerializeField]
    EnemySight sight;
    [SerializeField]
    Collider[] ragdollColliders;

    Vector3 goalLocation;
    bool shouldMove = false;
    bool dead = false;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Collider c in ragdollColliders)
        {
            c.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;
        if(ScanForPlayer())
        {
            shouldMove = true;
            transform.LookAt(new Vector3(goalLocation.x, 0, goalLocation.z));
        }

        if(shouldMove && Vector3.Distance(transform.position, goalLocation) < meleeRange)
        {
            shouldMove = false;
        }
        
        GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * (shouldMove ? 1 : 0);
        GetComponent<Animator>().SetFloat("moveSpeed", GetComponent<Rigidbody>().velocity.magnitude);

        /*if(Input.GetButton("Jump"))
        {
            GoRagdoll();
        }*/
    }

    bool ScanForPlayer()
    {
        foreach (SightInformation s in sight.CheckForObject())
        {
            // if we find player, and we're not super close, set goal location
            if (s.seen && s.tag == "Player" && Vector3.Distance(transform.position, s.location) > meleeRange)
            {
                goalLocation = s.location;
                goalLocation.y = 0;
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sword" && !dead)
        {
            GoRagdoll();

            Destroy(gameObject, 3.0f);
        }
    }

    void GoRagdoll()
    {
        shouldMove = false;
        GetComponent<CapsuleCollider>().isTrigger = true;
        dead = true;
        GetComponent<Animator>().enabled = false;

        foreach (Collider c in ragdollColliders)
        {
            c.isTrigger = false;
        }
    }

    
}
