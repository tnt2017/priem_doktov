using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test111
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class eDIMessage
    {

        private eDIMessageInterchangeHeader interchangeHeaderField;

        private eDIMessageOrder orderField;

        private string idField;

        /// <remarks/>
        public eDIMessageInterchangeHeader interchangeHeader
        {
            get
            {
                return this.interchangeHeaderField;
            }
            set
            {
                this.interchangeHeaderField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrder order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageInterchangeHeader
    {

        private ulong senderField;

        private ulong recipientField;

        private string documentTypeField;

        private System.DateTime creationDateTimeField;

        private System.DateTime creationDateTimeBySenderField;

        /// <remarks/>
        public ulong sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }

        /// <remarks/>
        public ulong recipient
        {
            get
            {
                return this.recipientField;
            }
            set
            {
                this.recipientField = value;
            }
        }

        /// <remarks/>
        public string documentType
        {
            get
            {
                return this.documentTypeField;
            }
            set
            {
                this.documentTypeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime creationDateTime
        {
            get
            {
                return this.creationDateTimeField;
            }
            set
            {
                this.creationDateTimeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime creationDateTimeBySender
        {
            get
            {
                return this.creationDateTimeBySenderField;
            }
            set
            {
                this.creationDateTimeBySenderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrder
    {

        private eDIMessageOrderSeller sellerField;

        private eDIMessageOrderBuyer buyerField;

        private eDIMessageOrderDeliveryInfo deliveryInfoField;

        private string commentField;

        private eDIMessageOrderLineItems lineItemsField;

        private string numberField;

        private System.DateTime dateField;

        /// <remarks/>
        public eDIMessageOrderSeller seller
        {
            get
            {
                return this.sellerField;
            }
            set
            {
                this.sellerField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderBuyer buyer
        {
            get
            {
                return this.buyerField;
            }
            set
            {
                this.buyerField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderDeliveryInfo deliveryInfo
        {
            get
            {
                return this.deliveryInfoField;
            }
            set
            {
                this.deliveryInfoField = value;
            }
        }

        /// <remarks/>
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderLineItems lineItems
        {
            get
            {
                return this.lineItemsField;
            }
            set
            {
                this.lineItemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderSeller
    {

        private ulong glnField;

        private eDIMessageOrderSellerOrganization organizationField;

        private eDIMessageOrderSellerRussianAddress russianAddressField;

        /// <remarks/>
        public ulong gln
        {
            get
            {
                return this.glnField;
            }
            set
            {
                this.glnField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderSellerOrganization organization
        {
            get
            {
                return this.organizationField;
            }
            set
            {
                this.organizationField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderSellerRussianAddress russianAddress
        {
            get
            {
                return this.russianAddressField;
            }
            set
            {
                this.russianAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderSellerOrganization
    {

        private string nameField;

        private ulong innField;

        private uint kppField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ulong inn
        {
            get
            {
                return this.innField;
            }
            set
            {
                this.innField = value;
            }
        }

        /// <remarks/>
        public uint kpp
        {
            get
            {
                return this.kppField;
            }
            set
            {
                this.kppField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderSellerRussianAddress
    {

        private string regionISOCodeField;

        private string cityField;

        private string streetField;

        private string houseField;

        private uint postalCodeField;

        /// <remarks/>
        public string regionISOCode
        {
            get
            {
                return this.regionISOCodeField;
            }
            set
            {
                this.regionISOCodeField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public string house
        {
            get
            {
                return this.houseField;
            }
            set
            {
                this.houseField = value;
            }
        }

        /// <remarks/>
        public uint postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderBuyer
    {

        private ulong glnField;

        private eDIMessageOrderBuyerOrganization organizationField;

        private eDIMessageOrderBuyerRussianAddress russianAddressField;

        /// <remarks/>
        public ulong gln
        {
            get
            {
                return this.glnField;
            }
            set
            {
                this.glnField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderBuyerOrganization organization
        {
            get
            {
                return this.organizationField;
            }
            set
            {
                this.organizationField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderBuyerRussianAddress russianAddress
        {
            get
            {
                return this.russianAddressField;
            }
            set
            {
                this.russianAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderBuyerOrganization
    {

        private string nameField;

        private ulong innField;

        private uint kppField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ulong inn
        {
            get
            {
                return this.innField;
            }
            set
            {
                this.innField = value;
            }
        }

        /// <remarks/>
        public uint kpp
        {
            get
            {
                return this.kppField;
            }
            set
            {
                this.kppField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderBuyerRussianAddress
    {

        private string regionISOCodeField;

        private string cityField;

        private string streetField;

        private string houseField;

        private byte flatField;

        private uint postalCodeField;

        /// <remarks/>
        public string regionISOCode
        {
            get
            {
                return this.regionISOCodeField;
            }
            set
            {
                this.regionISOCodeField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public string house
        {
            get
            {
                return this.houseField;
            }
            set
            {
                this.houseField = value;
            }
        }

        /// <remarks/>
        public byte flat
        {
            get
            {
                return this.flatField;
            }
            set
            {
                this.flatField = value;
            }
        }

        /// <remarks/>
        public uint postalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderDeliveryInfo
    {

        private System.DateTime requestedDeliveryDateTimeField;

        private eDIMessageOrderDeliveryInfoShipTo shipToField;

        /// <remarks/>
        public System.DateTime requestedDeliveryDateTime
        {
            get
            {
                return this.requestedDeliveryDateTimeField;
            }
            set
            {
                this.requestedDeliveryDateTimeField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderDeliveryInfoShipTo shipTo
        {
            get
            {
                return this.shipToField;
            }
            set
            {
                this.shipToField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderDeliveryInfoShipTo
    {

        private ulong glnField;

        private eDIMessageOrderDeliveryInfoShipToOrganization organizationField;

        private eDIMessageOrderDeliveryInfoShipToRussianAddress russianAddressField;

        /// <remarks/>
        public ulong gln
        {
            get
            {
                return this.glnField;
            }
            set
            {
                this.glnField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderDeliveryInfoShipToOrganization organization
        {
            get
            {
                return this.organizationField;
            }
            set
            {
                this.organizationField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderDeliveryInfoShipToRussianAddress russianAddress
        {
            get
            {
                return this.russianAddressField;
            }
            set
            {
                this.russianAddressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderDeliveryInfoShipToOrganization
    {

        private string nameField;

        private ulong innField;

        private uint kppField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public ulong inn
        {
            get
            {
                return this.innField;
            }
            set
            {
                this.innField = value;
            }
        }

        /// <remarks/>
        public uint kpp
        {
            get
            {
                return this.kppField;
            }
            set
            {
                this.kppField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderDeliveryInfoShipToRussianAddress
    {

        private string regionISOCodeField;

        private string cityField;

        private string streetField;

        private byte houseField;

        /// <remarks/>
        public string regionISOCode
        {
            get
            {
                return this.regionISOCodeField;
            }
            set
            {
                this.regionISOCodeField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public byte house
        {
            get
            {
                return this.houseField;
            }
            set
            {
                this.houseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderLineItems
    {

        private string currencyISOCodeField;

        private eDIMessageOrderLineItemsLineItem[] lineItemField;

        private decimal totalSumExcludingTaxesField;

        private decimal totalVATAmountField;

        private decimal totalAmountField;

        /// <remarks/>
        public string currencyISOCode
        {
            get
            {
                return this.currencyISOCodeField;
            }
            set
            {
                this.currencyISOCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("lineItem")]
        public eDIMessageOrderLineItemsLineItem[] lineItem
        {
            get
            {
                return this.lineItemField;
            }
            set
            {
                this.lineItemField = value;
            }
        }

        /// <remarks/>
        public decimal totalSumExcludingTaxes
        {
            get
            {
                return this.totalSumExcludingTaxesField;
            }
            set
            {
                this.totalSumExcludingTaxesField = value;
            }
        }

        /// <remarks/>
        public decimal totalVATAmount
        {
            get
            {
                return this.totalVATAmountField;
            }
            set
            {
                this.totalVATAmountField = value;
            }
        }

        /// <remarks/>
        public decimal totalAmount
        {
            get
            {
                return this.totalAmountField;
            }
            set
            {
                this.totalAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderLineItemsLineItem
    {

        private ulong gtinField;

        private string internalBuyerCodeField;

        private string descriptionField;

        private eDIMessageOrderLineItemsLineItemRequestedQuantity requestedQuantityField;

        private decimal netPriceField;

        private decimal netPriceWithVATField;

        private decimal netAmountField;

        private byte vATRateField;

        private decimal vATAmountField;

        private decimal amountField;

        /// <remarks/>
        public ulong gtin
        {
            get
            {
                return this.gtinField;
            }
            set
            {
                this.gtinField = value;
            }
        }

        /// <remarks/>
        public string internalBuyerCode
        {
            get
            {
                return this.internalBuyerCodeField;
            }
            set
            {
                this.internalBuyerCodeField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public eDIMessageOrderLineItemsLineItemRequestedQuantity requestedQuantity
        {
            get
            {
                return this.requestedQuantityField;
            }
            set
            {
                this.requestedQuantityField = value;
            }
        }

        /// <remarks/>
        public decimal netPrice
        {
            get
            {
                return this.netPriceField;
            }
            set
            {
                this.netPriceField = value;
            }
        }

        /// <remarks/>
        public decimal netPriceWithVAT
        {
            get
            {
                return this.netPriceWithVATField;
            }
            set
            {
                this.netPriceWithVATField = value;
            }
        }

        /// <remarks/>
        public decimal netAmount
        {
            get
            {
                return this.netAmountField;
            }
            set
            {
                this.netAmountField = value;
            }
        }

        /// <remarks/>
        public byte vATRate
        {
            get
            {
                return this.vATRateField;
            }
            set
            {
                this.vATRateField = value;
            }
        }

        /// <remarks/>
        public decimal vATAmount
        {
            get
            {
                return this.vATAmountField;
            }
            set
            {
                this.vATAmountField = value;
            }
        }

        /// <remarks/>
        public decimal amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class eDIMessageOrderLineItemsLineItemRequestedQuantity
    {

        private string unitOfMeasureField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
