using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float enemySpeed;
    Transform player;

    bool activated = true;

    private void Start()
    {
        enemySpeed = Random.Range(0.1f, 2.0f);
        player = FindAnyObjectByType<PlayerMovement>().GetComponent<Transform>();

        SetRandomPosition();
    }

    void SetRandomPosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.x = Random.Range(0f, Screen.width);
        screenPos.y = Random.Range(0f, Screen.height);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    private void Update()
    {
        if (!activated)
            return;

        Vector2 runAwayPath = (transform.position - player.position).normalized;
        transform.Translate(runAwayPath * enemySpeed * Time.deltaTime);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.x = Mathf.Clamp(screenPos.x, 0f, Screen.width);
        screenPos.y = Mathf.Clamp(screenPos.y, 0f, Screen.height);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    public void EnemyHit()
    {
        activated = false;
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
