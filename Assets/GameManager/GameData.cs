using UnityEngine;

public static class GameData 
{

    // Do not drag script into scene!!!
    
    public static int GDMiniGameNumber;
    public static bool GDTaskComplete;

    // static variables can be accessed from any script and is passed over through scenes
    // watch out for naming as they are public variables, I put GD before name so variables wont get confusing

    //GameData.GDMiniGameNumber - to change this number in other script

}
