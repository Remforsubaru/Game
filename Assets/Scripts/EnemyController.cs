
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyController : MonoBehaviour
//{
//    [Header("Название заголовка")]
//    [Tooltip("Для чего нужна переменная")]
//    [SerializeField]
//    private GameObject[] _enemyPrefab;//массив объектов шаблонов
//    private GameObject _enemy;

//    private void Update()
//    {
//        //Создаем нового врага, если врагов нет
//        //Так можно регулировать количество врагов на сцене
//        if (_enemy == null)
//        {
//            int randEnemy = Random.Range(1, _enemyPrefab.Length);//случайно выбираем врага
//            _enemy = Instantiate(_enemyPrefab[randEnemy]) as GameObject;//создаем клона как игровой объект
//            _enemy.transform.position = new Vector3(0, 3, 0);//задаем позицию появления

//            float angle = Random.Range(0, 360);
//            _enemy.transform.Rotate(0, angle, 0);//поворачиваем
//        }
//    }
////}
///



//using UnityEngine;
//using UnityEngine.AI;
//using System.Collections;

///* Makes enemies follow and attack the player */

////[RequireComponent(typeof(CharacterCombat))]
//public class EnemyController : MonoBehaviour
//{

//    public float lookRadius = 10f;

//    Transform target;
//    NavMeshAgent agent;
//    //CharacterCombat combatManager;

//    void Start()
//    {
//        //target = Player.instance.transform;
//        agent = GetComponent<NavMeshAgent>();
//        //combatManager = GetComponent<CharacterCombat>();
//    }

//    void Update()
//    {
//        // Get the distance to the player
//        //float distance = Vector3.Distance(target.position, transform.position);

//        // If inside the radius
//    //    if (distance <= lookRadius)
//    //    {
//    //        // Move towards the player
//    //        agent.SetDestination(target.position);
//    //        if (distance <= agent.stoppingDistance)
//    //        {
//    //            // Attack
//    //            //combatManager.Attack(Player.instance.playerStats);
//    //            FaceTarget();
//    //        }
//    //    }
//    }

//    // Point towards the player
//    void FaceTarget()
//    {
//        Vector3 direction = (target.position - transform.position).normalized;
//        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
//    }

//    void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, lookRadius);
//    }

//}