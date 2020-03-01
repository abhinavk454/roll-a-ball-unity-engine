using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public float Speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        winText.text="";
    }
    void FixedUpdate()//used on physics or rigid body update
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");
        Vector3 movment=new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movment*Speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick up"));
        {
            other.gameObject.SetActive(false);
            count=count+1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text="Score : "+count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
