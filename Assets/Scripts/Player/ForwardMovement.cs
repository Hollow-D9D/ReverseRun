using Assets.Scripts.Obstacles;
using UnityEngine;
using System.Collections;

public class ForwardMovement : MonoBehaviourSingleton<ForwardMovement>
{

    private Rigidbody rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Energy energy;
    [SerializeField] private float energyUsed;

    private float endPos = -240;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }
    private void Start() => energy.ShowEnergyBar();

    void FixedUpdate()
    {
        if (rb.velocity.z > -10)
            rb.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
        float progress = transform.position.z / endPos;
        //        Debug.Log(Screen.currentResolution.height);
        if (progress > 0.88f)
            GetComponent<ThrowPlayer>().End(progress);
        if (rb.velocity.z > 0f)
        {
            GetComponent<ThrowPlayer>().End(progress);
        }
        //Debug.Log(rb.velocity.z);
        //Debug.Log(progress);
        ChangeEnergy(-energyUsed * Time.fixedDeltaTime);
        CalculateSpeed(energyUsed * Time.fixedDeltaTime);
    }


    public void OnValueChange(float energyPercentToAdd, float speedPercentToAdd)
    {
        ChangeEnergy(energyPercentToAdd);
        ChangeSpeed(speedPercentToAdd);
    }

    private void ChangeEnergy(float energyPercentToAdd) =>
        energy.SetEnergy(energy.GetEnergy() / 100 * energyPercentToAdd);

    private void ChangeSpeed(float speedPercentToAdd) =>
        speed += speed / 100 * speedPercentToAdd * energy.GetEnergy();

    private void CalculateSpeed(float discountedEnergy)
    {
        speed -= speed / 100 * discountedEnergy;
    }

}