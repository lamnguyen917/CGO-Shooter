using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseCharacter
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool targetPlayer;
    [SerializeField] private float rotationSpeed = 0.25f;
    [SerializeField] private float damage = 10;
    [SerializeField] private Animator animator;
    private static readonly int AttackAnim = Animator.StringToHash("IsAttack");

    private Transform PlayerTransform => GameManager.Instance.player.transform;
    private float DistanceToPlayer => (transform.position - PlayerTransform.position).magnitude;

    private void Start()
    {
        // agent.SetDestination(GameManager.Instance.baseTransform.position);
    }

    private void Update()
    {
        if (targetPlayer && GameManager.Instance.player)
        {
            MoveTowardPlayer();
        }
    }

    void MoveTowardPlayer()
    {
        agent.SetDestination(GameManager.Instance.player.transform.position);
        // float rotationAngle = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        //
        // // Apply rotation to the character
        // transform.Rotate(Vector3.up, rotationAngle);
        //
        // // Clear the Nav Mesh Agent's desired velocity to prevent any movement
        // agent.velocity = Vector3.zero;

        if (DistanceToPlayer <= 1)
        {
            animator.SetBool(AttackAnim, true);
        }
    }

    void Damage()
    {
        animator.SetBool(AttackAnim, false);
        if (DistanceToPlayer > 1) return;
        Debug.Log("Damage by enemy");
        GameManager.Instance.player.GetComponent<BaseCharacter>().Damage(damage, Vector3.zero);
    }

    protected override void Dead()
    {
        base.Dead();
        GameManager.Instance.onEnemyDeath.Invoke();
    }
}
