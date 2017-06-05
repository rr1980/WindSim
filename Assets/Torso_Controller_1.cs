using UnityEngine;
public class Torso_Controller_1 : MonoBehaviour
{
    public Bot_13 bot;
    public Rigidbody rb;

    void Start()
    {
        bot = transform.parent.GetComponent<Bot_13>();
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(bot.IgnoreLayer, bot.IgnoreLayer);
    }

    private void Update()
    {
        //transform.root.position = transform.position+transform.localPosition;
    }
}
