using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();// b
                                                                           // Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }        
    }
}
