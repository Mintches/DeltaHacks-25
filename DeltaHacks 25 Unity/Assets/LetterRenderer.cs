using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterRenderer : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', '!', '?', ':', ';', ',', '-', '_', '\'', ' '};
    Dictionary<char, Sprite> mp;

    // Start is called before the first frame update
    void Start() {
        mp = new Dictionary<char, Sprite>();
        for (int i = 0; i < letters.Length; i++) {
            mp.Add(letters[i], sprites[i]);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    public void setLetter(char x) {
        mp = new Dictionary<char, Sprite>();
        for (int i = 0; i < letters.Length; i++) {
            mp.Add(letters[i], sprites[i]);
        }
        spriteRenderer.sprite = mp[x];
        Debug.Log(x);
    }
}
