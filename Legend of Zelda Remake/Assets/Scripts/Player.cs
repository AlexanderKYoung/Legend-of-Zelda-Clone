using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float movespeed = 5f;


    public Rigidbody2D rb;
    public Vector3 change;
    public Animator animator;

    Vector2 movement;

    public int health = 3;

    //atributes for collectibles
    [SerializeField]
    private Text coinCounter;
    [SerializeField]
    private Text bombCounter;
    [SerializeField]
    private Text keyCounter;

    private int collidedCoinValue;
    private string collidedCoinName;
    private int moneyAmount;
    private int bombAmount;
    private int keyAmount;

    void Start() {
        //initialize values 
        moneyAmount = 0;
        bombAmount = 0;
        keyAmount = 0;

    }

    void Update()
    {
        //input
        change = Vector3.zero;

        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("Horizontal", change.x);
            animator.SetFloat("Vertical", change.y);
            animator.SetBool("moving", true);
        }
        else {
            animator.SetBool("moving", false);
        }



        if (Input.GetKeyDown("z"))
        {
            
            Debug.Log("z");
            StartCoroutine(AttackCo());
        }
        else if (Input.GetKeyDown("x"))
        {
            Debug.Log("x");
        }
        else {
            animator.SetBool("attacking", false);

        }



        // collectables counter, need to be moved to ui eventually
        coinCounter.text = "Money: " + moneyAmount;
        bombCounter.text = "Bomb: " + bombAmount;
        keyCounter.text = "Key: " + keyAmount;

    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
    }
    public void MoveCharacter() {
        rb.MovePosition(transform.position + change * movespeed * Time.fixedDeltaTime);
        }
    void FixedUpdate() {
        //movement

        
    }

    // on triggering collectibles
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Item") {

            collidedCoinValue = collision.gameObject.GetComponent<Item>().coinValue;
            collidedCoinName = collision.gameObject.GetComponent<Item>().coinName;
            //Debug.Log(collidedCoinName.Substring(0));
            //figure out which collectible it is
            if (collidedCoinName.Substring(0, 1).Equals("C"))
            {
                //bc money can add in increments of 5, add the coin then if over 99 make it 99
                moneyAmount += collidedCoinValue;
                if (moneyAmount > 99)
                {
                    moneyAmount = 99;
                }
            }
            // if the current is less than 99 add 1 
            else if (collidedCoinName.Substring(0, 1).Equals("B"))
            {
                if (bombAmount <= 99)
                {
                    bombAmount += collidedCoinValue;
                }
            }
            else
            {
                if (keyAmount <= 99)
                {
                    keyAmount += collidedCoinValue;
                }
            }
            // Debug.Log(moneyAmount);
            // Debug.Log(bombAmount);
            // Debug.Log(keyAmount);
            //destroy the object after collected
            Destroy(collision.gameObject);
        }
        
    }
}
