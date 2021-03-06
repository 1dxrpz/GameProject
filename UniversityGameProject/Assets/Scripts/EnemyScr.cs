using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    private NavMeshAgent enemyBot;

    private int counterForAttak = 0;

    internal bool isTroww = false;

    [Header("?????")]
    public GameObject Player;

    [Header("??? ???????")]
    public GameObject Bullet;
    [Header("???? ?????? ???????")]
    public float Power;

    [Header("????? ????????, ? ?????")]
    public GameObject[] CounOfBulets;

    [Header("????? ??????")]
    public GameObject[] CountOfEnemy;

    [Header("????????? ????????")]
    public float distDetection;
    [Header("????????? ??????")]
    public float distAttack;
    [Header("???????? ????????????")]
    public float move_speed;
    [Header("???????? ????????")]
    public float rotation_speed;

    [Header("????? ???????, ? ?????")]
    public GameObject[] posForMove;
    public Vector3 curentPoint;
    private int counterForStay = 0;

    private bool detect = false;

    private void Start()
    {
        // ?????????????? ????-?????
        enemyBot = GetComponent<NavMeshAgent>();
        enemyBot.speed = move_speed;

        // ?????????????? ????? ???????????
        posForMove = GameObject.FindGameObjectsWithTag("PointForMove");
    }

    void Update()
    {
        bool isHiden = Player.GetComponent<PlayerController>().IsHidden;

        RaycastHit hit;
        Ray ray = new Ray(transform.position, 
            Player.transform.position - transform.position);

        Physics.Raycast(ray, out hit);

        bool wallDetect = false;

        if(hit.collider.tag == "Object")
        {
            wallDetect = true;
        }

        if ((Vector3.Distance(Player.transform.position, transform.position) <= distDetection) && !isHiden && !wallDetect)
            detect = true;
        else
            detect = false;

        if (detect)
        {
            //isTroww = true;
            MoveOrAttack();
        }

        if (!detect)
        {
            isTroww = false;
            enemyBot.isStopped = false;
            curentPoint = posForMove[Random.Range(0, posForMove.Length)].transform.position;
            JustMove();
        }
    }

    private void MoveOrAttack()
    {
        GetComponent<NavMeshAgent>().stoppingDistance = 3.5f;

        GetComponent<NavMeshAgent>().enabled = true;
        if (Vector3.Distance(Player.transform.position, transform.position) < distAttack)
        {
            var look_dir = (Player.transform.position - transform.position).normalized;
            if ((Quaternion.LookRotation(look_dir).eulerAngles.y + 0.5f >= transform.rotation.eulerAngles.y) &&
                (Quaternion.LookRotation(look_dir).eulerAngles.y - 0.5f <= transform.rotation.eulerAngles.y))
            {
                RaycastHit hit;
                Ray ray = new Ray(transform.position, Player.transform.position - transform.position);
                Physics.Raycast(ray, out hit);
                if (hit.collider.tag != "Object" )
                {
                    enemyBot.isStopped = true;
                    isTroww = true;
                    Attack();
                }
            }
            else
            {
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), 
                    rotation_speed * 5 * Time.deltaTime);
            }
        }
        else
        {
            isTroww = false;
            enemyBot.isStopped = false;
            enemyBot.destination = Player.transform.position;
        }
    }

    private void Attack()
    {
        GetComponent<NavMeshAgent>().stoppingDistance = 3.5f;

        CounOfBulets = GameObject.FindGameObjectsWithTag("Bulet");

        if (CounOfBulets.Length < 1)
        {
            if (counterForAttak >= 250)
            {
                var look_dir = (Player.transform.position - transform.position).normalized;

                GameObject b = Instantiate(Bullet, transform.position, transform.rotation);
                b.tag = "Bulet";

                b.GetComponent<Rigidbody>().AddForce(look_dir * Power, ForceMode.Impulse);
                isTroww = false;
                counterForAttak = 0;
            }
            counterForAttak++;
        }
    }


    private void JustMove()
    {
        GetComponent<NavMeshAgent>().stoppingDistance = 0;

        if (counterForStay >= 700)
        {
            MoveAtPoint();
        }
        else
        {
            counterForStay++;
        }
    }

    private void MoveAtPoint()
    {
        if (!enemyBot.hasPath)
            enemyBot.destination = curentPoint;
        else
        {
            curentPoint = posForMove[Random.Range(0, posForMove.Length)].transform.position;
        }
        counterForStay = 0;
    }
}
