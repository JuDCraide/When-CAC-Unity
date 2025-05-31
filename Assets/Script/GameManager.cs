using UnityEngine;

// This script manages the game state, including the game instance, seed, and error messages
// It is used to maintain the game's data across different scenes and provide a central point for game management
public class GameManager : MonoBehaviour {
    public static bool justStarted = true;
    public static string seed = null;// = "eyJsYXRlc3RfZXAiOjE3MzYsInN0YXJ0X3RpbWVzdGFtcCI6MTc0NjMxODA0MTQzM30=";
    public static Game game = null;
    public static string error = null;
}