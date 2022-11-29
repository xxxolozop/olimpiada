using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copter : MonoBehaviour
{
    private float pitch; //тангаж
    private float roll; //крен
    private float yaw; //рыскание
    public float throttle = 23; //газ

    public float targetPitch;
    public float targetRoll;
    public float targetYaw;

    private PID pitchPID = new PID(50,0,10);
    private PID rollPID = new PID(50,0,10);
    private PID yawPID = new PID(150,0,50);

    void readRotation()
    {
        pitch = GameObject.Find("form").transform.localEulerAngles.z;
        yaw = GameObject.Find("form").transform.localEulerAngles.y;
        roll = GameObject.Find("form").transform.localEulerAngles.x;
    }
    float normal(float In)
    { 
        if (In >= 180)
            In -= 360f;
        return In;
    }
    void stabilize()
    {
        pitch = normal(pitch);
        roll = normal(roll);
        yaw = normal(yaw);
        
        if (targetYaw > 180) targetYaw -= 360f;
        if (targetYaw < -180) targetYaw += 360f;

        float dPitch = targetPitch - pitch;
        float dRoll = targetRoll - roll;
        float dYaw = targetYaw - yaw;

        if (dYaw > 180) dYaw -= 360f;
        if (dYaw < -180) dYaw += 360f;

        float motor1power = throttle;
        float motor2power = throttle;
        float motor3power = throttle;
        float motor4power = throttle;

        float powerLimit = throttle > 15 ? 15 : throttle; //ограничение мощности мотора

        float pitchForce = pitchPID.calc(0, dPitch/180f);
        pitchForce = pitchForce > powerLimit ? powerLimit : pitchForce;
        pitchForce = pitchForce < -powerLimit ? -powerLimit : pitchForce;
        motor1power += pitchForce;
        motor2power += pitchForce;
        motor3power += -pitchForce;
        motor4power += -pitchForce;

        float rollForce = -rollPID.calc(0,dRoll/180f);
        rollForce = rollForce > powerLimit ? powerLimit : rollForce;
        rollForce = rollForce < -powerLimit ? -powerLimit : rollForce;
        motor1power += rollForce;
        motor2power += -rollForce;
        motor3power += -rollForce;
        motor4power += rollForce;

        float yawForce = -yawPID.calc(0,dYaw/180f);
        yawForce = yawForce > powerLimit ? powerLimit : yawForce;
        yawForce = yawForce < -powerLimit ? -powerLimit : yawForce;
        motor1power += yawForce;
        motor2power += -yawForce;
        motor3power += yawForce;
        motor4power += -yawForce;

        GameObject.Find("prop1").GetComponent<motor>().power = motor1power;
        GameObject.Find("prop2").GetComponent<motor>().power = motor2power;
        GameObject.Find("prop3").GetComponent<motor>().power = motor3power;
        GameObject.Find("prop4").GetComponent<motor>().power = motor4power;
    }
    void FixedUpdate()
    {
        readRotation();
        stabilize();
    }
}
public class PID
{
    private float P;
    private float I;
    private float D;

    private float prevErr;
    private float sumErr;

    public PID(float P, float I, float D)
    {
        this.P = P;
        this.I = I;
        this.D = D;
    }
    public float calc(float current, float target)
    {
        float dt = Time.fixedDeltaTime;
        float err = target - current;
        this.sumErr += err;
        float force = this.P*err + this.I*this.sumErr*dt + this.D*(err-this.prevErr)/dt;
        this.prevErr = err;
        return force;
    }
}
