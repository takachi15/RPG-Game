using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] Collider2D SwordCollider;
    Vector2 attackoffset;
    public enum AttackDirection
    {
        Right,
        Left
    }
    
    public AttackDirection attackDirection;
    public void Attack(AttackDirection direction)
    {
        switch (direction)
        {
            case AttackDirection.Right:
                AttackRight();
                print("AttackRight");
                break;
            case AttackDirection.Left:
                AttackLeft();
                print("AttackLeft");
                break;
            default:
                StopAttack();
                break;
        }
    }
    private void Start()
    {
        SwordCollider = GetComponent<Collider2D>();
        attackoffset = transform.position;
        Attack(attackDirection);
    }
    private void AttackRight()
    {
        
        SwordCollider.enabled = true;
        attackoffset = transform.position;
    }
    private void AttackLeft()
    {
        
        SwordCollider.enabled = true;
        attackoffset = new Vector2(-transform.position.x, transform.position.y);
    }
    private void StopAttack()
    {
        SwordCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
