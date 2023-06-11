using Assets.Scripts.Obstacles;
using UnityEngine;
using System.Collections;

public class ForwardMovement : MonoBehaviourSingleton<ForwardMovement>
{
    private bool checkLose;
    private Rigidbody rb;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Energy energy;
    [SerializeField] private float energyUsed;
    private float maxSpeed;
    private float endPos;

    protected override void Awake()
    {
        base.Awake();
        checkLose = false;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
    
    private void Start()
    {
        maxSpeed = speed;
        energy.ShowEnergyBar();
        endPos = LocalDB.Instance.db.data.ropeValue;
        rb.AddForce(Vector3.back * speed, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
       // Debug.Log($"Speed: {speed} Energy: {energy.GetEnergy()} EndPos: {endPos} " +
        //    $"Velocity {rb.velocity.z}");
        float progress = transform.position.z / endPos;
        if (progress > .2)
            checkLose = true;
        if (checkLose && rb.velocity.z > -6f ||
            progress > 0.88f ||
            rb.velocity.z > 0f)
        {
            InputManager.Instance.EndGame(progress);
        }
        ChangeEnergy(-energyUsed * Time.fixedDeltaTime);
        ChangeSpeed(-energyUsed * Time.fixedDeltaTime);
        rb.velocity = new Vector3(0, 0, -speed);
    }


    public void OnValueChange(float energyPercentToAdd, float speedPercentToAdd)
    {
        ChangeEnergy(energyPercentToAdd);
        ChangeSpeed(speedPercentToAdd);
    }

    private void ChangeEnergy(float energyPercentToAdd) =>
        energy.SetEnergy(energy.GetEnergy() / 100 * energyPercentToAdd);

    private void ChangeSpeed(float speedPercentToAdd) =>
        speed = maxSpeed * energy.GetEnergy();
}