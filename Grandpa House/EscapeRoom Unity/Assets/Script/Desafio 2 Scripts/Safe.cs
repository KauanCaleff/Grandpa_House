using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Safe : MonoBehaviour
{
    public string input = "";
    public string code = "1212";
    public GameObject obj;
    public int maxString = 4;
    public Text uiText;

    public GameObject button1, button2, button3, button4, button5;
    public GameObject button6, button7, button8, button9, button0;

    public Transform handle;
    public Transform handleTarget;
    public Transform door;
    public Transform doorTarget;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PressButton("1", button1, De1());
        if (Input.GetKeyDown(KeyCode.Alpha2)) PressButton("2", button2, De2());
        if (Input.GetKeyDown(KeyCode.Alpha3)) PressButton("3", button3, De3());
        if (Input.GetKeyDown(KeyCode.Alpha4)) PressButton("4", button4, De4());
        if (Input.GetKeyDown(KeyCode.Alpha5)) PressButton("5", button5, De5());
        if (Input.GetKeyDown(KeyCode.Alpha6)) PressButton("6", button6, De6());
        if (Input.GetKeyDown(KeyCode.Alpha7)) PressButton("7", button7, De7());
        if (Input.GetKeyDown(KeyCode.Alpha8)) PressButton("8", button8, De8());
        if (Input.GetKeyDown(KeyCode.Alpha9)) PressButton("9", button9, De9());
        if (Input.GetKeyDown(KeyCode.Alpha0)) PressButton("0", button0, De0());
    }

    void FixedUpdate()
    {
        if (input == code)
        {
            if (obj)
                obj.SetActive(true);
            uiText.color = Color.green;
            Open();
        }

        if (input.Length > maxString)
        {
            input = "";
        }

        uiText.text = input;
    }

    void PressButton(string digit, GameObject button, IEnumerator resetCoroutine)
    {
        input += digit;
        
        button.GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(resetCoroutine);
    }

    IEnumerator De1() { yield return new WaitForSeconds(0.1f); button1.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De2() { yield return new WaitForSeconds(0.1f); button2.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De3() { yield return new WaitForSeconds(0.1f); button3.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De4() { yield return new WaitForSeconds(0.1f); button4.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De5() { yield return new WaitForSeconds(0.1f); button5.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De6() { yield return new WaitForSeconds(0.1f); button6.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De7() { yield return new WaitForSeconds(0.1f); button7.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De8() { yield return new WaitForSeconds(0.1f); button8.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De9() { yield return new WaitForSeconds(0.1f); button9.GetComponent<Renderer>().material.color = Color.white; }
    IEnumerator De0() { yield return new WaitForSeconds(0.1f); button0.GetComponent<Renderer>().material.color = Color.white; }

    void Open()
    {
        handle.rotation = Quaternion.Euler(handle.rotation.x, handle.rotation.y, handleTarget.rotation.eulerAngles.z);
        StartCoroutine(DoorOpen());
    }

    IEnumerator DoorOpen()
    {
        yield return new WaitForSeconds(1f);
        door.rotation = Quaternion.Euler(door.rotation.eulerAngles.x, doorTarget.rotation.eulerAngles.y, door.rotation.eulerAngles.z);
        Destroy(uiText.gameObject);
    }
}
