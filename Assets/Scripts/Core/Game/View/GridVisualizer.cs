using System;
using TMPro;
using UnityEngine;

namespace Core.Game.View
{
    public class GridVisualizer : MonoBehaviour
    {
        [SerializeField] private Color WalkableColor = Color.green;
        [SerializeField] private Color UnWalkableColor = Color.red;
        [SerializeField] private Color OccupiedColor = Color.yellow;
        [SerializeField] private CellPoint pointPrefab;
        [SerializeField] private LineRenderer linePrefab;
        [SerializeField] private Transform content;
        [SerializeField] private Main main;
        [SerializeField] private TextMeshProUGUI curDimenText;
        [SerializeField] private TextMeshProUGUI curPosText;
        private CellPoint[,,] cellPoints;
        private Vector3Int? curPos;

        private CellPoint CurPoint => curPos != null ? cellPoints[curPos.Value.x, curPos.Value.y, curPos.Value.z] : null;

        private void Awake()
        {
            main.OnSetGrids += GenerateGrid;
            main.OnCurPosChanged += OnCurPosChanged;
        }

        private void Start()
        {
            CreateFrame(main.Size);
        }

        private void CreateFrame(int size)
        {
            DrawGridLines(size, size, size);
            cellPoints = new CellPoint[size, size, size];
            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
            for (var z = 0; z < size; z++)
                cellPoints[x, y, z] = Instantiate(pointPrefab, new Vector3(x, y, z), Quaternion.identity, content);
        }

        private void OnCurPosChanged(Dimen dimen, int x, int y, int z, int w)
        {
            const string color = "#FFFFFF88";
            curPosText.text = dimen switch
            {
                Dimen.XYZ => $"Current Position:({x},{y},{z},<color={color}>{w}</color>)",
                Dimen.YZW => $"Current Position:(<color={color}>{x}</color>,{y},{z},{w})",
                Dimen.ZWX => $"Current Position:({x},<color={color}>{y}</color>,{z},{w})",
                Dimen.WXY => $"Current Position:({x},{y},<color={color}>{z}</color>,{w})",
                _ => throw new ArgumentOutOfRangeException()
            };
            curDimenText.text = $"Current Dimension:{dimen.ToString()}";

            if (curPos != null)
            {
                CurPoint.SetColor(WalkableColor);
            }

            curPos = dimen switch
            {
                Dimen.XYZ => new Vector3Int(x, y, z),
                Dimen.YZW => new Vector3Int(y, z, w),
                Dimen.ZWX => new Vector3Int(z, w, x),
                Dimen.WXY => new Vector3Int(w, x, y),
                _ => throw new ArgumentOutOfRangeException()
            };
            CurPoint.SetColor(OccupiedColor);
        }


        private void GenerateGrid(int[,,] points)
        {
            var size = main.Size;
            for (var x = 0; x < size; x++)
            for (var y = 0; y < size; y++)
            for (var z = 0; z < size; z++)
                cellPoints[x, y, z].SetColor(points[x, y, z] == 0 ? WalkableColor : UnWalkableColor);
            curPos = null;
        }

        private void DrawGridLines(int sizeX, int sizeY, int sizeZ)
        {
            for (int y = 0; y < sizeY; y++)
            for (int z = 0; z < sizeZ; z++)
                DrawLine(new Vector3(0, y, z), new Vector3(sizeX - 1, y, z));
            for (int z = 0; z < sizeZ; z++)
            for (int x = 0; x < sizeX; x++)
                DrawLine(new Vector3(x, 0, z), new Vector3(x, sizeY - 1, z));
            for (int x = 0; x < sizeX; x++)
            for (int y = 0; y < sizeY; y++)
                DrawLine(new Vector3(x, y, 0), new Vector3(x, y, sizeZ - 1));
        }

        private void DrawLine(Vector3 start, Vector3 end)
        {
            LineRenderer lineRenderer = Instantiate(linePrefab, content);
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new[] { start, end });
        }
    }
}