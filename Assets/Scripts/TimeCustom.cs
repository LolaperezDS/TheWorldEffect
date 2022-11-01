using UnityEngine;

public static class TimeCustom
{
    private static float deltatime = Time.deltaTime;
    public static float deltaTime { get { return deltatime; } }

    private static float fixeddeltatime = Time.fixedDeltaTime;
    public static float fixedDeltaTime { get { return fixeddeltatime; } }


    public static float multiplayer;


    public static void SetNewMultiplayerOnTime(float multiplayer)
    {
        TimeCustom.multiplayer = multiplayer;
        deltatime = Time.deltaTime * multiplayer;
        fixeddeltatime = Time.fixedDeltaTime * multiplayer;
    }
}
