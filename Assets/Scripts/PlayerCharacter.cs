using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    //Количество жизни у игрока
    private int _health = 5;
    public int score = 0;

    public Text text;

    private void Start()
    {
        //Инициализируем
        _health = 5;
    }
    private void FixedUpdate()
    {
        text.GetComponent<Text>().text = "Score: " + score;
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