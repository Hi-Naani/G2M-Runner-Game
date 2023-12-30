using UnityEngine;

public class Gold_Coin : MonoBehaviour
{
    public ConstantForce gCRotation;
    Vector3 rotate = new Vector3(0, 10, 0);
    void Start()
    {
        gCRotation.GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gCRotation.torque = rotate;
    }
}
