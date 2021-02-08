using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmoriController : MonoBehaviour
{
    [SerializeField, HideInInspector] Animator unitychanAnimator;
    public LayerMask groundMask;
    [HideInInspector] public Vector2 hajiLeft, hajiRight, centerX;
    [SerializeField] float direction;
    Rigidbody2D omoriRb,unitychanRb;
    MoveCharacterAction unitychanController;
    //public int omoriMass = 1;

    // Start is called before the first frame update
    void Start()
    {
        omoriRb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hajiLeft = new Vector2(transform.position.x - (0.47f * transform.lossyScale.x), transform.position.y);
        hajiRight = new Vector2(transform.position.x + (0.47f * transform.lossyScale.x), transform.position.y);
        centerX = new Vector2(transform.position.x, transform.position.y);

        Debug.DrawRay(hajiLeft, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(hajiRight, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(centerX, Vector2.down * 0.52f, Color.yellow);
        Debug.DrawRay(hajiLeft, Vector2.left * 0.05f, Color.red);
        Debug.DrawRay(hajiRight, Vector2.right * 0.05f, Color.red);

        if(/*Physics2D.Raycast (hajiLeft, Vector2.down, 0.55f, groundMask) && Physics2D.Raycast (hajiRight, Vector2.down, 0.55f, groundMask)||*/ Physics2D.Raycast (centerX, Vector2.down, 0.52f, groundMask))
        {
            //Debug.Log("地上");
            Vector2 groundVelocity = omoriRb.velocity;

            if(Physics2D.Raycast (hajiLeft, Vector2.left, 0.05f, groundMask) || Physics2D.Raycast (hajiRight, Vector2.right, 0.05f, groundMask))
            {
                groundVelocity.x = 0f;
                //omoriRb.bodyType = RigidbodyType2D.Static;
                //gameObject.GetComponent<OmoriController>().enabled = false;
            }
            groundVelocity.y = 0f;
            omoriRb.velocity = groundVelocity;
        }else if(!Physics2D.Raycast (hajiLeft, Vector2.down, 0.52f, groundMask) && !Physics2D.Raycast (hajiRight, Vector2.down, 0.52f, groundMask))
        {
            //Debug.Log("地上じゃない");
            omoriRb.velocity = Vector2.down * 2;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D thisCollision)
    {
        if(Physics2D.Raycast (hajiLeft, Vector2.left, 0.05f, groundMask) ||Physics2D.Raycast (hajiRight, Vector2.right, 0.05f, groundMask))
        {

        }
        else if(thisCollision.gameObject.tag == "Character")
        {
            //Debug.Log("キャラに触れた");
            //unitychanをwalkモーションに変更
            unitychanAnimator = thisCollision.gameObject.GetComponent<Animator>();
            unitychanAnimator.SetFloat ("Speed", 0.1f);　
            //unitychanを動けなくする
            unitychanController = thisCollision.gameObject.GetComponent<MoveCharacterAction>();
            unitychanController.enabled = false;
            //unitychanをobstacleの後一定距離につける
            unitychanRb = thisCollision.gameObject.GetComponent<Rigidbody2D>();
            unitychanRb.bodyType = RigidbodyType2D.Kinematic;
            unitychanRb.velocity = Vector2.right * 0.97f * direction;
            omoriRb.velocity = Vector2.right * direction;

            /*
            //1.0f以内に壁があればそれに応じて止まる
            if(Physics2D.Raycast (hajiLeft, Vector2.left, 1.0f, groundMask) ||Physics2D.Raycast (hajiRight, Vector2.right, 1.0f, groundMask))
            {
                float rightDistance = Physics2D.Raycast (hajiRight, Vector2.right, 1.0f, groundMask).distance;
                float leftDistance = Physics2D.Raycast (hajiLeft, Vector2.left, 1.0f, groundMask).distance;
                //Debug.Log(rightDistance);
                //Debug.Log(leftDistance);
                yield return new WaitForSeconds(rightDistance + leftDistance - 0.1f);
                unitychanRb.velocity = Vector2.zero;
                yield return new WaitForSeconds(0.02f);
                omoriRb.velocity = Vector2.zero;
                unitychanRb.bodyType = RigidbodyType2D.Dynamic;
                unitychanController.enabled = true;
            }else
            */
            // {
                float startTime = Time.time;
                while(omoriRb.velocity.x != 0f)
                {
                    yield return null;
                    //Debug.Log(Time.time - startTime);
                    if(Time.time - startTime >= 1.0f)
                    {
                        break;
                    }
                }
                unitychanRb.velocity = Vector2.zero;
                omoriRb.velocity = Vector2.zero;
                unitychanRb.bodyType = RigidbodyType2D.Dynamic;
                unitychanController.enabled = true;
            // }
        }
    }
}