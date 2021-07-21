using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Fireball;
    public Transform Pivot;
    private float nextFire = 0f;
    public float fireRate = 1f;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Instantiate(Fireball, Pivot.position, Pivot.rotation);
        }
    }
}