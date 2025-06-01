using UnityEngine;
using AC; // Для интеграции с Adventure Creator (опционально)

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public bool useACNavigation = false; // Использовать ли навигацию AC

    private Vector2 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetMoveTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    void SetMoveTarget(Vector2 target)
    {
        targetPosition = target;
        isMoving = true;

        if (useACNavigation && AC.KickStarter.player != null)
        {
            // Если нужно интегрировать с Adventure Creator
            AC.KickStarter.player.MoveToPoint(new Vector3(target.x, target.y, 0));
            this.enabled = false; // Отключаем этот контроллер
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}