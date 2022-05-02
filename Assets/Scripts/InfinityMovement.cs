using UnityEngine;

public class InfinityMovement : MonoBehaviour
{
    [SerializeField] private float period;
    [SerializeField] private Vector2 range;
    [SerializeField] private Vector2 ratio;

    private Vector2 startPosition;
    private void Start() => startPosition = transform.position;
    private void FixedUpdate() => Movement();
    

    private void Movement()
    {
        Vector2 oscillation;
        oscillation.x = range.x * (Screen.width / 1080f) *
                        Mathf.Sin(Time.time % (2 * period) * Mathf.PI * ratio.x / period) * 0.5f;
        oscillation.y = range.y * (Screen.height / 1920f) *
                          Mathf.Sin(Time.time % (2 * period) * Mathf.PI * ratio.y / period) * 0.5f;

        transform.position = startPosition + oscillation;
    }
}
