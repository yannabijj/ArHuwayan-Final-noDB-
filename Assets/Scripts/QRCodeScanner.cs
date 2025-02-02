using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
using ZXing.Common;
using ZXing;

public class QRCodeScanner : MonoBehaviour
{
    [SerializeField] private ARCameraManager cameraManager;
    public RawImage scanZone;
    public Button qrCodeButton;
    public TMP_InputField searchInputField;
    public TMP_Dropdown searchDropdown;
    public GameObject qrCodeOverlay;
    public GameObject popupWindow;

    private bool scanning = false;
    public SetNavigationTarget navigationTargetHandler;
    private List<string> filteredResults = new List<string>();

    private IBarcodeReader barcodeReader = new BarcodeReader
    {
        AutoRotate = true,
        Options = new DecodingOptions { TryHarder = true }
    };

    private void Start()
    {
        qrCodeButton.onClick.AddListener(StartScanning);
        scanZone.gameObject.SetActive(false);
        searchInputField.gameObject.SetActive(false);
        searchDropdown.gameObject.SetActive(false);
        qrCodeOverlay.SetActive(false);
        popupWindow.SetActive(false);

        if (searchInputField != null)
        {
            searchInputField.onValueChanged.AddListener(OnSearchInputChanged);
            searchInputField.onSubmit.AddListener(OnSearchSubmit);
        }
        else
        {
            Debug.LogError("Search Input Field is not assigned.");
        }

        searchDropdown.onValueChanged.AddListener(OnDropdownSelectionChanged);
    }

    private void OnEnable()
    {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    private void StartScanning()
    {
        scanZone.gameObject.SetActive(true);
        qrCodeOverlay.SetActive(true);
        scanning = true;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        if (scanning)
        {
            if (cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
            {
                var conversionParams = new XRCpuImage.ConversionParams
                {
                    inputRect = new RectInt(0, 0, image.width, image.height),
                    outputDimensions = new Vector2Int(image.width / 2, image.height / 2),
                    outputFormat = TextureFormat.RGBA32,
                    transformation = XRCpuImage.Transformation.MirrorY
                };

                int size = image.GetConvertedDataSize(conversionParams);
                var buffer = new NativeArray<byte>(size, Allocator.Temp);
                image.Convert(conversionParams, buffer);

                Texture2D cameraImageTexture = new Texture2D(conversionParams.outputDimensions.x, conversionParams.outputDimensions.y, conversionParams.outputFormat, false);
                cameraImageTexture.LoadRawTextureData(buffer);
                cameraImageTexture.Apply();

                buffer.Dispose();
                image.Dispose();

                var result = barcodeReader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

                if (result != null && result.Text == "DEST_MENU")
                {
                    searchInputField.gameObject.SetActive(true);
                    searchDropdown.gameObject.SetActive(true);
                    popupWindow.SetActive(true);

                    scanning = false;
                    scanZone.gameObject.SetActive(false);
                    qrCodeOverlay.SetActive(false);

                    Debug.Log("QR code detected: DEST_MENU");
                }
            }
        }
    }

    public void ClosePopup()
    {
        popupWindow.SetActive(false);
    }

    public void OnSearchInputChanged(string inputText)
    {
        if (!string.IsNullOrEmpty(inputText))
        {
            FetchFilteredDestinations(inputText);
        }
        else
        {
            searchDropdown.ClearOptions();
            searchDropdown.gameObject.SetActive(false);
        }
    }

    public void OnSearchSubmit(string inputText)
    {
        if (!string.IsNullOrEmpty(inputText))
        {
            FetchFilteredDestinations(inputText);
        }
    }

    private void FetchFilteredDestinations(string query)
    {
        filteredResults.Clear();
        foreach (var entry in TargetData.targets)  // Updated to use "targets"
        {
            if (entry.Value.name.ToLower().Contains(query.ToLower()) || entry.Value.lotAddress.ToLower().Contains(query.ToLower()))
            {
                filteredResults.Add(entry.Value.name);  // Only showing name, but you can also show lotAddress if needed
            }
        }

        searchDropdown.ClearOptions();
        if (filteredResults.Count > 0)
        {
            searchDropdown.AddOptions(filteredResults);
            searchDropdown.gameObject.SetActive(true);
        }
        else
        {
            searchDropdown.gameObject.SetActive(false);
        }
    }

    private void OnDropdownSelectionChanged(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < filteredResults.Count)
        {
            string selectedDestination = filteredResults[selectedIndex];
            searchInputField.text = selectedDestination;
            GetTargetPosition(selectedDestination);

            // Ensure navigation updates after selecting from dropdown
            if (navigationTargetHandler != null)
            {
                navigationTargetHandler.UpdateTargetPosition(TargetData.targets.Values.FirstOrDefault(t => t.name == selectedDestination)?.position ?? Vector3.zero);
            }
        }
    }

    private void GetTargetPosition(string destination)
    {
        var targetInfo = TargetData.targets.Values.FirstOrDefault(t => t.name == destination);
        if (targetInfo != null)
        {
            if (navigationTargetHandler != null)
            {
                navigationTargetHandler.UpdateTargetPosition(targetInfo.position);
            }
            else
            {
                Debug.LogError("NavigationTargetHandler is not assigned.");
            }
        }
        else
        {
            Debug.LogError("Target position not found for: " + destination);
        }
    }
}
