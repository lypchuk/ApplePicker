using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // ������ ��� �������� �����
    public GameObject applePrefab;

    // �������� �������� ������
    public float speed = 1f;

    // ����������, �� ������� ������ ���������� ����������� �������� ������
    public float leftAndRightEdge = 10f;

    //��������� ���� �������� ����
    public float chanceToChangeDirections = 0.1f;

    // ������� �������� ����������� �����
    public float secondsBetweenAppleDrops = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ���������� ������ ��� � �������
        Invoke("DropApple", 2f);
    }

    void DropApple()
    { // b
        GameObject apple = Instantiate<GameObject>(applePrefab); // c
        apple.transform.position = transform.position; // d
        Invoke("DropApple", secondsBetweenAppleDrops); // e
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �����������
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // ��������� �����������
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); 
        }
        //else if (Random.value<chanceToChangeDirections ) {
        //    speed *= -1; // Change direction 11 b
        //}
    }

    void FixedUpdate()
    {
        // ������ ��������� ����� ����������� ��������� �� �������,
        // ������ ��� ����������� � FixedUpdateQ
        if (Random.value < chanceToChangeDirections)
        { 
            speed *= -1; // Change direction
        }
    }
}


