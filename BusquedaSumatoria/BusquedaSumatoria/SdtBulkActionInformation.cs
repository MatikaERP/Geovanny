using GeneXus.Application;
using GeneXus.Utils;
using System;
using System.Collections;
using System.Xml.Serialization;

namespace BusquedaSumatoria
{
    [XmlRoot(ElementName = "BulkActionInformation")]
    [XmlType(TypeName = "BulkActionInformation", Namespace = "BusquedaSumatoria")]
    [Serializable]
    public class SdtBulkActionInformation : GxUserType
    {
        private static Hashtable mapper;
        protected string sDateCnv;
        protected string sNumToPad;
        protected DateTime datetime_STZ;
        protected string gxTv_SdtBulkActionInformation_Id;
        protected string gxTv_SdtBulkActionInformation_Description;
        protected string gxTv_SdtBulkActionInformation_Progresstype;
        protected int gxTv_SdtBulkActionInformation_Value;
        protected DateTime gxTv_SdtBulkActionInformation_Startdate;
        protected DateTime gxTv_SdtBulkActionInformation_Completedate;
        protected string gxTv_SdtBulkActionInformation_Linkoncomplete;
        protected string gxTv_SdtBulkActionInformation_Linkdescription;
        protected string gxTv_SdtBulkActionInformation_Linktarget;

        public SdtBulkActionInformation()
        {
            this.gxTv_SdtBulkActionInformation_Id = "";
            this.gxTv_SdtBulkActionInformation_Description = "";
            this.gxTv_SdtBulkActionInformation_Progresstype = "";
            this.gxTv_SdtBulkActionInformation_Startdate = DateTime.MinValue;
            this.gxTv_SdtBulkActionInformation_Completedate = DateTime.MinValue;
            this.gxTv_SdtBulkActionInformation_Linkoncomplete = "";
            this.gxTv_SdtBulkActionInformation_Linkdescription = "";
            this.gxTv_SdtBulkActionInformation_Linktarget = "";
        }

        public SdtBulkActionInformation(IGxContext context)
        {
            this.context = context;
            this.initialize();
        }

        public override string JsonMap(string value)
        {
            if (SdtBulkActionInformation.mapper == null)
                SdtBulkActionInformation.mapper = new Hashtable();
            return (string)SdtBulkActionInformation.mapper[(object)value];
        }

        public override void ToJSON() => this.ToJSON(true);

