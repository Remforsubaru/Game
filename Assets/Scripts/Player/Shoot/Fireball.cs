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

    

}

