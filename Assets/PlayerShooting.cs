using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100.0f;              // kuinka pitk‰lle ampunin voi tapahtua

    public float damage = 25.0f;              // kuinka paljon damagea tehd‰‰n

    public Camera fpsCamera;                  // mihin kameraan pyssy laitetaan

    public LayerMask shootingLayer;           // Mihin layeriin pyssy voi vaikuttaa



    void Update()

    {

        if (Input.GetButtonDown("Fire1"))

        {

            Shoot();

        }

    }



    void Shoot()

    {

        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, shootingLayer))

        {

            // Debuggausta, piirrell‰‰n drawray, kun osutaan kohteeseen

            Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * range, Color.red, 2.0f);



            // checkaa jos objekti on sellainen mihin voi osua

            IDamageable damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable != null)

            {

                damageable.TakeDamage(damage);

            }

        }

    }

}



// t‰ss‰ se interface nyt tehd‰‰n

public interface IDamageable

{

    void TakeDamage(float damageAmount);
}
