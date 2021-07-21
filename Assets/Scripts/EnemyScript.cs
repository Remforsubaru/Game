//using UnityEngine;
//using System.Collections;

//[ExecuteInEditMode]
//[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]


//public class EnemyScript : MonoBehaviour
//{
//    private SpriteRenderer spriteRenderer;
//    private Animator animator;
//    private BoxCollider2D collider;
//    private Rigidbody2D rigidBody;
    

//    void Awake()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        animator = GetComponent<Animator>();
//        collider = GetComponent<BoxCollider2D>();
//        rigidBody = GetComponent<Rigidbody2D>();
        

//        rigidBody.isKinematic = true;
//    }
//}