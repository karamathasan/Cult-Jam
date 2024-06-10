using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSound 
{
    Vector2 position;
    float range;
    //float sourceVolume;
    public WorldSound(Vector2 position, float range)
    {
        this.position = position;
        this.range = range;
        UpdateListeners(this);
    }

    public Vector2 getPosition()
    {
        return position;
    }

    public float getRange()
    {
        return range;
    }

    public static void UpdateListeners(WorldSound sound)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(sound.getPosition(), sound.getRange());
        foreach(Collider2D col in cols)
        {
            if(col.TryGetComponent(out WorldSoundListener listener))
            {
                listener.Respond(sound);
            }
        }
    }
}
