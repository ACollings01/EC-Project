using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public LayerMask layerMask;
    public float accuracy = 0.1f;

    [SerializeField]
    private int strength;
    [SerializeField]
    private int dexterity;
    [SerializeField]
    private int constitution;
    [SerializeField]
    private int intelligence;
    [SerializeField]
    private int wisdom;
    [SerializeField]
    private int charisma;

    private GameObject player;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 direction;
    private NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerModel");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the screen to the mouse position
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        MoveTarget();

        agent.SetDestination(target.position);

        anim.SetBool("isWalking", !AtGoal());
    }

    private void MoveTarget()
    {
        if (Input.GetKey("mouse 1"))
        {
            if (Physics.Raycast(ray, out hit, 1000, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.point != target.position)
                {
                    target.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
            }
        }

        if (Input.GetKey("s"))
        {
            target.position = player.transform.position;
        }

        // Account for changes in player's y
        target.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }

    private bool AtGoal()
    {
        if ((transform.position - target.position).magnitude <= accuracy)
        {
            return true;
        }
        return false;
    }

    public int GetSTR() { return strength; }
    public int GetDEX() { return dexterity; }
    public int GetCON() { return constitution; }
    public int GetINT() { return intelligence; }
    public int GetWIS() { return wisdom; }
    public int GetCHA() { return charisma; }

    public void SetSTR(int str) { strength = str; }
    public void SetDEX(int dex) { dexterity = dex; }
    public void SetCON(int con) { constitution = con; }
    public void SetINT(int intel) { intelligence = intel; }
    public void SetWIS(int wis) { wisdom = wis; }
    public void SetCHA(int cha) { charisma = cha; }
}
