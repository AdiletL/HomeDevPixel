using Puzzle;
using UnityEngine;

namespace Puzzle {

public class Pushable : MonoBehaviour
{
    public float pushForce = 5f;

    private Rigidbody rb;
    private Vector3 pushDirection; // Направление толчка

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>(); // Добавляем Rigidbody, если его нет
        }
    }

    public void Push(CharacterPush characterPush)
    {
        // Получаем направление от игрока к объекту
        pushDirection = transform.position - characterPush.transform.position;
        pushDirection.Normalize();
        pushDirection.y = 0; // Убираем вертикальную составляющую, чтобы не подпрыгивал

        // Применяем силу к объекту
        rb.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);
    }
}

}