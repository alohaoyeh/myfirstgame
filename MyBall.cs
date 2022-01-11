using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBall : MonoBehaviour
{
    Rigidbody rigid;
    bool isJump;
    public float jumpPower;
    public int itemCount;
    AudioSource audio;
    public GameManagerLogic manager;


    void Awake() {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        if(Input.GetButtonDown("Jump") && !isJump) {
        isJump = true;
        rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    
    }
    

    void FixedUpdate()
    {

        Vector3 vec = new Vector3(
            Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        rigid.AddForce(vec * 3, ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "ItemCan") {
            itemCount ++;
            audio.Play();
            other.gameObject.SetActive(false);         
        }

        else if (other.tag == "Point") {
            if(itemCount == manager.totalItemCount) {
                //Game Clear!
                SceneManager.LoadScene("Example1_" + (manager.stage + 1).ToString());

            }
            else {
                //Restart...
                SceneManager.LoadScene("Example1_" + manager.stage.ToString());

            }
        } 
    }
}


