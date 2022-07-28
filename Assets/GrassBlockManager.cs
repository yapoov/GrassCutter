using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GrassBlockManager : Singleton<GrassBlockManager>
{
    public GameObject grassBlockPf;
    public int spawnNum;
    public Transform startTf;
    public Gradient hardnessGradient;

    public Transform playerTf;
    List<GameObject> spawnedBlocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        Vector3 nextSpawnPos = startTf.position;
        for (int i = 0; i < spawnNum; i++)
        {
            var spawnedBlock = Instantiate(grassBlockPf, nextSpawnPos, Quaternion.identity);
            spawnedBlocks.Add(spawnedBlock);
            spawnedBlock.Gcic<GrassPlane>().coinSpawnNum = (i + 1) * 5;
            spawnedBlock.Gcic<GrassPlane>().id = i;
            spawnedBlock.GetComponentInChildren<GrassPlane>().SetData(new GrassPlaneData { color = hardnessGradient.Evaluate((float)i / spawnNum), hardness = i });
            nextSpawnPos += Vector3.right * 10 * grassBlockPf.transform.localScale.x;

        }
        Vector3 offset = playerTf.position - startTf.position;
        foreach (var item in spawnedBlocks)
        {
            item.SetActive(false);
        }

        A.GC.OnStarted += () =>
        {

            if (GameController.Level - 1 < spawnedBlocks.Count)
                playerTf.position = spawnedBlocks[GameController.Level - 1].transform.position + offset;
        };


    }

    int lastIndex = 0;
    // Update is called once per frame
    void Update()
    {
        int index = Mathf.RoundToInt((Camera.main.transform.position.x - startTf.position.x) / (10 * grassBlockPf.transform.localScale.x) + 0.5f);
        if (index < 0 || index >= spawnedBlocks.Count) return;
        spawnedBlocks.ForEach((gameObj) => gameObj.SetActive(false));
        spawnedBlocks[index].SetActive(true);

        if (index > 0)
            spawnedBlocks[index - 1].SetActive(true);

    }
}
