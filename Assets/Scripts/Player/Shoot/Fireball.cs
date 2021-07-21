using UnityEngine;

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
            Destroy (this.gameObject); //Иногда ругается и не дает вызывать новый объект, но последнее время такого не было
        }
        LastPos = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (enemy != null)
        {
            enemy.TakeDamage(2);
        }
        if (player != null)
        {
            player.Hurt(1);
        }
    }
}

