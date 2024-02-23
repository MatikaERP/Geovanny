using GeneXus.Utils;
using System;
using System.Runtime.Serialization;
using System.Web.SessionState;

namespace BusquedaSumatoria
{
    [DataContract(Name = "BulkActionInformation", Namespace = "BusquedaSumatoria")]
    public class SdtBulkActionInformation_RESTInterface :
        GxGenericCollectionItem<SdtBulkActionInformation>,
        IRequiresSessionState
    {
        public SdtBulkActionInformation_RESTInterface()
        {
        }

        public SdtBulkActionInformation_RESTInterface(SdtBulkActionInformation psdt)
          : base(psdt)
        {
        }

        [DataMember(Name = "Id", Order = 0)]
        public string gxTpr_Id
        {
            get => this.sdt.gxTpr_Id;
            set => this.sdt.gxTpr_Id = value;
        }

        [DataMember(Name = "Description", Order = 1)]
        public string gxTpr_Description
        {
            get => this.sdt.gxTpr_Description;
            set => this.sdt.gxTpr_Description = value;
        }

        [DataMember(Name = "ProgressType", Order = 2)]
        public string gxTpr_Progresstype
        {
            get => StringUtil.RTrim(this.sdt.gxTpr_Progresstype);
            set => this.sdt.gxTpr_Progresstype = value;
        }

        [DataMember(Name = "Value", Order = 3)]
        public string gxTpr_Value
        {
            get => StringUtil.LTrim(StringUtil.Str((Decimal)this.sdt.gxTpr_Value, 8, 0));
            set => this.sdt.gxTpr_Value = (int)NumberUtil.Val(value, ".");
        }

        [DataMember(Name = "StartDate", Order = 4)]
        public string gxTpr_Startdate
        {
            get => DateTimeUtil.TToC2(this.sdt.gxTpr_Startdate);
            set => this.sdt.gxTpr_Startdate = DateTimeUtil.CToT2(value);
        }

        [DataMember(Name = "CompleteDate", Order = 5)]
        public string gxTpr_Completedate
        {
            get => DateTimeUtil.TToC2(this.sdt.gxTpr_Completedate);
            set => this.sdt.gxTpr_Completedate = DateTimeUtil.CToT2(value);
        }

        [DataMember(Name = "LinkOnComplete", Order = 6)]
        public string gxTpr_Linkoncomplete
        {
            get => this.sdt.gxTpr_Linkoncomplete;
            set => this.sdt.gxTpr_Linkoncomplete = value;
        }

        [DataMember(Name = "LinkDescription", Order = 7)]
        public string gxTpr_Linkdescription
        {
            get => this.sdt.gxTpr_Linkdescription;
            set => this.sdt.gxTpr_Linkdescription = value;
        }

        [DataMember(Name = "LinkTarget", Order = 8)]
        public string gxTpr_Linktarget
        {
            get => this.sdt.gxTpr_Linktarget;
            set => this.sdt.gxTpr_Linktarget = value;
        }

        public SdtBulkActionInformation sdt
        {
            get => (SdtBulkActionInformation)this.Sdt;
            set => this.Sdt = (GxUserType)value;
        }

        [OnDeserializing]
        private void checkSdt(StreamingContext ctx)
        {
            if (this.sdt != null)
                return;
            this.sdt = new SdtBulkActionInformation();
        }
    }
}
