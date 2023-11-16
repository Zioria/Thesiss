using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlowMotionAbility : AbilityScriptable
{

    public override void Activate(TimeManager time)
    {
        time.StopTime();
    }

    public override void BeginCooldown(TimeManager time)
    {
        time.ContinueTime();
    }
}
