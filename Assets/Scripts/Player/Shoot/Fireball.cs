//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Fireball : MonoBehaviour
//{
//    public float speed = 10f;//скорость движения 
//    public int damage = 1;//наносимый урон

//    private void Update()
//    {
//        //У огненного шара постоянное движение вперед
//        transform.Translate(0, 0, speed * Time.deltaTime);
//    }

//    //Когда с тригером столкнется другой объект, вызывется этот метод
//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log(other.name);

//        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
//        if (player != null)
//        {
//            player.Hurt(damage);
//        }

//        Destroy(this.gameObject);
//    }

//}

//using UnityEngine;
//using System.Collections;

//public class Fireball : MonoBehaviour
//{
//    public Transform BulletPrefab;
//    public float reloadTimer = 0f;
//    public const float reloadCooldown = 0.1f;
//    void Updat()
//    {
//        if (Input.GetButton("Fire1"))
//        {
//            if (reloadTimer > 0) reloadTimer -= Time.deltaTime;
//            if (reloadTimer <= 0)
//            {
//                reloadTimer = reloadCooldown;
//                var instance = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
//            }
//        }
//    }
//}
// Instantiates a projectile every 0.5 seconds,
// if the Fire1 button (default is Ctrl) is pressed.

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Fireball : MonoBehaviour
{
   
    private float myTime = 0.0F;
    public float speed = 15f;//скорость движения \
    public int damage = 1;//наносимый урон
    public float Scale;

    Vector3 LastPos;

    void Start()
    {
        LastPos = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit hit;

        if (Physics.Linecast(LastPos, transform.position, out hit))
        {
            print(hit.transform.name);
            Destroy (this.gameObject);
        }
        LastPos = transform.position;
    }

    ////Когда с тригером столкнется другой объект, вызывется этот метод
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.name);

    //    PlayerCharacter player = other.GetComponent<PlayerCharacter>();
    //    if (player != null)
    //    {
    //        player.Hurt(damage);
    //    }

    //    Destroy(this.gameObject);
    //}

}