        public override void ToJSON(bool includeState)
        {
            this.AddObjectProperty("Id", (object)this.gxTpr_Id, false);
            this.AddObjectProperty("Description", (object)this.gxTpr_Description, false);
            this.AddObjectProperty("ProgressType", (object)this.gxTpr_Progresstype, false);
            this.AddObjectProperty("Value", (object)this.gxTpr_Value, false);
            this.datetime_STZ = this.gxTpr_Startdate;
            this.sDateCnv = "";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Year(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("0000", 1, 4 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "-";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Month(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "-";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Day(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "T";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Hour(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += ":";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Minute(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += ":";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Second(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.AddObjectProperty("StartDate", (object)this.sDateCnv, false);
            this.datetime_STZ = this.gxTpr_Completedate;
            this.sDateCnv = "";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Year(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("0000", 1, 4 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "-";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Month(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "-";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Day(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += "T";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Hour(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += ":";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Minute(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.sDateCnv += ":";
            this.sNumToPad = StringUtil.Trim(StringUtil.Str((Decimal)DateTimeUtil.Second(this.datetime_STZ), 10, 0));
            this.sDateCnv = this.sDateCnv + StringUtil.Substring("00", 1, 2 - StringUtil.Len(this.sNumToPad)) + this.sNumToPad;
            this.AddObjectProperty("CompleteDate", (object)this.sDateCnv, false);
            this.AddObjectProperty("LinkOnComplete", (object)this.gxTpr_Linkoncomplete, false);
            this.AddObjectProperty("LinkDescription", (object)this.gxTpr_Linkdescription, false);
            this.AddObjectProperty("LinkTarget", (object)this.gxTpr_Linktarget, false);
        }

        [SoapElement(ElementName = "Id")]
        [XmlElement(ElementName = "Id")]
        public string gxTpr_Id
        {
            get => this.gxTv_SdtBulkActionInformation_Id;
            set
            {
                this.gxTv_SdtBulkActionInformation_Id = value;
                this.SetDirty("Id");
            }
        }

        [SoapElement(ElementName = "Description")]
        [XmlElement(ElementName = "Description")]
        public string gxTpr_Description
        {
            get => this.gxTv_SdtBulkActionInformation_Description;
            set
            {
                this.gxTv_SdtBulkActionInformation_Description = value;
                this.SetDirty("Description");
            }
        }

        [SoapElement(ElementName = "ProgressType")]
        [XmlElement(ElementName = "ProgressType")]
        public string gxTpr_Progresstype
        {
            get => this.gxTv_SdtBulkActionInformation_Progresstype;
            set
            {
                this.gxTv_SdtBulkActionInformation_Progresstype = value;
                this.SetDirty("Progresstype");
            }
        }

        [SoapElement(ElementName = "Value")]
        [XmlElement(ElementName = "Value")]
        public int gxTpr_Value
        {
            get => this.gxTv_SdtBulkActionInformation_Value;
            set
            {
                this.gxTv_SdtBulkActionInformation_Value = value;
                this.SetDirty("Value");
            }
        }

        [SoapElement(ElementName = "StartDate")]
        [XmlElement(ElementName = "StartDate", IsNullable = true)]
        public string gxTpr_Startdate_Nullable
        {
            get => this.gxTv_SdtBulkActionInformation_Startdate == DateTime.MinValue ? (string)null : new GxDatetimeString(this.gxTv_SdtBulkActionInformation_Startdate).value;
            set => this.gxTv_SdtBulkActionInformation_Startdate = DateTimeUtil.CToD2(value);
        }

        [XmlIgnore]
        public DateTime gxTpr_Startdate
        {
            get => this.gxTv_SdtBulkActionInformation_Startdate;
            set
            {
                this.gxTv_SdtBulkActionInformation_Startdate = value;
                this.SetDirty("Startdate");
            }
        }

        [SoapElement(ElementName = "CompleteDate")]
        [XmlElement(ElementName = "CompleteDate", IsNullable = true)]
        public string gxTpr_Completedate_Nullable
        {
            get => this.gxTv_SdtBulkActionInformation_Completedate == DateTime.MinValue ? (string)null : new GxDatetimeString(this.gxTv_SdtBulkActionInformation_Completedate).value;
            set => this.gxTv_SdtBulkActionInformation_Completedate = DateTimeUtil.CToD2(value);
        }

        [XmlIgnore]
        public DateTime gxTpr_Completedate
        {
            get => this.gxTv_SdtBulkActionInformation_Completedate;
            set
            {
                this.gxTv_SdtBulkActionInformation_Completedate = value;
                this.SetDirty("Completedate");
            }
        }

        [SoapElement(ElementName = "LinkOnComplete")]
        [XmlElement(ElementName = "LinkOnComplete")]
        public string gxTpr_Linkoncomplete
        {
            get => this.gxTv_SdtBulkActionInformation_Linkoncomplete;
            set
            {
                this.gxTv_SdtBulkActionInformation_Linkoncomplete = value;
                this.SetDirty("Linkoncomplete");
            }
        }

        [SoapElement(ElementName = "LinkDescription")]
        [XmlElement(ElementName = "LinkDescription")]
        public string gxTpr_Linkdescription
        {
            get => this.gxTv_SdtBulkActionInformation_Linkdescription;
            set
            {
                this.gxTv_SdtBulkActionInformation_Linkdescription = value;
                this.SetDirty("Linkdescription");
            }
        }

        [SoapElement(ElementName = "LinkTarget")]
        [XmlElement(ElementName = "LinkTarget")]
        public string gxTpr_Linktarget
        {
            get => this.gxTv_SdtBulkActionInformation_Linktarget;
            set
            {
                this.gxTv_SdtBulkActionInformation_Linktarget = value;
                this.SetDirty("Linktarget");
            }
        }

        public void initialize()
        {
            this.gxTv_SdtBulkActionInformation_Id = "";
            this.gxTv_SdtBulkActionInformation_Description = "";
            this.gxTv_SdtBulkActionInformation_Progresstype = "";
            this.gxTv_SdtBulkActionInformation_Startdate = DateTime.MinValue;
            this.gxTv_SdtBulkActionInformation_Completedate = DateTime.MinValue;
            this.gxTv_SdtBulkActionInformation_Linkoncomplete = "";
            this.gxTv_SdtBulkActionInformation_Linkdescription = "";
            this.gxTv_SdtBulkActionInformation_Linktarget = "";
            this.datetime_STZ = DateTime.MinValue;
            this.sDateCnv = "";
            this.sNumToPad = "";
        }
    }
}
