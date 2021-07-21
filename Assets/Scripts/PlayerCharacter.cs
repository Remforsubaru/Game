using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //���������� ����� � ������
    private int _health = 5;

    private void Start()
    {
        //��������������
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
    //�������
    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " + _health);
    }
}