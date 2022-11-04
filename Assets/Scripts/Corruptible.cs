using UnityEngine;

public interface ICorruptible
{
    uint CorruptionLevel { get; set; }
    uint CorruptionSpeed { get; set; }
    void Corrupt();
    bool IsCorrupt() => CorruptionLevel >= 100;
}
public class Corruptible : MonoBehaviour, ICorruptible
{

    public float timeElapsedAfterLastCorrupt = 0f;
    public uint CorruptionLevel { get; set; } = 0;
    public uint CorruptionSpeed { get; set; } = 1;
    public ICorruptible corruptible { get; set; }

    public GameObject auraPrefab;
    public bool hasAura = false;

    public void Corrupt()
    {
        bool previousIsCorrupt = corruptible.IsCorrupt();
        if (!corruptible.IsCorrupt())
        {
            timeElapsedAfterLastCorrupt += Time.deltaTime;
            if (timeElapsedAfterLastCorrupt >= 0.01f)
            {
                timeElapsedAfterLastCorrupt = 0;
                CorruptionLevel += CorruptionSpeed;

                var corruptColor = (1.0f / 100.0f) * CorruptionLevel;
                GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(corruptColor, 0, 0));
            }
        }

        if (corruptible.IsCorrupt() && !hasAura)
        {
            Debug.Log("Corrupted!");
            Instantiate(auraPrefab, transform);
            hasAura = true;
        }

        if (previousIsCorrupt != corruptible.IsCorrupt())
        {
            CorruptionCounter.AddToCount();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        corruptible = this;
    }

    // Update is called once per frame
    //private float timeElapsed = 0;
    //void Update()
    //{
    //    timeElapsed += Time.deltaTime;
    //    if (timeElapsed >= 0.01f)
    //    {

    //    }
    //}
}
