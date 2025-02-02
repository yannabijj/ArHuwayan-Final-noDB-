using System.Collections.Generic;
using UnityEngine;

public static class TargetData
{
    // Target data structure: Target ID, Name, X, Y, Z, Lot Address
    public static Dictionary<int, TargetInfo> targets = new Dictionary<int, TargetInfo>
    {
        { 1, new TargetInfo("Ruby", new Vector3(-67.81f, 1f, 33.73f), "Lot 20 Block - A") },
        { 2, new TargetInfo("Maria", new Vector3(-6.7f, 1f, 9.598f), "Lot 20 Block - B") },
        { 3, new TargetInfo("Anna", new Vector3(-67.81f, 1f, 33.73f), "Lot 20 Block - C") },
        { 4, new TargetInfo("Maria Ruby Anna Ferrer", new Vector3(-28.5f, 1f, 63.4f), "Lot 20 Block - D") },
        { 5, new TargetInfo("Ruby Jane", new Vector3(-67.81f, 1f, 33.73f), "Lot 11 Block - A") },
        { 6, new TargetInfo("Maria Clara", new Vector3(-6.7f, 1f, 9.598f), "Lot 11 Block - B") },
        { 7, new TargetInfo("Anna Belle", new Vector3(-33.5f, 1f, 32.2f), "Lot 11 Block - C") },
        { 9, new TargetInfo("Maria Ruby Anna Montefalco", new Vector3(-28.5f, 1f, 63.4f), "Lot 13 Block - D") },
        { 10, new TargetInfo("Michael Jakson", new Vector3(-67.81f, 1f, 33.73f), "Lot 12 Block - A") },
        { 11, new TargetInfo("Marian Kleo", new Vector3(-35.5f, 1f, 9.598f), "Lot 12 Block - B") },
        { 12, new TargetInfo("Michael Jordan", new Vector3(-67.81f, 1f, 33.73f), "Lot 12 Block - C") },
        { 13, new TargetInfo("Nokia Dela Cruz", new Vector3(-6.3f, 1f, 20.5f), "Lot 13 Block - A") },
        { 14, new TargetInfo("Apple Swift", new Vector3(-8.5f, 1f, 16.1f), "Lot 2 Block - B") },
        { 25, new TargetInfo("Lot 78 Block - A", new Vector3(-72.92f, 1f, 6.12f), "Lot 78 Block - A") },
        { 26, new TargetInfo("Lot 77 Block - B", new Vector3(-72.92f, 1f, 7.16f), "Lot 77 Block - B") },
        { 27, new TargetInfo("Lot 76 Block - B", new Vector3(-72.66f, 1f, 8.81f), "Lot 76 Block - B") },
        { 28, new TargetInfo("Lot 75 Block - B", new Vector3(-72.66f, 1f, 10.03f), "Lot 75 Block - B") },
        { 29, new TargetInfo("Lot 502 Block - A", new Vector3(-46.02f, 1f, 38.23f), "Lot 502 Block - A") },
        { 30, new TargetInfo("Lot 501 Block - B", new Vector3(-46.02f, 1f, 37.27f), "Lot 501 Block - B") },
        { 31, new TargetInfo("Lot 500 Block - B", new Vector3(-46.02f, 1f, 36.14f), "Lot 500 Block - B") },
        { 32, new TargetInfo("Lot 76 Block - C", new Vector3(-75.27f, 1f, 42.15f), "Lot 76 Block - C") },
        { 33, new TargetInfo("Lot 75 Block - C", new Vector3(-75.27f, 1f, 43.02f), "Lot 75 Block - C") },
        { 34, new TargetInfo("Lot 74 Block - C", new Vector3(-75.27f, 1f, 43.98f), "Lot 74 Block - C") },
        { 35, new TargetInfo("Lot 452 Block - A", new Vector3(-43.85f, 1f, 70.18f), "Lot 452 Block - A") },
        { 36, new TargetInfo("Lot 453 Block - C", new Vector3(-43.85f, 1f, 69.4f), "Lot 453 Block - C") },
        { 37, new TargetInfo("Lot 454 Block - C", new Vector3(-43.85f, 1f, 68.7f), "Lot 454 Block - C") },
        { 38, new TargetInfo("Lot 492 Block - C", new Vector3(-4.07f, 1f, 67.84f), "Lot 492 Block - C") },
        { 39, new TargetInfo("Lot 493 Block - D", new Vector3(-4.07f, 1f, 66.82f), "Lot 493 Block - D") },
        { 40, new TargetInfo("Lot 494 Block - D", new Vector3(-4.07f, 1f, 65.72f), "Lot 494 Block - D") },
        { 41, new TargetInfo("Lot 62 Block - A", new Vector3(-36.61f, 1f, 41.66f), "Lot 62 Block - A") },
        { 42, new TargetInfo("Lot 61 Block - D", new Vector3(-36.61f, 1f, 42.92f), "Lot 61 Block - D") },
        { 43, new TargetInfo("Lot 60 Block - D", new Vector3(-36.61f, 1f, 44.26f), "Lot 60 Block - D") },
        { 44, new TargetInfo("Lot 71 Block - B", new Vector3(-37.78f, 1f, 7.2f), "Lot 71 Block - B") },
        { 45, new TargetInfo("Lot 72 Block - A", new Vector3(-34.28f, 1f, 7.11f), "Lot 72 Block - A") },
        { 46, new TargetInfo("Lot 73 Block - A", new Vector3(-34.28f, 1f, 7.86f), "Lot 73 Block - A") },
        { 47, new TargetInfo("Lot 575 Block - D", new Vector3(-4.45f, 1f, 38.02f), "Lot 575 Block - D") },
        { 48, new TargetInfo("Lot 576 Block - A", new Vector3(-4.45f, 1f, 37.02f), "Lot 576 Block - A") },
        { 49, new TargetInfo("Lot 577 Block - A", new Vector3(-4.45f, 1f, 35.85f), "Lot 577 Block - A") },
        { 50, new TargetInfo("Lot 74 Block - B", new Vector3(-75.3f, 1f, 8.6f), "Lot 74 Block - B") },
        { 51, new TargetInfo("Lot 71 Block - A", new Vector3(-37.78f, 1f, 7.2f), "Lot 71 Block - A") },
        { 52, new TargetInfo("Lot 71 Block - C", new Vector3(-37.78f, 1f, 7.2f), "Lot 71 Block - C") },
        { 53, new TargetInfo("Lot 575 Block - B", new Vector3(-4.45f, 1f, 38.02f), "Lot 575 Block - B") },
        { 54, new TargetInfo("Lot 575 Block - A", new Vector3(-4.45f, 1f, 38.02f), "Lot 575 Block - A") },
        { 55, new TargetInfo("Lot 78 Block - B", new Vector3(-72.92f, 1f, 6.12f), "Lot 78 Block - B") },
        { 56, new TargetInfo("Lot 78 Block - C", new Vector3(-72.92f, 1f, 6.12f), "Lot 78 Block - C") },
        { 57, new TargetInfo("Lot 502 Block - B", new Vector3(-46.02f, 1f, 38.23f), "Lot 502 Block - B") },
        { 58, new TargetInfo("Lot 502 Block - D", new Vector3(-46.02f, 1f, 38.23f), "Lot 502 Block - D") },
        { 59, new TargetInfo("Lot 76 Block - A", new Vector3(-75.27f, 1f, 42.15f), "Lot 76 Block - A") },
        { 60, new TargetInfo("Lot 76 Block - D", new Vector3(-75.27f, 1f, 42.15f), "Lot 76 Block - D") },
        { 61, new TargetInfo("Lot 452 Block - C", new Vector3(-43.85f, 1f, 70.18f), "Lot 452 Block - C") },
        { 62, new TargetInfo("Lot 452 Block - B", new Vector3(-43.85f, 1f, 70.18f), "Lot 452 Block - B") },
        { 63, new TargetInfo("Lot 492 Block - A", new Vector3(-4.07f, 1f, 67.84f), "Lot 492 Block - A") },
        { 64, new TargetInfo("Lot 492 Block - D", new Vector3(-4.07f, 1f, 67.84f), "Lot 492 Block - D") },
        { 65, new TargetInfo("Lot 62 Block - D", new Vector3(-36.61f, 1f, 41.66f), "Lot 62 Block - D") },
        { 66, new TargetInfo("Lot 62 Block - C", new Vector3(-36.61f, 1f, 41.66f), "Lot 62 Block - C") }
    };
}

public class TargetInfo
{
    public string name;
    public Vector3 position;
    public string lotAddress;

    public TargetInfo(string name, Vector3 position, string lotAddress)
    {
        this.name = name;
        this.position = position;
        this.lotAddress = lotAddress;
    }
}
