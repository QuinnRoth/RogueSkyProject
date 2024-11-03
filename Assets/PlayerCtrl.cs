using System.Collections;
using UnityEngine;

public class SimpleMoveScript : MonoBehaviour
{

public float NormalSpeed;
public float ExtraSpeed;
public float TurnSpeed;

public float cooldown = 0.5f;

private float nextFire = 0.0f;
public Plane plane;

void Update()
{

    
    transform.Translate(0 * Input.GetAxis("Horizontal") * Time.deltaTime, NormalSpeed * Time.deltaTime, 0f);

    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        NormalSpeed += ExtraSpeed;
    }
    else if (Input.GetKeyUp(KeyCode.LeftShift))
    {
        NormalSpeed -= ExtraSpeed;
    }

    if (Input.GetKey(KeyCode.D))
    {
        transform.Rotate(new Vector3(0, 0, -TurnSpeed));
    }

    if (Input.GetKey(KeyCode.A))
    {
        transform.Rotate(new Vector3(0, 0, TurnSpeed));
    }

    if (Input.GetKey(KeyCode.Space) && Time.time > nextFire){
        nextFire = Time.time + cooldown;
        plane.Fire();
        
    }


}
}