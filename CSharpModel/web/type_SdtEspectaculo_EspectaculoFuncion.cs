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
   [XmlRoot(ElementName = "Espectaculo.EspectaculoFuncion" )]
   [XmlType(TypeName =  "Espectaculo.EspectaculoFuncion" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtEspectaculo_EspectaculoFuncion : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEspectaculo_EspectaculoFuncion( )
      {
      }

      public SdtEspectaculo_EspectaculoFuncion( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EspectaculoFuncionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "EspectaculoFuncion");
         metadata.Set("BT", "EspectaculoFuncion");
         metadata.Set("PK", "[ \"EspectaculoFuncionId\" ]");
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
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Espectaculofuncionid_Z");
         state.Add("gxTpr_Espectaculofuncionname_Z");
         state.Add("gxTpr_Espectaculofuncionprecio_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEspectaculo_EspectaculoFuncion sdt;
         sdt = (SdtEspectaculo_EspectaculoFuncion)(source);
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Mode = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Mode ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Modified ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z ;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z ;
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
         AddObjectProperty("EspectaculoFuncionId", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoFuncionName", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname, false, includeNonInitialized);
         AddObjectProperty("EspectaculoFuncionPrecio", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEspectaculo_EspectaculoFuncion_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEspectaculo_EspectaculoFuncion_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized, false, includeNonInitialized);
            AddObjectProperty("EspectaculoFuncionId_Z", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoFuncionName_Z", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoFuncionPrecio_Z", gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEspectaculo_EspectaculoFuncion sdt )
      {
         if ( sdt.IsDirty("EspectaculoFuncionId") )
         {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid ;
         }
         if ( sdt.IsDirty("EspectaculoFuncionName") )
         {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname ;
         }
         if ( sdt.IsDirty("EspectaculoFuncionPrecio") )
         {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio = sdt.gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionId" )]
      [  XmlElement( ElementName = "EspectaculoFuncionId"   )]
      public short gxTpr_Espectaculofuncionid
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFuncionName" )]
      [  XmlElement( ElementName = "EspectaculoFuncionName"   )]
      public string gxTpr_Espectaculofuncionname
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionname");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFuncionPrecio" )]
      [  XmlElement( ElementName = "EspectaculoFuncionPrecio"   )]
      public short gxTpr_Espectaculofuncionprecio
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionprecio");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Mode ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Mode_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Modified ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Modified_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionId_Z" )]
      [  XmlElement( ElementName = "EspectaculoFuncionId_Z"   )]
      public short gxTpr_Espectaculofuncionid_Z
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z = 0;
         SetDirty("Espectaculofuncionid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionName_Z" )]
      [  XmlElement( ElementName = "EspectaculoFuncionName_Z"   )]
      public string gxTpr_Espectaculofuncionname_Z
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z = "";
         SetDirty("Espectaculofuncionname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionPrecio_Z" )]
      [  XmlElement( ElementName = "EspectaculoFuncionPrecio_Z"   )]
      public short gxTpr_Espectaculofuncionprecio_Z
      {
         get {
            return gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z ;
         }

         set {
            gxTv_SdtEspectaculo_EspectaculoFuncion_N = 0;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z = value;
            gxTv_SdtEspectaculo_EspectaculoFuncion_Modified = 1;
            SetDirty("Espectaculofuncionprecio_Z");
         }

      }

      public void gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z = 0;
         SetDirty("Espectaculofuncionprecio_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEspectaculo_EspectaculoFuncion_N = 1;
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname = "";
         gxTv_SdtEspectaculo_EspectaculoFuncion_Mode = "";
         gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEspectaculo_EspectaculoFuncion_N ;
      }

      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_N ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Modified ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Initialized ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionid_Z ;
      private short gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionprecio_Z ;
      private string gxTv_SdtEspectaculo_EspectaculoFuncion_Mode ;
      private string gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname ;
      private string gxTv_SdtEspectaculo_EspectaculoFuncion_Espectaculofuncionname_Z ;
   }

   [DataContract(Name = @"Espectaculo.EspectaculoFuncion", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_EspectaculoFuncion_RESTInterface : GxGenericCollectionItem<SdtEspectaculo_EspectaculoFuncion>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_EspectaculoFuncion_RESTInterface( ) : base()
      {
      }

      public SdtEspectaculo_EspectaculoFuncion_RESTInterface( SdtEspectaculo_EspectaculoFuncion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspectaculoFuncionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculofuncionid
      {
         get {
            return sdt.gxTpr_Espectaculofuncionid ;
         }

         set {
            sdt.gxTpr_Espectaculofuncionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EspectaculoFuncionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Espectaculofuncionname
      {
         get {
            return sdt.gxTpr_Espectaculofuncionname ;
         }

         set {
            sdt.gxTpr_Espectaculofuncionname = value;
         }

      }

      [DataMember( Name = "EspectaculoFuncionPrecio" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Espectaculofuncionprecio
      {
         get {
            return sdt.gxTpr_Espectaculofuncionprecio ;
         }

         set {
            sdt.gxTpr_Espectaculofuncionprecio = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEspectaculo_EspectaculoFuncion sdt
      {
         get {
            return (SdtEspectaculo_EspectaculoFuncion)Sdt ;
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
            sdt = new SdtEspectaculo_EspectaculoFuncion() ;
         }
      }

   }

   [DataContract(Name = @"Espectaculo.EspectaculoFuncion", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_EspectaculoFuncion_RESTLInterface : GxGenericCollectionItem<SdtEspectaculo_EspectaculoFuncion>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_EspectaculoFuncion_RESTLInterface( ) : base()
      {
      }

      public SdtEspectaculo_EspectaculoFuncion_RESTLInterface( SdtEspectaculo_EspectaculoFuncion psdt ) : base(psdt)
      {
      }

      public SdtEspectaculo_EspectaculoFuncion sdt
      {
         get {
            return (SdtEspectaculo_EspectaculoFuncion)Sdt ;
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
            sdt = new SdtEspectaculo_EspectaculoFuncion() ;
         }
      }

   }

}
