using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerFactory player;
    public float speed;
    Rigidbody rb;
    public Transform head;
    public float distance;
    public GameObject lickingSound, gameOverScreen;

    AnimationsController anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<PlayerFactory>();
        anim = GetComponentInChildren<AnimationsController>();
        gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    bool getPlayer;
    void Update()
    {
        HuntPlayer();
        RotateToPlayer(
            IsNearby() ||
            RangeOfViewInArea(distance * 1.5f, 1f) ||
            getPlayer
        );

    }


    void FixedUpdate()
    {
        Jump(
            Physics.Raycast(transform.position, -transform.up, 1f)
        );
        MoveToPlayer();
    }
    float time = 0;
    public float TimeToHunt;
    void HuntPlayer()
    {
        if (time >= TimeToHunt)
        {
            getPlayer = !getPlayer;
            if (getPlayer)
                time = TimeToHunt / 2;
            else
                time = 0f;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    void RotateToPlayer(bool nearby)
    {
        head.LookAt(player.transform);
        Vector3 rot = head.eulerAngles;
        rot.x = 0f;
        rot.z = 0f;
        if (nearby)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.Euler(new Vector3(0, rot.y, 0)),
                0.05f
            );
            //anim.SetAnimation("quadruped",true);
        }
        else
        {
            rot.y += 45f;
            transform.eulerAngles = rot;
            //anim.SetAnimation("quadruped",false);
        }

    }
    void MoveToPlayer()
    {
        Vector3 move = rb.position + transform.forward * speed * Time.deltaTime;
        rb.MovePosition(move);
    }

    void Jump(bool jump)
    {
        if (!jump) return;
        if (Mathf.Abs(transform.position.y - player.transform.position.y) > 3f)
            rb.velocity = transform.up * 8f;
    }

    bool RangeOfViewInArea(float distance, float range)
    {
        RaycastHit hit;
        float direction = Vector3.Dot((player.transform.position - transform.position).normalized, transform.forward);
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
            if (Physics.Linecast(head.position, player.transform.position, out hit) && direction > range)
            {
                return hit.transform.Equals(player.transform);
            }
        return false;
    }
    bool IsNearby()
    {
        return Vector3.Distance(transform.position, player.transform.position) < distance;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            player.enabled = false;
            Camera.main.GetComponent<CameraFactory>().enabled = false;
            lickingSound.SetActive(true);
            // if(UIEvents.Instance != null)
            //     UIEvents.Instance.Die.OnDie();
            // else
            //     gameOverScreen.SetActive(true);

        }
    }
}
