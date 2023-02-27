using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;
    [SerializeField]
    private Transform enemy;
    [SerializeField]
    private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [SerializeField]
    private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("enemyWalk", true);
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        anim.SetBool("enemyWalk", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
