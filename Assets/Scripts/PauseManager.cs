using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    public void Pause()
    {
        isPaused = true;
        Messenger.Broadcast(GameEvent.LEVEL_PAUSED);
    }

    public void Unpause()
    {
        isPaused = false;
        Messenger.Broadcast(GameEvent.LEVEL_UNPAUSED);
    }
}
