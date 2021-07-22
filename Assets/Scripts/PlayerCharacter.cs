using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    //���������� ����� � ������
    private int _health = 5;
    public int score = 0;

    public Text text;

    private void Start()
    {
        //��������������
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
    //�������
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " + _health);
    }
}