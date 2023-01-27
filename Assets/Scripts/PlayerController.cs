using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runningSpeed;
    float touchxDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchxDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchxDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchxDelta = 0;
        }
        newX = transform.position.x + xSpeed * touchxDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);


        Vector3 newPossition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPossition;
    }
}
