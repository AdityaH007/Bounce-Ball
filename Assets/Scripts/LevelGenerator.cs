using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject surfacePrefab;
    public GameObject pillarPrefab;
    public GameObject coinPrefab;

    public int numberOfPillars = 4; // Adjust the number of pillars per set
    public float surfaceLength = 100f; // Adjust the length of the surface as needed
    public float spawnInterval = 5f; // Adjust the interval between surface generations
    public float initialZPos = 27.2f; // Adjust the initial z-position

    private float surfaceHeight = 1.4f; // Adjust as needed
    private float xOffset = 5.2f; // Adjust as needed
    private float pillarXOffset = -1.3f; // Adjust the x-position of the pillars
    public float minGapBetweenPillarSets = 12f; // Minimum gap between the two sets of pillars

    private void Start()
    {
        StartCoroutine(GenerateSurfaces());
    }

    IEnumerator GenerateSurfaces()
    {
        while (true)
        {
            GenerateSurface(new Vector3(xOffset, surfaceHeight, initialZPos));
            initialZPos += surfaceLength;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void GenerateSurface(Vector3 position)
    {
        // Instantiate the surface
        GameObject surface = Instantiate(surfacePrefab, position, Quaternion.identity);
        // Adjust the scale of the surface to set its length
        surface.transform.localScale = new Vector3(surface.transform.localScale.x, surface.transform.localScale.y, surfaceLength);

        // Generate the first set of pillars on the surface with randomized heights
        GeneratePillars(surface.transform.position + Vector3.up * (surfaceHeight + Random.Range(1f, 5f)), surfaceLength, numberOfPillars);

        // Generate the second set of pillars on top with randomized heights and a random gap
        GeneratePillars(surface.transform.position + Vector3.up * (surfaceHeight + Random.Range(1f, 5f) + minGapBetweenPillarSets), surfaceLength, numberOfPillars);
    }

    private void GeneratePillars(Vector3 position, float surfaceLength, int numberOfPillars)
    {
        float gapBetweenPillars = surfaceLength / (numberOfPillars - 1);

        for (int i = 0; i < numberOfPillars; i++)
        {
            // Instantiate the left pillar with randomized height
            GameObject leftPillar = Instantiate(pillarPrefab, position + new Vector3(pillarXOffset, 0, -surfaceLength / 2f + i * gapBetweenPillars), Quaternion.identity);
            leftPillar.transform.localScale = new Vector3(leftPillar.transform.localScale.x, Random.Range(1f, 5f), leftPillar.transform.localScale.z);

            // Instantiate the coin on top of each left pillar
            Vector3 coinPositionLeft = leftPillar.transform.position + Vector3.up * leftPillar.transform.localScale.y;
            Instantiate(coinPrefab, coinPositionLeft, Quaternion.identity);

            // Instantiate the right pillar with randomized height
            GameObject rightPillar = Instantiate(pillarPrefab, position + new Vector3(pillarXOffset, 0, -surfaceLength / 4f + i * gapBetweenPillars), Quaternion.identity);
            rightPillar.transform.localScale = new Vector3(rightPillar.transform.localScale.x, Random.Range(1f, 5f), rightPillar.transform.localScale.z);

            // Instantiate the coin on top of each right pillar
            Vector3 coinPositionRight = rightPillar.transform.position + Vector3.up * rightPillar.transform.localScale.y;
            Instantiate(coinPrefab, coinPositionRight, Quaternion.identity);
        }
    }
}
