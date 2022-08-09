using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Pais" )]
   [XmlType(TypeName =  "Pais" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtPais : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais( )
      {
      }

      public SdtPais( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV3PaisId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV3PaisId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Pais");
         metadata.Set("BT", "Pais");
         metadata.Set("PK", "[ \"PaisId\" ]");
         metadata.Set("PKAssigned", "[ \"PaisId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Paisflag_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisname_Z");
         state.Add("gxTpr_Paisflag_gxi_Z");
         state.Add("gxTpr_Paisflag_N");
         state.Add("gxTpr_Paisflag_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPais sdt;
         sdt = (SdtPais)(source);
         gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         gxTv_SdtPais_Paisname = sdt.gxTv_SdtPais_Paisname ;
         gxTv_SdtPais_Paisflag = sdt.gxTv_SdtPais_Paisflag ;
         gxTv_SdtPais_Paisflag_gxi = sdt.gxTv_SdtPais_Paisflag_gxi ;
         gxTv_SdtPais_Mode = sdt.gxTv_SdtPais_Mode ;
         gxTv_SdtPais_Initialized = sdt.gxTv_SdtPais_Initialized ;
         gxTv_SdtPais_Paisid_Z = sdt.gxTv_SdtPais_Paisid_Z ;
         gxTv_SdtPais_Paisname_Z = sdt.gxTv_SdtPais_Paisname_Z ;
         gxTv_SdtPais_Paisflag_gxi_Z = sdt.gxTv_SdtPais_Paisflag_gxi_Z ;
         gxTv_SdtPais_Paisflag_N = sdt.gxTv_SdtPais_Paisflag_N ;
         gxTv_SdtPais_Paisflag_gxi_N = sdt.gxTv_SdtPais_Paisflag_gxi_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("PaisId", gxTv_SdtPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisName", gxTv_SdtPais_Paisname, false, includeNonInitialized);
         AddObjectProperty("PaisFlag", gxTv_SdtPais_Paisflag, false, includeNonInitialized);
         AddObjectProperty("PaisFlag_N", gxTv_SdtPais_Paisflag_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PaisFlag_GXI", gxTv_SdtPais_Paisflag_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisName_Z", gxTv_SdtPais_Paisname_Z, false, includeNonInitialized);
            AddObjectProperty("PaisFlag_GXI_Z", gxTv_SdtPais_Paisflag_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("PaisFlag_N", gxTv_SdtPais_Paisflag_N, false, includeNonInitialized);
            AddObjectProperty("PaisFlag_GXI_N", gxTv_SdtPais_Paisflag_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPais sdt )
      {
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         }
         if ( sdt.IsDirty("PaisName") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisname = sdt.gxTv_SdtPais_Paisname ;
         }
         if ( sdt.IsDirty("PaisFlag") )
         {
            gxTv_SdtPais_Paisflag_N = (short)(sdt.gxTv_SdtPais_Paisflag_N);
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag = sdt.gxTv_SdtPais_Paisflag ;
         }
         if ( sdt.IsDirty("PaisFlag") )
         {
            gxTv_SdtPais_Paisflag_gxi_N = (short)(sdt.gxTv_SdtPais_Paisflag_gxi_N);
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag_gxi = sdt.gxTv_SdtPais_Paisflag_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtPais_Paisid ;
         }

         set {
            gxTv_SdtPais_N = 0;
            if ( gxTv_SdtPais_Paisid != value )
            {
               gxTv_SdtPais_Mode = "INS";
               this.gxTv_SdtPais_Paisid_Z_SetNull( );
               this.gxTv_SdtPais_Paisname_Z_SetNull( );
               this.gxTv_SdtPais_Paisflag_gxi_Z_SetNull( );
            }
            gxTv_SdtPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisName" )]
      [  XmlElement( ElementName = "PaisName"   )]
      public string gxTpr_Paisname
      {
         get {
            return gxTv_SdtPais_Paisname ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisname = value;
            SetDirty("Paisname");
         }

      }

      [  SoapElement( ElementName = "PaisFlag" )]
      [  XmlElement( ElementName = "PaisFlag"   )]
      [GxUpload()]
      public string gxTpr_Paisflag
      {
         get {
            return gxTv_SdtPais_Paisflag ;
         }

         set {
            gxTv_SdtPais_Paisflag_N = 0;
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag = value;
            SetDirty("Paisflag");
         }

      }

      public void gxTv_SdtPais_Paisflag_SetNull( )
      {
         gxTv_SdtPais_Paisflag_N = 1;
         gxTv_SdtPais_Paisflag = "";
         SetDirty("Paisflag");
         return  ;
      }

      public bool gxTv_SdtPais_Paisflag_IsNull( )
      {
         return (gxTv_SdtPais_Paisflag_N==1) ;
      }

      [  SoapElement( ElementName = "PaisFlag_GXI" )]
      [  XmlElement( ElementName = "PaisFlag_GXI"   )]
      public string gxTpr_Paisflag_gxi
      {
         get {
            return gxTv_SdtPais_Paisflag_gxi ;
         }

         set {
            gxTv_SdtPais_Paisflag_gxi_N = 0;
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag_gxi = value;
            SetDirty("Paisflag_gxi");
         }

      }

      public void gxTv_SdtPais_Paisflag_gxi_SetNull( )
      {
         gxTv_SdtPais_Paisflag_gxi_N = 1;
         gxTv_SdtPais_Paisflag_gxi = "";
         SetDirty("Paisflag_gxi");
         return  ;
      }

      public bool gxTv_SdtPais_Paisflag_gxi_IsNull( )
      {
         return (gxTv_SdtPais_Paisflag_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPais_Mode ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPais_Mode_SetNull( )
      {
         gxTv_SdtPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPais_Initialized ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPais_Initialized_SetNull( )
      {
         gxTv_SdtPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtPais_Paisid_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisName_Z" )]
      [  XmlElement( ElementName = "PaisName_Z"   )]
      public string gxTpr_Paisname_Z
      {
         get {
            return gxTv_SdtPais_Paisname_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisname_Z = value;
            SetDirty("Paisname_Z");
         }

      }

      public void gxTv_SdtPais_Paisname_Z_SetNull( )
      {
         gxTv_SdtPais_Paisname_Z = "";
         SetDirty("Paisname_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisFlag_GXI_Z" )]
      [  XmlElement( ElementName = "PaisFlag_GXI_Z"   )]
      public string gxTpr_Paisflag_gxi_Z
      {
         get {
            return gxTv_SdtPais_Paisflag_gxi_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag_gxi_Z = value;
            SetDirty("Paisflag_gxi_Z");
         }

      }

      public void gxTv_SdtPais_Paisflag_gxi_Z_SetNull( )
      {
         gxTv_SdtPais_Paisflag_gxi_Z = "";
         SetDirty("Paisflag_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisflag_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisFlag_N" )]
      [  XmlElement( ElementName = "PaisFlag_N"   )]
      public short gxTpr_Paisflag_N
      {
         get {
            return gxTv_SdtPais_Paisflag_N ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag_N = value;
            SetDirty("Paisflag_N");
         }

      }

      public void gxTv_SdtPais_Paisflag_N_SetNull( )
      {
         gxTv_SdtPais_Paisflag_N = 0;
         SetDirty("Paisflag_N");
         return  ;
      }

      public bool gxTv_SdtPais_Paisflag_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisFlag_GXI_N" )]
      [  XmlElement( ElementName = "PaisFlag_GXI_N"   )]
      public short gxTpr_Paisflag_gxi_N
      {
         get {
            return gxTv_SdtPais_Paisflag_gxi_N ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisflag_gxi_N = value;
            SetDirty("Paisflag_gxi_N");
         }

      }

      public void gxTv_SdtPais_Paisflag_gxi_N_SetNull( )
      {
         gxTv_SdtPais_Paisflag_gxi_N = 0;
         SetDirty("Paisflag_gxi_N");
         return  ;
      }

      public bool gxTv_SdtPais_Paisflag_gxi_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPais_N = 1;
         gxTv_SdtPais_Paisname = "";
         gxTv_SdtPais_Paisflag = "";
         gxTv_SdtPais_Paisflag_gxi = "";
         gxTv_SdtPais_Mode = "";
         gxTv_SdtPais_Paisname_Z = "";
         gxTv_SdtPais_Paisflag_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pais", "GeneXus.Programs.pais_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPais_N ;
      }

      private short gxTv_SdtPais_Paisid ;
      private short gxTv_SdtPais_N ;
      private short gxTv_SdtPais_Initialized ;
      private short gxTv_SdtPais_Paisid_Z ;
      private short gxTv_SdtPais_Paisflag_N ;
      private short gxTv_SdtPais_Paisflag_gxi_N ;
      private string gxTv_SdtPais_Mode ;
      private string gxTv_SdtPais_Paisname ;
      private string gxTv_SdtPais_Paisflag_gxi ;
      private string gxTv_SdtPais_Paisname_Z ;
      private string gxTv_SdtPais_Paisflag_gxi_Z ;
      private string gxTv_SdtPais_Paisflag ;
   }

   [DataContract(Name = @"Pais", Namespace = "Obligatorio1v2")]
   public class SdtPais_RESTInterface : GxGenericCollectionItem<SdtPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais_RESTInterface( ) : base()
      {
      }

      public SdtPais_RESTInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Paisid
      {
         get {
            return sdt.gxTpr_Paisid ;
         }

         set {
            sdt.gxTpr_Paisid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisname
      {
         get {
            return sdt.gxTpr_Paisname ;
         }

         set {
            sdt.gxTpr_Paisname = value;
         }

      }

      [DataMember( Name = "PaisFlag" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Paisflag
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Paisflag)) ? PathUtil.RelativeURL( sdt.gxTpr_Paisflag) : StringUtil.RTrim( sdt.gxTpr_Paisflag_gxi)) ;
         }

         set {
            sdt.gxTpr_Paisflag = value;
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPais() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Pais", Namespace = "Obligatorio1v2")]
   public class SdtPais_RESTLInterface : GxGenericCollectionItem<SdtPais>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPais_RESTLInterface( ) : base()
      {
      }

      public SdtPais_RESTLInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisname
      {
         get {
            return sdt.gxTpr_Paisname ;
         }

         set {
            sdt.gxTpr_Paisname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtPais() ;
         }
      }

   }

}
