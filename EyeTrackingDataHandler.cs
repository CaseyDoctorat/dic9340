using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.IO;

public class EyeTrackingDataHandler : MonoBehaviour
{
   
    string datasetRawBackup = "./dataEyeTrackingRB.csv" + System.DateTime.Now;
    string dataset = "./dataEyeTracking.csv"+System.DateTime.Now;
    private List<TobiiXR_AdvancedTimesyncData> _timesyncData = new List<TobiiXR_AdvancedTimesyncData>();
    TobiiXR_AdvancedEyeTrackingData DataManager = new TobiiXR_AdvancedEyeTrackingData();
    List<string> DatasetUsable = new List<string>();
    void Start()
    {
        var data = TobiiXR.Advanced.LatestData;
        File.Create(dataset);
        StartCoroutine(TimesyncCoroutine());
    }

    private IEnumerator TimesyncCoroutine()
    {
        while (true)
        {
            var handle = TobiiXR.Advanced.StartTimesyncJob();
            while (!handle.IsCompleted)
            {
                yield return new WaitForEndOfFrame();
            }

            var data = TobiiXR.Advanced.FinishTimesyncJob();
            if (data.HasValue)
            {
                _timesyncData.Add(data.Value);
                File.WriteAllText(datasetRawBackup,data.Value.ToString());

                DatasetUsable.Add(DataManager.Left.PupilDiameter.ToString());
                DatasetUsable.Add(DataManager.Left.GazeRay.Origin.ToString());
                DatasetUsable.Add(DataManager.Left.GazeRay.Direction.ToString());
                DatasetUsable.Add(DataManager.Right.PupilDiameter.ToString());
                DatasetUsable.Add(DataManager.Right.GazeRay.Origin.ToString());
                DatasetUsable.Add(DataManager.Right.GazeRay.Direction.ToString());

            }

            for (int x = 0; x < DatasetUsable.Count; x++)
            {
                for (int y = 0; y < DatasetUsable.Count; y++)//1 count = 1 frame
                {
                    File.WriteAllText(dataset, DatasetUsable[y]);

                }
            }

            yield return new WaitForSecondsRealtime(60);
        }

        
    }
}
