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

    [SerializeField]
    private int hitPoints = 100;

    private GameObject player;
    private RaycastHit hit;
    private Ray ray;
    private Vector3 direction;
    private NavMeshAgent agent;
    private Animator anim;

    private bool isRunning;
    private bool isWaving;

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

        UpdateAnimation();

        HandleActions();
    }

    void UpdateAnimation()
    {
        // Makes sure the player isn't dead if they regain HP
        if (hitPoints > 0)
        {
            anim.SetBool("isDead", false);
        }

        // Handles changes in animations
        if (hitPoints <= 0)
        {
            anim.SetBool("isDead", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWaving", false);
        }
        else if (isWaving)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWaving", true);
        }
        else if (AtGoal())
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWaving", false);
        }
        else if (!AtGoal() && !isRunning)
        {
            agent.speed = 2.8f;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWaving", false);
        }
        else if (!AtGoal() && isRunning)
        {
            agent.speed = 5;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isWaving", false);
        }
    }

    private void HandleActions()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            target.position = player.transform.position;
            isWaving = !isWaving;
            
        }
    }

    private void MoveTarget()
    {
        if (Input.GetKey("mouse 1"))
        {
            isWaving = false;
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
