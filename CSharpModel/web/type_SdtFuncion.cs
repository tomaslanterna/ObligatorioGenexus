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
   [XmlRoot(ElementName = "Funcion" )]
   [XmlType(TypeName =  "Funcion" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtFuncion : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFuncion( )
      {
      }

      public SdtFuncion( IGxContext context )
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

      public void Load( short AV15FuncionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV15FuncionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FuncionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Funcion");
         metadata.Set("BT", "Funcion");
         metadata.Set("PK", "[ \"FuncionId\" ]");
         metadata.Set("PKAssigned", "[ \"FuncionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EspectaculoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Funcionid_Z");
         state.Add("gxTpr_Funcionname_Z");
         state.Add("gxTpr_Preciofuncion_Z");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculoname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFuncion sdt;
         sdt = (SdtFuncion)(source);
         gxTv_SdtFuncion_Funcionid = sdt.gxTv_SdtFuncion_Funcionid ;
         gxTv_SdtFuncion_Funcionname = sdt.gxTv_SdtFuncion_Funcionname ;
         gxTv_SdtFuncion_Preciofuncion = sdt.gxTv_SdtFuncion_Preciofuncion ;
         gxTv_SdtFuncion_Espectaculoid = sdt.gxTv_SdtFuncion_Espectaculoid ;
         gxTv_SdtFuncion_Espectaculoname = sdt.gxTv_SdtFuncion_Espectaculoname ;
         gxTv_SdtFuncion_Mode = sdt.gxTv_SdtFuncion_Mode ;
         gxTv_SdtFuncion_Initialized = sdt.gxTv_SdtFuncion_Initialized ;
         gxTv_SdtFuncion_Funcionid_Z = sdt.gxTv_SdtFuncion_Funcionid_Z ;
         gxTv_SdtFuncion_Funcionname_Z = sdt.gxTv_SdtFuncion_Funcionname_Z ;
         gxTv_SdtFuncion_Preciofuncion_Z = sdt.gxTv_SdtFuncion_Preciofuncion_Z ;
         gxTv_SdtFuncion_Espectaculoid_Z = sdt.gxTv_SdtFuncion_Espectaculoid_Z ;
         gxTv_SdtFuncion_Espectaculoname_Z = sdt.gxTv_SdtFuncion_Espectaculoname_Z ;
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
         AddObjectProperty("FuncionId", gxTv_SdtFuncion_Funcionid, false, includeNonInitialized);
         AddObjectProperty("FuncionName", gxTv_SdtFuncion_Funcionname, false, includeNonInitialized);
         AddObjectProperty("PrecioFuncion", gxTv_SdtFuncion_Preciofuncion, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId", gxTv_SdtFuncion_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoName", gxTv_SdtFuncion_Espectaculoname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFuncion_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFuncion_Initialized, false, includeNonInitialized);
            AddObjectProperty("FuncionId_Z", gxTv_SdtFuncion_Funcionid_Z, false, includeNonInitialized);
            AddObjectProperty("FuncionName_Z", gxTv_SdtFuncion_Funcionname_Z, false, includeNonInitialized);
            AddObjectProperty("PrecioFuncion_Z", gxTv_SdtFuncion_Preciofuncion_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtFuncion_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoName_Z", gxTv_SdtFuncion_Espectaculoname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFuncion sdt )
      {
         if ( sdt.IsDirty("FuncionId") )
         {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Funcionid = sdt.gxTv_SdtFuncion_Funcionid ;
         }
         if ( sdt.IsDirty("FuncionName") )
         {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Funcionname = sdt.gxTv_SdtFuncion_Funcionname ;
         }
         if ( sdt.IsDirty("PrecioFuncion") )
         {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Preciofuncion = sdt.gxTv_SdtFuncion_Preciofuncion ;
         }
         if ( sdt.IsDirty("EspectaculoId") )
         {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoid = sdt.gxTv_SdtFuncion_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoName") )
         {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoname = sdt.gxTv_SdtFuncion_Espectaculoname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FuncionId" )]
      [  XmlElement( ElementName = "FuncionId"   )]
      public short gxTpr_Funcionid
      {
         get {
            return gxTv_SdtFuncion_Funcionid ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            if ( gxTv_SdtFuncion_Funcionid != value )
            {
               gxTv_SdtFuncion_Mode = "INS";
               this.gxTv_SdtFuncion_Funcionid_Z_SetNull( );
               this.gxTv_SdtFuncion_Funcionname_Z_SetNull( );
               this.gxTv_SdtFuncion_Preciofuncion_Z_SetNull( );
               this.gxTv_SdtFuncion_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtFuncion_Espectaculoname_Z_SetNull( );
            }
            gxTv_SdtFuncion_Funcionid = value;
            SetDirty("Funcionid");
         }

      }

      [  SoapElement( ElementName = "FuncionName" )]
      [  XmlElement( ElementName = "FuncionName"   )]
      public string gxTpr_Funcionname
      {
         get {
            return gxTv_SdtFuncion_Funcionname ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Funcionname = value;
            SetDirty("Funcionname");
         }

      }

      [  SoapElement( ElementName = "PrecioFuncion" )]
      [  XmlElement( ElementName = "PrecioFuncion"   )]
      public short gxTpr_Preciofuncion
      {
         get {
            return gxTv_SdtFuncion_Preciofuncion ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Preciofuncion = value;
            SetDirty("Preciofuncion");
         }

      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtFuncion_Espectaculoid ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoName" )]
      [  XmlElement( ElementName = "EspectaculoName"   )]
      public string gxTpr_Espectaculoname
      {
         get {
            return gxTv_SdtFuncion_Espectaculoname ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoname = value;
            SetDirty("Espectaculoname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFuncion_Mode ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFuncion_Mode_SetNull( )
      {
         gxTv_SdtFuncion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFuncion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFuncion_Initialized ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFuncion_Initialized_SetNull( )
      {
         gxTv_SdtFuncion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFuncion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FuncionId_Z" )]
      [  XmlElement( ElementName = "FuncionId_Z"   )]
      public short gxTpr_Funcionid_Z
      {
         get {
            return gxTv_SdtFuncion_Funcionid_Z ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Funcionid_Z = value;
            SetDirty("Funcionid_Z");
         }

      }

      public void gxTv_SdtFuncion_Funcionid_Z_SetNull( )
      {
         gxTv_SdtFuncion_Funcionid_Z = 0;
         SetDirty("Funcionid_Z");
         return  ;
      }

      public bool gxTv_SdtFuncion_Funcionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FuncionName_Z" )]
      [  XmlElement( ElementName = "FuncionName_Z"   )]
      public string gxTpr_Funcionname_Z
      {
         get {
            return gxTv_SdtFuncion_Funcionname_Z ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Funcionname_Z = value;
            SetDirty("Funcionname_Z");
         }

      }

      public void gxTv_SdtFuncion_Funcionname_Z_SetNull( )
      {
         gxTv_SdtFuncion_Funcionname_Z = "";
         SetDirty("Funcionname_Z");
         return  ;
      }

      public bool gxTv_SdtFuncion_Funcionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PrecioFuncion_Z" )]
      [  XmlElement( ElementName = "PrecioFuncion_Z"   )]
      public short gxTpr_Preciofuncion_Z
      {
         get {
            return gxTv_SdtFuncion_Preciofuncion_Z ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Preciofuncion_Z = value;
            SetDirty("Preciofuncion_Z");
         }

      }

      public void gxTv_SdtFuncion_Preciofuncion_Z_SetNull( )
      {
         gxTv_SdtFuncion_Preciofuncion_Z = 0;
         SetDirty("Preciofuncion_Z");
         return  ;
      }

      public bool gxTv_SdtFuncion_Preciofuncion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtFuncion_Espectaculoid_Z ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtFuncion_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtFuncion_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtFuncion_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoName_Z" )]
      [  XmlElement( ElementName = "EspectaculoName_Z"   )]
      public string gxTpr_Espectaculoname_Z
      {
         get {
            return gxTv_SdtFuncion_Espectaculoname_Z ;
         }

         set {
            gxTv_SdtFuncion_N = 0;
            gxTv_SdtFuncion_Espectaculoname_Z = value;
            SetDirty("Espectaculoname_Z");
         }

      }

      public void gxTv_SdtFuncion_Espectaculoname_Z_SetNull( )
      {
         gxTv_SdtFuncion_Espectaculoname_Z = "";
         SetDirty("Espectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtFuncion_Espectaculoname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtFuncion_N = 1;
         gxTv_SdtFuncion_Funcionname = "";
         gxTv_SdtFuncion_Espectaculoname = "";
         gxTv_SdtFuncion_Mode = "";
         gxTv_SdtFuncion_Funcionname_Z = "";
         gxTv_SdtFuncion_Espectaculoname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "funcion", "GeneXus.Programs.funcion_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtFuncion_N ;
      }

      private short gxTv_SdtFuncion_Funcionid ;
      private short gxTv_SdtFuncion_N ;
      private short gxTv_SdtFuncion_Preciofuncion ;
      private short gxTv_SdtFuncion_Espectaculoid ;
      private short gxTv_SdtFuncion_Initialized ;
      private short gxTv_SdtFuncion_Funcionid_Z ;
      private short gxTv_SdtFuncion_Preciofuncion_Z ;
      private short gxTv_SdtFuncion_Espectaculoid_Z ;
      private string gxTv_SdtFuncion_Mode ;
      private string gxTv_SdtFuncion_Funcionname ;
      private string gxTv_SdtFuncion_Espectaculoname ;
      private string gxTv_SdtFuncion_Funcionname_Z ;
      private string gxTv_SdtFuncion_Espectaculoname_Z ;
   }

   [DataContract(Name = @"Funcion", Namespace = "Obligatorio1v2")]
   public class SdtFuncion_RESTInterface : GxGenericCollectionItem<SdtFuncion>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFuncion_RESTInterface( ) : base()
      {
      }

      public SdtFuncion_RESTInterface( SdtFuncion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FuncionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Funcionid
      {
         get {
            return sdt.gxTpr_Funcionid ;
         }

         set {
            sdt.gxTpr_Funcionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "FuncionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Funcionname
      {
         get {
            return sdt.gxTpr_Funcionname ;
         }

         set {
            sdt.gxTpr_Funcionname = value;
         }

      }

      [DataMember( Name = "PrecioFuncion" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Preciofuncion
      {
         get {
            return sdt.gxTpr_Preciofuncion ;
         }

         set {
            sdt.gxTpr_Preciofuncion = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculoid
      {
         get {
            return sdt.gxTpr_Espectaculoid ;
         }

         set {
            sdt.gxTpr_Espectaculoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Espectaculoname
      {
         get {
            return sdt.gxTpr_Espectaculoname ;
         }

         set {
            sdt.gxTpr_Espectaculoname = value;
         }

      }

      public SdtFuncion sdt
      {
         get {
            return (SdtFuncion)Sdt ;
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
            sdt = new SdtFuncion() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"Funcion", Namespace = "Obligatorio1v2")]
   public class SdtFuncion_RESTLInterface : GxGenericCollectionItem<SdtFuncion>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtFuncion_RESTLInterface( ) : base()
      {
      }

      public SdtFuncion_RESTLInterface( SdtFuncion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FuncionName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Funcionname
      {
         get {
            return sdt.gxTpr_Funcionname ;
         }

         set {
            sdt.gxTpr_Funcionname = value;
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

      public SdtFuncion sdt
      {
         get {
            return (SdtFuncion)Sdt ;
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
            sdt = new SdtFuncion() ;
         }
      }

   }

}
