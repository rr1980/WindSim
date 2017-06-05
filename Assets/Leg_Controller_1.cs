using UnityEngine;

public class Leg_Controller_1 : MonoBehaviour
{
    public ForceMode ForceMode;
    public float ForceFactor;
    public float Speed;
    public HingeJoint hj;
    public Rigidbody rb;
    public Bot_13 bot;

    public float Force;

    public bool debug = false;

    private void Start()
    {
        bot = transform.parent.GetComponent<Bot_13>();
        hj = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(bot.IgnoreLayer, bot.IgnoreLayer);
    }

    private void Update()
    {
        if ((hj.angle > 80 && Force > 0) || (hj.angle > 80 && Force < 0))
        {
            //Debug.Log("hj.angle > 90");
            //Debug.Log(transform.rotation.z);
            //Debug.Log(Force);
            //Debug.Log("------------------");
            Speed = 0;
            Force = 0;
        }

        //if (debug)
        //{
        //}

        Speed += Force * ForceFactor;
        Speed = Mathf.Clamp(Speed, -40, 40);
        rb.AddRelativeTorque(new Vector3(0, 0, Speed), ForceMode);

        //rb.angularVelocity

        //GetLegAngle();
    }

    public float GetLegAngle()
    {
        //float rad = transform.rotation.z * Mathf.Deg2Rad;
        //Debug.Log(rad);
        return transform.rotation.z;
    }

    public void Hook()
    {
        //rb.AddTorque(Force, ForceMode);
        //Speed *= -1;
        //var motor = hj.motor;
        //motor.targetVelocity = Speed;
        //hj.motor = motor;
    }
}