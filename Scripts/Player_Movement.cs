using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public AudioSource eatingVeg;
    public float forwardSpeed;
    public AudioSource backMusic;


    private Game_Manager gameManager;

    private float firtsTouchX;
    private float firtsTouchY;
    
 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Game_Manager>();
        
    }



    // Update is called once per frame
    private void Update()
    {
        if (gameManager.currentGameState != GameState.Start)
        {
            return;

        }

        //ileri gönder

        Vector3 moveVector = new Vector3(-1 * forwardSpeed * Time.deltaTime, 0, 0);
        float diff = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firtsTouchX = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0))
        {
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX - firtsTouchX;
            moveVector += new Vector3(0, 0, diff * Time.deltaTime / 10);
            firtsTouchX = lastTouchX;

        }

        transform.position += moveVector;

        //sağ sol sınırı

        Vector3 right_go = new Vector3(transform.position.x, transform.position.y, 2.25f);
        Vector3 left_go = new Vector3(transform.position.x, transform.position.y, 0.90f);



        //yukarı zıplama

        Vector3 upVector = new Vector3(-1 * forwardSpeed * Time.deltaTime, 0, 0);
        float diffY = 0.4f;

        if (Input.GetMouseButtonDown(0))
        {
            firtsTouchY = Input.mousePosition.y;
            
            
        }

        else if (Input.GetMouseButton(0))
        {
            float lastTouchY = Input.mousePosition.y;
            diffY = lastTouchY - firtsTouchY;
            upVector += new Vector3(0, diffY * Time.deltaTime / 10, 0);
            firtsTouchY = lastTouchY;


        }
        transform.position += upVector;


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Veg")
        {
            Destroy(other.gameObject);
            eatingVeg.Play();
            transform.localScale = transform.localScale + new Vector3(0.05f, 0.05f, 0.05f);
        }

        else if (other.gameObject.tag == "Finish")
        {
            gameManager.EndGame();
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }

        if (other.gameObject.tag == "FastF")
        {

            gameManager.currentGameState = GameState.End;

        }

      
    }

   
}


