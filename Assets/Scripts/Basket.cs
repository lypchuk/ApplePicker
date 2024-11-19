using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    //public Text scoreGT;
    public TextMeshProUGUI scoreGT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // b
                                                      // �������� ��������� Text ����� �������� �������
        //scoreGT = scoreGO.GetComponent<Text>(); // �
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>(); // �
                                                // ���������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition; // a
                                                  // ���������� Z ������ ����������, ��� ������ � ���������� ������������
                                                  // ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z; // b
                                                          // ������������� ����� �� ��������� ��������� ������ � ����������
                                                          // ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // c
                                                                         // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    { 
       
        // �������� ������, �������� � ��� �������
        GameObject collidedWith = coll.gameObject; // b
        if (collidedWith.tag == "Apple")
        { 
            Destroy(collidedWith);

            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text); 

                                                 // �������� ���� �� ��������� ������
            score += 100;
            // ������������� ����� ����� ������� � ������ � ������� �� �� �����
            scoreGT.text = score.ToString();

            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}

