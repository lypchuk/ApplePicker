using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Ўаблон дл€ создани€ €блок
    public GameObject applePrefab;

    // —корость движени€ €блони
    public float speed = 1f;

    // –ассто€ние, на котором должно измен€тьс€ направление движени€ €блони
    public float leftAndRightEdge = 10f;

    //…мов≥рн≥сть зм≥ни напр€мку руху
    public float chanceToChangeDirections = 0.1f;

    // „астота создани€ экземпл€ров €блок
    public float secondsBetweenAppleDrops = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // —брасывать €блоки раз в секунду
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
        // ѕростое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // »зменение направлени€
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
        // “еперь случайна€ смена направлени€ прив€зана ко времени,
        // потому что выполн€етс€ в FixedUpdateQ
        if (Random.value < chanceToChangeDirections)
        { 
            speed *= -1; // Change direction
        }
    }
}


