using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BunnyChangeController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject currentBunny;
    public GameObject bottomRightBunny;
    public GameObject bunnyContainer;
    //public UIHandler uiHandler;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out hit))
        {
            if(Mouse.current.leftButton.isPressed)
            {
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Bunny"))
                    {
                        currentBunny = hit.collider.gameObject;
                        GameObject BottomRightBunnyClone = Instantiate(bottomRightBunny, 
                            new Vector3(currentBunny.transform.position.x, currentBunny.transform.position.y -0.49999f, currentBunny.transform.position.z - 0.3f), 
                            Quaternion.identity) as GameObject;
                        BottomRightBunnyClone.transform.parent = bunnyContainer.transform;
                        BottomRightBunnyClone.name = "BottomRightBunny";
                        Destroy(currentBunny);
                        //print(currentBunny);
                    }
                }
            }
        }

        //Debug.Log(uiHandler.currentChoiceState);
    }
}
