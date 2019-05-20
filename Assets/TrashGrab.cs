using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class TrashGrab : MonoBehaviour
{
    public static int score=0;
    public static int limit = 16;
    public static int points = 0;
    public GameObject Hands;
    public AudioSource TrashManEffects;
    public AudioClip grab;
    public AudioClip throws;
    public Text endText;
    GameObject item;
    bool inHands = false;
    bool isInputEnabled = false;
    Ray ray;
    RaycastHit hit;
    Vector3 itemPos;
    // Start is called before the first frame update
    void Start()
    {
        endText.text = "TRASH MAN";
        StartCoroutine(Intro(3));
    }

    IEnumerator Intro(float time)
    {
        yield return new WaitForSeconds(time);
        item = GameObject.Find("Canvas");
        item.GetComponent<Tempo>().enabled = true;
        item = null;
        endText.text = "";
        isInputEnabled = true;
        score = 0;
        points = 0;

    }

   void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Debug.Log(mouse);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isInputEnabled)
        {
            Vector3 center = new Vector3(XRSettings.eyeTextureWidth/2, XRSettings.eyeTextureHeight/2, 0);
            ray = Camera.main.ScreenPointToRay(center);
            if (Physics.Raycast(ray, out hit))
            {
                if (item == null)
                {
                    item = GameObject.Find(hit.collider.name);
                    itemPos = item.transform.position;
                    if (!inHands)
                    {
                        if (item.gameObject.tag == "paper" || item.gameObject.tag == "banana" || item.gameObject.tag == "bucket" || item.gameObject.tag == "bottle")
                        {
                            TrashManEffects.clip = grab;
                            TrashManEffects.Play();
                            item.GetComponent<Rigidbody>().useGravity = false;
                            item.transform.SetParent(Hands.transform);
                            item.transform.localPosition = new Vector3(0f, -.5f, 0f);
                            inHands = true;
                        }
                        else
                        {
                            item = null;
                        }
                    }
                }
                else
                {
                    if (inHands)
                    {

                        Rigidbody rb = item.GetComponent<Rigidbody>();
                        GameObject camera = GameObject.Find("Main Camera");
                        rb.useGravity = true;

                        rb.AddForce(Hands.transform.forward * 700);
                        TrashManEffects.clip = throws;
                        TrashManEffects.Play();
                        item.transform.SetParent(null);
                        inHands = false;
                        item = null;
                    }
                }
            }
        }
        
    }
}
