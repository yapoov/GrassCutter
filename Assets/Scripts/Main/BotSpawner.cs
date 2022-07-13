using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : Singleton<BotSpawner> {

    public int n = 0;

    public List<Character> characters;

    Bot botPf;

    void Awake() {
        botPf = Resources.Load<Bot>("Main/Bot");
        characters.Add<Character>(A.FOsOT<Character>());
        CreateBots(n);
    }

    void Start() { }

    void Update() { }

    public void CreateBots(int n) {
        Vector3 pos = Vector3.zero, rot = Vector3.zero;
        for (int i = 0; i < n; i++) {
            Create(pos, rot);
        }
    }

    public void UpdatePlace() {
        // sort
        for (int i = 0; i < characters.Count; i++)
            characters[i].UpdatePlace(i + 1);
    }

    public void Create(Vector3 pos, Vector3 rot) {
        Bot bot = Instantiate(botPf, pos, Q.Euler(rot), transform);
        characters.Add(bot);
    }

    public void GetCharacter() { }
}