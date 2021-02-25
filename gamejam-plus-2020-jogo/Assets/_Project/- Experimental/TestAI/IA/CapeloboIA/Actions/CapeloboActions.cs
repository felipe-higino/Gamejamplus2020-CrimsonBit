using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapeloboActions : MonoBehaviour
{
    Rigidbody rb;
    float velocity;

    public float getVelocity()
    {
        return this.velocity;
    }

    public void setVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destination = transform.position;
    }

    Vector3 destination;

    public Vector3 getDestination()
    {
        return this.destination;
    }

    public void setDestination(Vector3 destination)
    {
        this.destination = destination;
    }

     public void GetTarget(Transform destiny){
        setDestination(destiny.position);
        GoToPoint();
    }


    public void GoToPoint(){
        transform.LookAt(destination);
        CorrectRotation();
        Vector3 pos = transform.position + transform.forward * velocity * Time.deltaTime;
        rb.MovePosition(pos);
    }

    public void GoAwayFromPoint(){
        transform.LookAt(destination);
        CorrectRotation();
        Vector3 pos = transform.position - transform.forward * velocity * Time.deltaTime;
        rb.MovePosition(pos);
    }

    void CorrectRotation(){
        Vector3 rot = transform.eulerAngles;
        rot.x = rot.z = 0f;
        transform.eulerAngles = rot;
    }

    bool tracking;

    public void Track(Transform target){
        if(!tracking){
            tracking = true;
            GetTarget(target);
            Invoke("canSnif",30f);
        }
    }
    void canSnif(){
        tracking = false;
    }
    
    bool OnJumpAttack = false;
    bool check = false;
    void StartCheck(){
        check = true;
    }
    public void JumpAttack(){
        if(OnJumpAttack) return;
        OnJumpAttack = true;
        rb.velocity = transform.up * 8f;
        Invoke("StartCheck",1f);
    }

    [SerializeField] LayerMask contactLayer;
    [SerializeField] float collisionFieldSize;
    public void CheckCollision(){
        if(!OnJumpAttack || !check) return;
        var contacts = Physics.OverlapSphere(transform.position,collisionFieldSize,contactLayer);

        if(contacts == null)
            return;

        foreach(var contact in contacts){
            if(contact.tag.Equals("Player")){
                Debug.Log("Player is Died");
                checkCondition.ChangeTo("KillingPrey");
                checkCondition.NextState(true);
                OnGround();
            }else{
                checkCondition.ChangeTo("WaitingAfterJump");
                checkCondition.NextState(true);
                OnGround();
            }
        }
    }

    void OnGround(){
         OnJumpAttack = false;
         check = false;
    }

    ChangeState checkCondition;
    public void SetState(ChangeState condition){
        checkCondition = condition;
    }

    

    public void GroundAttack(){
        Debug.Log("GROUND ATTACK");
    }

}
