using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 2f;
    public float rotateSpeed = 200;


    public Transform objectViewer;
    public UnityEvent onView;
    public UnityEvent onFinishView;

    private Camera myCam;
    private bool isViewing;
    private bool canFinish;

    private Interactables currentInteractable;
    private Vector3 originPosition;
    private Quaternion originRotation;

    // private AudioManager audioManager;

    private Vector2 mouseDelta;
    private bool leftClickHeld;
    private bool leftClickPressed;
    private bool rightClickPressed;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        //audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
        
        leftClickPressed = false;
        rightClickPressed = false;
    }

    void CheckInteractables()
    {
        if (isViewing)
        {
            if (currentInteractable.item.grabbable && leftClickHeld)
            {
                RotateObject();
            }

            if (canFinish && rightClickPressed)
            {
                FinishView();
            }

            return;
        }

        RaycastHit hit;
        Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            if (interactable != null)
            {
                //UiManager.instance.SetHandCursor(true);

                if (leftClickPressed)
                {
                    if (interactable.isMoving)
                    {
                        return;
                    }
                    onView.Invoke();

                    currentInteractable = interactable;

                    currentInteractable.onInteract.Invoke();

                    if (currentInteractable.item != null && currentInteractable.item.itemName == "Paper")
                    {
                        //audioManager.PlayPaperSound();
                    }

                    if (currentInteractable.item != null && currentInteractable.item.itemName == "Radio")
                    {
                        //audioManager.SetRadioStatic(true);
                    }

                    if (currentInteractable.item != null)
                    {
                        isViewing = true;
                        Interact(currentInteractable.item);

                        if (currentInteractable.item.grabbable)
                        {
                            originPosition = currentInteractable.transform.position;
                            originRotation = currentInteractable.transform.rotation;
                            StartCoroutine(MovingObject(currentInteractable, objectViewer.position));
                        }
                    }


                }
            }
            else
            {
                //UiManager.instance.SetHandCursor(false);
            }
        }
        else
        {
            //UiManager.instance.SetHandCursor(false);
        }

    }

    void Interact(Item item)
    {
        if (item.image)
        {
            //UiManager.instance.SetImage(item.image);
        }
        Invoke("CanFinish", 1f);
    }

    void CanFinish()
    {
        canFinish = true;
        //UiManager.instance.SetBackImage(true);
    }

    void FinishView()
    {
        canFinish = false;
        isViewing = false;
        //UiManager.instance.SetBackImage(false);
        if (currentInteractable.item.grabbable)
        {
            currentInteractable.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentInteractable, originPosition));
        }

        if (currentInteractable.item != null && currentInteractable.item.itemName == "Radio")
        {
            //audioManager.SetRadioStatic(false);
        }

        onFinishView.Invoke();
    }

    IEnumerator MovingObject(Interactables obj, Vector3 position)
    {
        obj.isMoving = true;
        float timer = 0;
        while (timer < 1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5);
            timer += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = position;
        obj.isMoving = false;
    }

    void RotateObject()
    {
        float pegaoX = mouseDelta.x;
        float pegaoY = mouseDelta.y;

        currentInteractable.transform.Rotate(myCam.transform.right, -Mathf.Deg2Rad * pegaoY * rotateSpeed, Space.World);
        currentInteractable.transform.Rotate(myCam.transform.up, -Mathf.Deg2Rad * pegaoX * rotateSpeed, Space.World);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.started)
            leftClickPressed = true;
        if (context.performed || context.started)
            leftClickHeld = true;
        if (context.canceled)
            leftClickHeld = false;
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.started)
            rightClickPressed = true;
    }
}
