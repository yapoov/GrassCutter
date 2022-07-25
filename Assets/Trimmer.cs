using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float maxSlowness = 2f;
    // private bool[,] visited = new bool[100, 100];
    float slowness;
    float slowRate = 1f;
    bool isInsideShop = false;


    public RectTransform coinImageRect;

    private int currentTrimmerIdx;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!A.IsPlaying) return;


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
        fan.Child(currentTrimmerIdx).gameObject.SetActive(false);
        currentTrimmerIdx += 1;
        if (currentTrimmerIdx < fan.childCount)
            fan.Child(currentTrimmerIdx).gameObject.SetActive(true);
        sharpness += 1;
    }


    public void MoveAt(Vector3 position)
    {
        // fan.position = position;
        var targetRotation = Quaternion.LookRotation(-Vector3.forward, transform.position - position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 - Mathf.Pow(slowRate, Time.deltaTime));
        // fan.position = position;
        // rod.up = fan.position -
        position.z = rod.position.z;
        var targetPos = position + rod.up * 2.189f;
        Vector3 dir = (targetPos - rod.position);
        if (dir.magnitude > 1)
            dir = dir.normalized;

        var displacement = dir * Time.deltaTime * moveSpeed;
        displacement -= displacement * slowRate * 0.9f;
        rod.localPosition += new Vector3(0, rod.InverseTransformDirection(displacement).y, 0);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-Vector3.forward, transform.position - position), Time.deltaTime * 5);
        // var fanOffset = rod.position - fan.position;
        // var targetLoc = rod.localPosition;
        // float sign = Mathf.Sign(rod.InverseTransformPoint(position).y);
        // targetLoc.y = sign * rod.InverseTransformPoint(position).magnitude * 2f;

        // rod.localPosition = Vector3.Lerp(rod.localPosition, targetLoc, Time.deltaTime * 10);

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

            //refrite system;
            StartCoroutine(cor());
            IEnumerator cor()
            {
                while (isInsideShop && Data.Coin.I() > 1)
                {
                    yield return A.Wfs025;
                    Data.Coin.Set(Data.Coin.I() - 1);
                    A.CC.HudCoin(Data.Coin.I());
                    shop.SetPrice(shop.currentPrice - 1);

                    if (shop.currentPrice == 0)
                    {
                        UpgradeTrimmer();
                        shop.currentPrice = 10;
                    }
                }
            }
        }

        if (other.CompareTag("Coin"))
        {
            other.GetComponent<Collider>().enabled = false;
            Canvas canvas = other.GetComponentInChildren<Canvas>();
            StartCoroutine(cor());
            IEnumerator cor()
            {
                yield return new WaitForSeconds(0.9f);
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                float duration = 1f;
                Transform rect = canvas.transform.Child(0);
                Vector2 start = rect.transform.position;
                Vector2 target = coinImageRect.transform.position;
                rect.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                rect.localScale = Vector3.one * 0.5f;
                for (float t = 0; t < duration; t += Time.deltaTime)
                {
                    rect.transform.position = Vector2.Lerp(start, target, AnimationCurve.EaseInOut(0, 0, 1, 1).Evaluate(t / duration));
                    yield return null;
                }

                Data.Coin.Set(Data.Coin.I() + 1);
                // print(Data.Coin.I)
                A.CC.HudCoin(Data.Coin.I());
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            isInsideShop = false;
        }
    }
}
