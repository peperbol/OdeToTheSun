using UnityEngine;
using System.Collections;

public  class GameProperties :MonoBehaviour
{
    public const int NUMBER_OF_COLORS = 8;
    private static float spawnRadius ;
	public static float SpawnRadius {get{return spawnRadius;}}
	private static float noteDuration = 3 ;
	public static float NoteDuration {get{return noteDuration;}}
	public static float NoteVelocity {get{return SpawnRadius/ NoteDuration;}}
	//private static float sunRadius = 
	void Awake(){
        spawnRadius = Camera.main.orthographicSize * 0.8f;
    }
}
