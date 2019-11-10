using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.
    // Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
    {

    [SerializeField]
    private GameObject PurchaseScreen;

    [SerializeField]
    private Text MessageText;

        private static IStoreController m_StoreController;          // The Unity Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

        public static string shapos650 = "shapos650";
    	public static string shapos1380 = "shapos1380";
        public static string shapos2940 = "shapos2940";

    void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            // If we have already connected to Purchasing ...
            if (IsInitialized())
            {
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            // Add a product to sell / restore by way of its identifier, associating the general identifier
            // with its store-specific identifiers.
            builder.AddProduct(shapos650, ProductType.Consumable);
            builder.AddProduct(shapos1380, ProductType.Consumable);
            builder.AddProduct(shapos2940, ProductType.Consumable);

        // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
        // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
        UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized()
        {
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }


        public void BuyShapos650()
        {
            // Buy the consumable product using its general identifier. Expect a response either 
            // through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(shapos650);
        }

    public void BuyShapos1380()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(shapos1380);
    }

    public void BuyShapos2940()
    {
        // Buy the consumable product using its general identifier. Expect a response either 
        // through ProcessPurchase or OnPurchaseFailed asynchronously.
        BuyProductID(shapos2940);
    }


    void BuyProductID(string productId)
        {
            // If Purchasing has been initialized ...
            if (IsInitialized())
            {
                // ... look up the Product reference with the general product identifier and the Purchasing 
                // system's products collection.
                Product product = m_StoreController.products.WithID(productId);

                // If the look up found a product for this device's store and that product is ready to be sold ... 
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                    // asynchronously.
                    m_StoreController.InitiatePurchase(product);
                }
                // Otherwise ...
                else
                {
                    // ... report the product look-up failure situation  
                    MessageText.text = "BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase";
                    MessageText.gameObject.SetActive(true);

                }
            }
            // Otherwise ...
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initiailization.
                MessageText.text = "BuyProductID FAIL. Not initialized.";
                MessageText.gameObject.SetActive(true);
            }
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }


        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            MessageText.text = ("OnInitializeFailed InitializationFailureReason:" + error);
            MessageText.gameObject.SetActive(true);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            if (string.Equals(args.purchasedProduct.definition.id, shapos650, StringComparison.Ordinal))
            {
                // The consumable item has been successfully purchased, add 650 shapos to the player's shapos.
                int initialShapos = PlayerPrefs.GetInt("shapos", 0);
                int purchasedShapos = 650;
                int currentShapos = initialShapos + purchasedShapos;
                PlayerPrefs.SetInt("shapos", currentShapos);
                MessageText.text = (string.Format("You successfully purchased {0} shapos!", purchasedShapos));
                MessageText.gameObject.SetActive(true);

            }
        // Or ... a non-consumable product has been purchased by this user.
        else if (string.Equals(args.purchasedProduct.definition.id, shapos1380, StringComparison.Ordinal))
        {
            // The consumable item has been successfully purchased, add 13800 shapos to the player's shapos.
            int initialShapos = PlayerPrefs.GetInt("shapos", 0);
            int purchasedShapos = 1380;
            int currentShapos = initialShapos + purchasedShapos;
            PlayerPrefs.SetInt("shapos", currentShapos);
            MessageText.text = (string.Format("You successfully purchased {0} shapos!", purchasedShapos));
            MessageText.gameObject.SetActive(true);
        }
        // Or ... a subscription product has been purchased by this user.
        else if (string.Equals(args.purchasedProduct.definition.id, shapos2940, StringComparison.Ordinal))
        {
            // The consumable item has been successfully purchased, add 2940 shapos to the player's shapos.
            int initialShapos = PlayerPrefs.GetInt("shapos", 0);
            int purchasedShapos = 2940;
            int currentShapos = initialShapos + purchasedShapos;
            PlayerPrefs.SetInt("shapos", currentShapos);
            MessageText.text = (string.Format("You successfully purchased {0} shapos!", purchasedShapos));
            MessageText.gameObject.SetActive(true);
        }
        else
            {
                MessageText.text = (string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
                MessageText.gameObject.SetActive(true);
            }

            return PurchaseProcessingResult.Complete;
        }


        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {

            MessageText.text = string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason);
            MessageText.gameObject.SetActive(true);
        }

    public void OpenPurchaseScreen()
    {
        PurchaseScreen.SetActive(true);
    }

    public void ClosePurchaseScreen()
        {
        PurchaseScreen.SetActive(false);
        }
    }
