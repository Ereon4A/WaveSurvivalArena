using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private CharacterController _controller;
    private Transform _playerTransform;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (_playerTransform == null) return;

        Vector3 direction = _playerTransform.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > 1f)
        {
            direction.Normalize();
            _controller.Move(direction * moveSpeed * Time.deltaTime);
        }
    }
}