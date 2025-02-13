using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

   
    [SerializeField] private Transform enemy;

  
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

  
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        if(anim != null)
        anim.SetBool("BlackRun", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        if(anim == null) return;
        anim.SetBool("BlackRun", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        if(anim == null) return;
        idleTimer = 0;
        anim.SetBool("BlackRun", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}