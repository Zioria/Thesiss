using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowMotionAbility : AbilityScriptable
{
    private GameObject _tempObject;

    public override void Activate()
    {

        if (_tempObject == null)
        {
            _tempObject = GameObject.FindGameObjectWithTag("TimeManager");
        }
        _tempObject.GetComponent<TimeManager>().StopTime();
    }

    public override void BeginCooldown()
    {
        if (_tempObject == null)
        {
            _tempObject = GameObject.FindGameObjectWithTag("TimeManager");
        }
        _tempObject.GetComponent<TimeManager>().ContinueTime();
    }
}
