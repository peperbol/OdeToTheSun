using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour {
    public float ttl;
    public static void PlaySound(AudioClip clip, AudioPlay prefab) {
        AudioPlay o = Instantiate(prefab);
        o.GetComponent<AudioSource>().PlayOneShot(clip);
    }
    void update() {
        ttl -= Time.deltaTime;
        if (ttl <=0) Destroy(gameObject);
    }
}
