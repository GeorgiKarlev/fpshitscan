using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;					// Kuinka pitk‰n aikaa kest‰‰, ett‰ kranaatti r‰j‰ht‰‰.

    public float blastRadius = 5f;			// Kuinka iso r‰j‰hdys on.

    public float explosionForce = 700f;		// R‰j‰hdyksen voima.

    public float damageAmount = 50f;			// Kuinka paljon damagea kranaatti aiheuttaa.

    public LayerMask damageableLayer;			// Layer johon kranaatti vaikuttaa.



    private bool hasExploded = false;			// Booli r‰j‰hdykselle.



    void Start()

    {

        StartCoroutine(ExplodeAfterDelay());

    }



    IEnumerator ExplodeAfterDelay()

    {

        yield return new WaitForSeconds(delay);

        Explode();

    }



    void Explode()

    {

        if (hasExploded) return;



        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius, damageableLayer);

        foreach (Collider nearbyObject in colliders)

        {

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)

            {

                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);

            }



            IDamageable damageable = nearbyObject.GetComponent<IDamageable>();

            if (damageable != null)

            {

                damageable.TakeDamage(damageAmount);

            }

        }



        // TODO: Lis‰‰ efektej‰ r‰j‰hdykseen



        hasExploded = true;

        Destroy(gameObject);

    }
}
