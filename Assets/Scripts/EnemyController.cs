using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackCooldown = 1f;

    private CharacterController _controller;
    private Transform _playerTransform;
    private float _attackTimer;

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

        float distance = direction.magnitude;

        if (distance > attackRange)
        {
            direction.Normalize();
            _controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        _attackTimer += Time.deltaTime;

        if (distance <= attackRange && _attackTimer >= attackCooldown)
        {
            AttackPlayer();
            _attackTimer = 0f;
        }
    }

    private void AttackPlayer()
    {
        _playerTransform.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
    }   
}