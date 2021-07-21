using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //Количество жизни у игрока
    private int _health = 5;

    private void Start()
    {
        //Инициализируем
        _health = 5;
    }
    private void FixedUpdate()
    {
        if ( _health < 1)
        {
            Debug.Log("Lol, you died!");
            Application.Quit();
        }
    }
    //Ранение
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " + _health);
    }
}