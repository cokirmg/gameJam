using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    public float jumpforce = 20f;
    public bool canJump;
    private Animator anim;
    public GameObject camara;

    [SerializeField]
    private Transform grabPoint;
    private Transform grabPointPara;
    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    public GameObject spawn;
    private int layerIndex;
    public bool liana;

    private GameObject lianaObj;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 8f;
        layerIndex = LayerMask.NameToLayer("Objects");

    }

    // Update is called once per frame
    void Update()
    {
        
        //Ray ray = new Ray(transform.position, Vector3.down);
        //RaycastHit hit;
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.transform.position , -Vector3.up);
        Debug.DrawRay(rayPoint.transform.position, Vector3.down * 2f, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("rayo");
            
               if(hit.distance < 2f)
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
        
        

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.transform.position, Vector3.right);
        Debug.DrawRay(rayPoint.transform.position, Vector3.right , Color.green);
        if (hitInfo.collider !=null )
        {
            if (hitInfo.distance < 1f)
            {
                Debug.Log("Detecto algo 4f");
                if (Input.GetKeyDown(KeyCode.E) && grabbedObject == null)
                {
                    


                            if(grabbedObject.transform.CompareTag("paracaidas"))
                                {
                                    Debug.Log("presiono e = null");
                                    grabbedObject = hitInfo.collider.gameObject;
                                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                                    grabbedObject.transform.position = grabPointPara.position;
                                    grabbedObject.transform.SetParent(transform);
                                    rb.gravityScale = 1f;
                                }
                            else if(grabbedObject.transform.CompareTag("canCatch"))
                                {
                                        Debug.Log("presiono e = null");
                                        grabbedObject = hitInfo.collider.gameObject;
                                        grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                                        grabbedObject.transform.position = grabPoint.position;
                                        grabbedObject.transform.SetParent(transform);
                                        rb.gravityScale = 1f;
                                }
                }
                else if (Input.GetKeyDown(KeyCode.E) && grabbedObject != null)
                {
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.transform.SetParent(null);
                    grabbedObject = null;
                    rb.gravityScale = 4f;
                }
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
            anim.SetBool("salto", true);
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            

        }
        else
        {
            anim.SetBool("salto", false);
        }

        if (Input.GetKeyDown(KeyCode.S) && liana)
        {

           transform.SetParent(lianaObj.transform);
            rb.isKinematic = true;
            speed = 0f;
            liana = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !liana)
        {

            transform.SetParent(null);
            rb.isKinematic = false;
            speed = 8f;
            lianaObj = null;

        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "faster")
        {
            speed = 14f;
        }
        else
        {
            speed = 8f;
        }

        if (collision.gameObject.tag == "liana")
        {
            lianaObj = collision.gameObject;
            liana = true;
            
        }
        else
        {
            liana = false;
        }

        if (collision.gameObject.tag == "enemigo")
        {
            transform.position = spawn.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("trigger");
        if (col.transform.CompareTag("vientoTOR"))
        {
            Debug.Log("if");
            transform.position += new Vector3(3f, 0f, 0f) * Time.deltaTime;
        }

        if (col.gameObject.CompareTag ( "vientoTOL"))
        {
            transform.position += new Vector3(-3f, 0, 0) * Time.deltaTime;
        }
    }
    
}
