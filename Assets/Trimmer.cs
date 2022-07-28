using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Trimmer : MonoBehaviour
{
    [Header("Trimmer Stats")]
    public float moveSpeed;
    public float rotSpeed;
    public float sharpness;
    [Header("Parts")]
    public Transform fan;
    public Transform rod;
    public Transform extension;
    [Header("ParticleSystem")]
    public ParticleSystem grassCutMasPS;

    float maxSlowness = 4f;
    // private bool[,] visited = new bool[100, 100];
    float slowness;
    float slowRate = 1f;
    [HideInInspector]
    public bool isInsideShop = false;


    public Transform coinSpawn;

    private int currentTrimmerIdx;

    public event System.Action<Trimmer> onEnterShop;
    public event System.Action<Trimmer> onExitShop;




    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SetTrimmer(Data.PlayerSkinIdx.I());
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;

        if (!audioSource.isPlaying)
            audioSource.Play();

        grassCutMasPS.transform.position = fan.transform.position;


        float hardness = 0;
        RaycastHit hit;
        float targetRot = -rotSpeed * (1 - slowRate * 0.9f) * Time.deltaTime;

        if (Physics.Raycast(fan.position, Vector3.forward, out hit, 10, 1 << 4))
        {

            hardness = hit.collider.Gc<GrassPlane>().hardness;
        }

        if (isInsideShop)
        {
            targetRot = -1;
        }



        fan.rotation = Quaternion.Euler(0, 0, targetRot) * fan.rotation;

        var mainStartColor = grassCutMasPS.startColor;
        mainStartColor.a = 1 - slowRate;
        grassCutMasPS.startColor = mainStartColor;
        slowRate = Mathf.Lerp(slowRate, Mathf.Clamp01(Mathf.Clamp(hardness - sharpness, 0, Mathf.Infinity) / maxSlowness), Time.deltaTime * 5);
    }


    public void UpgradeTrimmer()
    {
        Data.PlayerSkinIdx.Set(Data.PlayerSkinIdx.I() + 1);
        SetTrimmer(Data.PlayerSkinIdx.I());
        // sharpness += 1;

    }

    void SetTrimmer(int idx)
    {

        sharpness = idx;
        for (int i = 0; i < fan.childCount; i++)
        {
            if (i == idx)
                fan.Child(i).gameObject.SetActive(true);
            else
                fan.Child(i).gameObject.SetActive(false);
        }
    }


    public void MoveAt(Vector3 position)
    {
        position.y = Mathf.Clamp(position.y, 1, Mathf.Infinity);
        var targetRotation = Quaternion.LookRotation(-Vector3.forward, transform.position - position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 - Mathf.Pow(slowRate, Time.deltaTime));

        position.z = rod.position.z;
        var targetPos = position + rod.up * 2.189f;
        Vector3 dir = (targetPos - rod.position);
        if (dir.magnitude > 1)
            dir = dir.normalized;

        var displacement = dir * Time.deltaTime * moveSpeed;
        displacement -= displacement * slowRate * 0.9f;
        rod.localPosition += new Vector3(0, rod.InverseTransformDirection(displacement).y, 0);

        var targetScale = extension.localScale;
        targetScale.y = Mathf.Clamp((extension.localPosition - rod.localPosition).y * 5, 0, Mathf.Infinity);
        extension.localScale = targetScale;

    }

    public Vector3 GetFanPos()
    {
        return fan.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            var shop = other.GetComponentInParent<UpgradeShop>();
            isInsideShop = true;
            onEnterShop?.Invoke(this);
        }

        if (other.CompareTag("Coin"))
        {
            other.GetComponent<Collider>().enabled = false;
            Canvas canvas = other.GetComponentInChildren<Canvas>();
            // canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var coin = canvas.transform.Child(0);
            // coin.localScale *= 0.4f;

            bool isComplete = false;
            coin.transform.DOJump(coin.transform.position + Vector3.forward * -1f, 1f, 1, 0.9f).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                coin.DOMove(coinSpawn.position, 0.5f)
                    .SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        Data.Coin.Set(Data.Coin.I() + 1);
                        A.CC.HudCoin(Data.Coin.I());
                        Destroy(other.gameObject);
                    }).WaitForCompletion(isComplete);
            });

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            isInsideShop = false;
            onExitShop?.Invoke(this);
        }
    }
}
