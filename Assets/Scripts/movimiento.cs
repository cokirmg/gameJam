using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    public float jumpforce = 15f;
    public bool canJump;
    private Animator anim;
    
    [SerializeField]
    private Transform grabPoint;
    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 5f;
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(transform.position, Vector3.down);
        //RaycastHit hit;
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.transform.position , -Vector3.up);
        Debug.DrawRay(transform.position, Vector3.down * 4f, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("rayo");
            
               if(hit.distance < 4f)
                {
                    Debug.Log("rayo4f");
                    canJump = true;
                }
                else
                {
                    Debug.Log("rayo>4f");
                    canJump = false;
                }

            



        }
        
        

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right);
        Debug.DrawRay(transform.position, Vector3.right * 4f, Color.green);
        if (hitInfo.collider !=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKey(KeyCode.E) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if(Input.GetKey(KeyCode.E)&& grabbedObject != null)
                {
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.transform.SetParent(null);
                    grabbedObject = null;
                }
        }


        if (Input.GetKey(KeyCode.A))
        {

            transform.position -= new Vector3(speed, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetBool("andado", true);
            
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetBool("andado", true);
            
        }
        else
        {
            anim.SetBool("andado", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            

        }


        
        
    }

    
}
