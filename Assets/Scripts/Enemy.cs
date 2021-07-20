//using UnityEngine;
//using System.Collections;

//public class Enemy : MonoBehaviour
//{
//    //��������� �� ������� �� �������� ������ ������
//    public float seeDistance;
//    //��������� �� �����
//    public float attackDistance;
//    public Transform player;
//    public float move_speed;
//    public float rotation_speed;
//    public Transform enemy;

//    void Update()
//    {
//        var look_dir = player.position - 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */


public class Enemy : MonoBehaviour
{
    //��������� �� ������� �� �������� ������ ������
    
    //��������� �� �����
   
    //public Transform player;
    //public Transform enemy;

    public float seeDistance = 7f;
    public float attackDistance = 2f;
    public float speed;
    private Transform target;
    
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {

            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                transform.LookAt(target.transform);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

            }
        }
        else
        {

        }
    }

}