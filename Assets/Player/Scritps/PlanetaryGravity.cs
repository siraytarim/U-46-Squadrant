using UnityEngine;

public class PlanetaryGravity : MonoBehaviour
{
    public Transform planet;
    public bool alignToPlanet = true;

    float gravityConstant = 9.8f;
    Rigidbody rigidibody;
    public Vector3 toCenter;
    public Vector3 toCenterNormalized;


    void Start()
    {
        rigidibody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        toCenter = planet.position - transform.position;
        //toCenter.Normalize();
        toCenterNormalized = toCenter.normalized;


        rigidibody.AddForce(toCenterNormalized * gravityConstant, ForceMode.Acceleration);

        if (alignToPlanet)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, -toCenterNormalized);
            q = q * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
    }
}
