using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private BirdData _birdData;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jumpForce = 7f;

    private void OnEnable()
    {
        transform.position = Vector3.zero;
        StartCoroutine(DelayEnable());

        // This functions wait until the player controller has an instance
        IEnumerator DelayEnable()
        {
            if (!PlayerController.Instance || !GameManager.Instance)
            {
                yield return new WaitUntil(() => PlayerController.Instance && GameManager.Instance);
            }

            // Add listeners to player's controller
            PlayerController.Instance.onJump.AddListener(OnJump);
        }
    }

    private void OnJump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
        PlayerController.Instance.onJump.RemoveListener(OnJump);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.GameOver();
        }
    }
}
