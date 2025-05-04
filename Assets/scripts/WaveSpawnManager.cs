using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;
    private bool waitingForNextWave = false;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
    }

    void Update()
    {
        // รอให้ spawn ครบก่อนเริ่มจับเวลา waveInterval
        if (waveController.IsComplete() && !waitingForNextWave)
        {
            waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            waitingForNextWave = true;
        }

        // ถ้ารอจนถึงเวลา waveInterval แล้ว ค่อยเริ่มเวฟถัดไป
        if (waitingForNextWave && Time.time >= waveEndTime)
        {
            currentWave++;

            if (currentWave >= waveConfigurations.Length)
            {
                if (enableWaveCycling)
                {
                    currentWave = 0;
                    Debug.Log("Wave Cycling: Restarting from Wave 1");
                }
                else
                {
                    Debug.Log("All waves completed!");
                    enabled = false; // ปิด script นี้
                    return;
                }
            }

            waveController.StartWave(waveConfigurations[currentWave]);
            waitingForNextWave = false;
        }
    }
}