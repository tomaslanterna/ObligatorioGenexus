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
   [XmlRoot(ElementName = "Lugar.Sector" )]
   [XmlType(TypeName =  "Lugar.Sector" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtLugar_Sector : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtLugar_Sector( )
      {
      }

      public SdtLugar_Sector( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"LugarSectorId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Sector");
         metadata.Set("BT", "LugarSector");
         metadata.Set("PK", "[ \"LugarSectorId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LugarId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Lugarsectorid_Z");
         state.Add("gxTpr_Lugarsectorname_Z");
         state.Add("gxTpr_Lugarsectorcantidad_Z");
         state.Add("gxTpr_Lugarsectorprecio_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLugar_Sector sdt;
         sdt = (SdtLugar_Sector)(source);
         gxTv_SdtLugar_Sector_Lugarsectorid = sdt.gxTv_SdtLugar_Sector_Lugarsectorid ;
         gxTv_SdtLugar_Sector_Lugarsectorname = sdt.gxTv_SdtLugar_Sector_Lugarsectorname ;
         gxTv_SdtLugar_Sector_Lugarsectorcantidad = sdt.gxTv_SdtLugar_Sector_Lugarsectorcantidad ;
         gxTv_SdtLugar_Sector_Lugarsectorprecio = sdt.gxTv_SdtLugar_Sector_Lugarsectorprecio ;
         gxTv_SdtLugar_Sector_Mode = sdt.gxTv_SdtLugar_Sector_Mode ;
         gxTv_SdtLugar_Sector_Modified = sdt.gxTv_SdtLugar_Sector_Modified ;
         gxTv_SdtLugar_Sector_Initialized = sdt.gxTv_SdtLugar_Sector_Initialized ;
         gxTv_SdtLugar_Sector_Lugarsectorid_Z = sdt.gxTv_SdtLugar_Sector_Lugarsectorid_Z ;
         gxTv_SdtLugar_Sector_Lugarsectorname_Z = sdt.gxTv_SdtLugar_Sector_Lugarsectorname_Z ;
         gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z = sdt.gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z ;
         gxTv_SdtLugar_Sector_Lugarsectorprecio_Z = sdt.gxTv_SdtLugar_Sector_Lugarsectorprecio_Z ;
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
         AddObjectProperty("LugarSectorId", gxTv_SdtLugar_Sector_Lugarsectorid, false, includeNonInitialized);
         AddObjectProperty("LugarSectorName", gxTv_SdtLugar_Sector_Lugarsectorname, false, includeNonInitialized);
         AddObjectProperty("LugarSectorCantidad", gxTv_SdtLugar_Sector_Lugarsectorcantidad, false, includeNonInitialized);
         AddObjectProperty("LugarSectorPrecio", gxTv_SdtLugar_Sector_Lugarsectorprecio, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLugar_Sector_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtLugar_Sector_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLugar_Sector_Initialized, false, includeNonInitialized);
            AddObjectProperty("LugarSectorId_Z", gxTv_SdtLugar_Sector_Lugarsectorid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorName_Z", gxTv_SdtLugar_Sector_Lugarsectorname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorCantidad_Z", gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorPrecio_Z", gxTv_SdtLugar_Sector_Lugarsectorprecio_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLugar_Sector sdt )
      {
         if ( sdt.IsDirty("LugarSectorId") )
         {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorid = sdt.gxTv_SdtLugar_Sector_Lugarsectorid ;
         }
         if ( sdt.IsDirty("LugarSectorName") )
         {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorname = sdt.gxTv_SdtLugar_Sector_Lugarsectorname ;
         }
         if ( sdt.IsDirty("LugarSectorCantidad") )
         {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorcantidad = sdt.gxTv_SdtLugar_Sector_Lugarsectorcantidad ;
         }
         if ( sdt.IsDirty("LugarSectorPrecio") )
         {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorprecio = sdt.gxTv_SdtLugar_Sector_Lugarsectorprecio ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LugarSectorId" )]
      [  XmlElement( ElementName = "LugarSectorId"   )]
      public short gxTpr_Lugarsectorid
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorid ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorid = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorid");
         }

      }

      [  SoapElement( ElementName = "LugarSectorName" )]
      [  XmlElement( ElementName = "LugarSectorName"   )]
      public string gxTpr_Lugarsectorname
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorname ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorname = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorname");
         }

      }

      [  SoapElement( ElementName = "LugarSectorCantidad" )]
      [  XmlElement( ElementName = "LugarSectorCantidad"   )]
      public short gxTpr_Lugarsectorcantidad
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorcantidad ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorcantidad = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorcantidad");
         }

      }

      [  SoapElement( ElementName = "LugarSectorPrecio" )]
      [  XmlElement( ElementName = "LugarSectorPrecio"   )]
      public short gxTpr_Lugarsectorprecio
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorprecio ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorprecio = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorprecio");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLugar_Sector_Mode ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLugar_Sector_Mode_SetNull( )
      {
         gxTv_SdtLugar_Sector_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtLugar_Sector_Modified ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtLugar_Sector_Modified_SetNull( )
      {
         gxTv_SdtLugar_Sector_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLugar_Sector_Initialized ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Initialized = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLugar_Sector_Initialized_SetNull( )
      {
         gxTv_SdtLugar_Sector_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorId_Z" )]
      [  XmlElement( ElementName = "LugarSectorId_Z"   )]
      public short gxTpr_Lugarsectorid_Z
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorid_Z ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorid_Z = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorid_Z");
         }

      }

      public void gxTv_SdtLugar_Sector_Lugarsectorid_Z_SetNull( )
      {
         gxTv_SdtLugar_Sector_Lugarsectorid_Z = 0;
         SetDirty("Lugarsectorid_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Lugarsectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorName_Z" )]
      [  XmlElement( ElementName = "LugarSectorName_Z"   )]
      public string gxTpr_Lugarsectorname_Z
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorname_Z ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorname_Z = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorname_Z");
         }

      }

      public void gxTv_SdtLugar_Sector_Lugarsectorname_Z_SetNull( )
      {
         gxTv_SdtLugar_Sector_Lugarsectorname_Z = "";
         SetDirty("Lugarsectorname_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Lugarsectorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorCantidad_Z" )]
      [  XmlElement( ElementName = "LugarSectorCantidad_Z"   )]
      public short gxTpr_Lugarsectorcantidad_Z
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorcantidad_Z");
         }

      }

      public void gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z_SetNull( )
      {
         gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z = 0;
         SetDirty("Lugarsectorcantidad_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorPrecio_Z" )]
      [  XmlElement( ElementName = "LugarSectorPrecio_Z"   )]
      public short gxTpr_Lugarsectorprecio_Z
      {
         get {
            return gxTv_SdtLugar_Sector_Lugarsectorprecio_Z ;
         }

         set {
            gxTv_SdtLugar_Sector_N = 0;
            gxTv_SdtLugar_Sector_Lugarsectorprecio_Z = value;
            gxTv_SdtLugar_Sector_Modified = 1;
            SetDirty("Lugarsectorprecio_Z");
         }

      }

      public void gxTv_SdtLugar_Sector_Lugarsectorprecio_Z_SetNull( )
      {
         gxTv_SdtLugar_Sector_Lugarsectorprecio_Z = 0;
         SetDirty("Lugarsectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_Lugarsectorprecio_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtLugar_Sector_N = 1;
         gxTv_SdtLugar_Sector_Lugarsectorname = "";
         gxTv_SdtLugar_Sector_Mode = "";
         gxTv_SdtLugar_Sector_Lugarsectorname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtLugar_Sector_N ;
      }

      private short gxTv_SdtLugar_Sector_Lugarsectorid ;
      private short gxTv_SdtLugar_Sector_N ;
      private short gxTv_SdtLugar_Sector_Lugarsectorcantidad ;
      private short gxTv_SdtLugar_Sector_Lugarsectorprecio ;
      private short gxTv_SdtLugar_Sector_Modified ;
      private short gxTv_SdtLugar_Sector_Initialized ;
      private short gxTv_SdtLugar_Sector_Lugarsectorid_Z ;
      private short gxTv_SdtLugar_Sector_Lugarsectorcantidad_Z ;
      private short gxTv_SdtLugar_Sector_Lugarsectorprecio_Z ;
      private string gxTv_SdtLugar_Sector_Mode ;
      private string gxTv_SdtLugar_Sector_Lugarsectorname ;
      private string gxTv_SdtLugar_Sector_Lugarsectorname_Z ;
   }

   [DataContract(Name = @"Lugar.Sector", Namespace = "Obligatorio1v2")]
   public class SdtLugar_Sector_RESTInterface : GxGenericCollectionItem<SdtLugar_Sector>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtLugar_Sector_RESTInterface( ) : base()
      {
      }

      public SdtLugar_Sector_RESTInterface( SdtLugar_Sector psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LugarSectorId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarsectorid
      {
         get {
            return sdt.gxTpr_Lugarsectorid ;
         }

         set {
            sdt.gxTpr_Lugarsectorid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarSectorName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Lugarsectorname
      {
         get {
            return sdt.gxTpr_Lugarsectorname ;
         }

         set {
            sdt.gxTpr_Lugarsectorname = value;
         }

      }

      [DataMember( Name = "LugarSectorCantidad" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarsectorcantidad
      {
         get {
            return sdt.gxTpr_Lugarsectorcantidad ;
         }

         set {
            sdt.gxTpr_Lugarsectorcantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarSectorPrecio" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarsectorprecio
      {
         get {
            return sdt.gxTpr_Lugarsectorprecio ;
         }

         set {
            sdt.gxTpr_Lugarsectorprecio = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtLugar_Sector sdt
      {
         get {
            return (SdtLugar_Sector)Sdt ;
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
            sdt = new SdtLugar_Sector() ;
         }
      }

   }

   [DataContract(Name = @"Lugar.Sector", Namespace = "Obligatorio1v2")]
   public class SdtLugar_Sector_RESTLInterface : GxGenericCollectionItem<SdtLugar_Sector>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtLugar_Sector_RESTLInterface( ) : base()
      {
      }

      public SdtLugar_Sector_RESTLInterface( SdtLugar_Sector psdt ) : base(psdt)
      {
      }

      public SdtLugar_Sector sdt
      {
         get {
            return (SdtLugar_Sector)Sdt ;
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
            sdt = new SdtLugar_Sector() ;
         }
      }

   }

}
