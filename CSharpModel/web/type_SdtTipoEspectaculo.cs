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
   [XmlRoot(ElementName = "TipoEspectaculo" )]
   [XmlType(TypeName =  "TipoEspectaculo" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtTipoEspectaculo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoEspectaculo( )
      {
      }

      public SdtTipoEspectaculo( IGxContext context )
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

      public void Load( short AV7TipoEspectaculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV7TipoEspectaculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoEspectaculoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoEspectaculo");
         metadata.Set("BT", "TipoEspectaculo");
         metadata.Set("PK", "[ \"TipoEspectaculoId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoEspectaculoId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Tipoespectaculoid_Z");
         state.Add("gxTpr_Tipoespectaculoname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoEspectaculo sdt;
         sdt = (SdtTipoEspectaculo)(source);
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculoname = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoname ;
         gxTv_SdtTipoEspectaculo_Mode = sdt.gxTv_SdtTipoEspectaculo_Mode ;
         gxTv_SdtTipoEspectaculo_Initialized = sdt.gxTv_SdtTipoEspectaculo_Initialized ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
         gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z ;
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
         AddObjectProperty("TipoEspectaculoId", gxTv_SdtTipoEspectaculo_Tipoespectaculoid, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoName", gxTv_SdtTipoEspectaculo_Tipoespectaculoname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoEspectaculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoEspectaculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoId_Z", gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoName_Z", gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoEspectaculo sdt )
      {
         if ( sdt.IsDirty("TipoEspectaculoId") )
         {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         }
         if ( sdt.IsDirty("TipoEspectaculoName") )
         {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoname = sdt.gxTv_SdtTipoEspectaculo_Tipoespectaculoname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId" )]
      [  XmlElement( ElementName = "TipoEspectaculoId"   )]
      public short gxTpr_Tipoespectaculoid
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            if ( gxTv_SdtTipoEspectaculo_Tipoespectaculoid != value )
            {
               gxTv_SdtTipoEspectaculo_Mode = "INS";
               this.gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_SetNull( );
               this.gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z_SetNull( );
            }
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid = value;
            SetDirty("Tipoespectaculoid");
         }

      }

      [  SoapElement( ElementName = "TipoEspectaculoName" )]
      [  XmlElement( ElementName = "TipoEspectaculoName"   )]
      public string gxTpr_Tipoespectaculoname
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoname ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoname = value;
            SetDirty("Tipoespectaculoname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoEspectaculo_Mode ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Mode_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoEspectaculo_Initialized ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Initialized_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoId_Z"   )]
      public short gxTpr_Tipoespectaculoid_Z
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = value;
            SetDirty("Tipoespectaculoid_Z");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z = 0;
         SetDirty("Tipoespectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoName_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoName_Z"   )]
      public string gxTpr_Tipoespectaculoname_Z
      {
         get {
            return gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z ;
         }

         set {
            gxTv_SdtTipoEspectaculo_N = 0;
            gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z = value;
            SetDirty("Tipoespectaculoname_Z");
         }

      }

      public void gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z_SetNull( )
      {
         gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z = "";
         SetDirty("Tipoespectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTipoEspectaculo_N = 1;
         gxTv_SdtTipoEspectaculo_Tipoespectaculoname = "";
         gxTv_SdtTipoEspectaculo_Mode = "";
         gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipoespectaculo", "GeneXus.Programs.tipoespectaculo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtTipoEspectaculo_N ;
      }

      private short gxTv_SdtTipoEspectaculo_Tipoespectaculoid ;
      private short gxTv_SdtTipoEspectaculo_N ;
      private short gxTv_SdtTipoEspectaculo_Initialized ;
      private short gxTv_SdtTipoEspectaculo_Tipoespectaculoid_Z ;
      private string gxTv_SdtTipoEspectaculo_Mode ;
      private string gxTv_SdtTipoEspectaculo_Tipoespectaculoname ;
      private string gxTv_SdtTipoEspectaculo_Tipoespectaculoname_Z ;
   }

   [DataContract(Name = @"TipoEspectaculo", Namespace = "Obligatorio1v2")]
   public class SdtTipoEspectaculo_RESTInterface : GxGenericCollectionItem<SdtTipoEspectaculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoEspectaculo_RESTInterface( ) : base()
      {
      }

      public SdtTipoEspectaculo_RESTInterface( SdtTipoEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoEspectaculoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoespectaculoid
      {
         get {
            return sdt.gxTpr_Tipoespectaculoid ;
         }

         set {
            sdt.gxTpr_Tipoespectaculoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoEspectaculoName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipoespectaculoname
      {
         get {
            return sdt.gxTpr_Tipoespectaculoname ;
         }

         set {
            sdt.gxTpr_Tipoespectaculoname = value;
         }

      }

      public SdtTipoEspectaculo sdt
      {
         get {
            return (SdtTipoEspectaculo)Sdt ;
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
            sdt = new SdtTipoEspectaculo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"TipoEspectaculo", Namespace = "Obligatorio1v2")]
   public class SdtTipoEspectaculo_RESTLInterface : GxGenericCollectionItem<SdtTipoEspectaculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtTipoEspectaculo_RESTLInterface( ) : base()
      {
      }

      public SdtTipoEspectaculo_RESTLInterface( SdtTipoEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoEspectaculoName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipoespectaculoname
      {
         get {
            return sdt.gxTpr_Tipoespectaculoname ;
         }

         set {
            sdt.gxTpr_Tipoespectaculoname = value;
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

      public SdtTipoEspectaculo sdt
      {
         get {
            return (SdtTipoEspectaculo)Sdt ;
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
            sdt = new SdtTipoEspectaculo() ;
         }
      }

   }

}
