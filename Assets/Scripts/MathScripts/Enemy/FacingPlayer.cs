using UnityEngine;
using System.Collections;

public class FacingPlayer : MonoBehaviour
{
    public float rotSpeed = 90f, rotSpeed2 = 180f, cooldownTimer = 0f;
    public GameObject[] Target;
    public Transform player;
    public bool look;
    public int current = 1;
    private float fireDelay;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public GameObject bulletPrefab;

    void Start()
    {
        newPos();
        Target = GameObject.FindGameObjectsWithTag("Target");
    }

    //keeps enemy focoused on the player when they answer incorrectly so they can shoot the player
    void Update()
    {
        if (look != true)
        {
            Vector3 dir = Target[current].transform.position - transform.position;
            dir.Normalize();

            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

            if (this.transform.position == Target[current].transform.position)
            {
                newPos();
            }
        }
        else
        {
            shootPlayer();
        }
    }


    //if the enemy colldies with its target its given a new target
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Target")
        {
            newPos();
        }
    }

    //if the enemy collides with the player its given a new target
    void OnTriggerStay2D(Collider2D collis)
    {

        if (collis.gameObject.tag == "Player")
        {
            newPos();
        }
    }

    void newPos()
    {
        current = Random.Range(0, Target.Length);
    }

    //when called the correct asnwer stops moving and faces the palyer and shoots
    void shootPlayer()
    {
        this.GetComponent<ProjectileMovment>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;


        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");

            if (go != null)
            {
                player = go.transform;

            }
        }

        if (player == null)
        {
            return;
        }
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed2 * Time.deltaTime);

        fireDelay = 1f;
        cooldownTimer -= Time.deltaTime;

        //if the cooldownTimer is equal to 0 then the enemy shotos once
        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            SoundEffects.Instance.MakeEnemyShotSound();
            Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);

        }

    }
}
