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
   [XmlRoot(ElementName = "Espectaculo.LugarSector" )]
   [XmlType(TypeName =  "Espectaculo.LugarSector" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtEspectaculo_LugarSector : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtEspectaculo_LugarSector( )
      {
      }

      public SdtEspectaculo_LugarSector( IGxContext context )
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
         metadata.Set("Name", "LugarSector");
         metadata.Set("BT", "EspectaculoLugarSector");
         metadata.Set("PK", "[ \"LugarSectorId\" ]");
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
         state.Add("gxTpr_Lugarsectorid_Z");
         state.Add("gxTpr_Lugarsectorname_Z");
         state.Add("gxTpr_Lugarsectorcantidad_Z");
         state.Add("gxTpr_Lugarsectorestadosector_Z");
         state.Add("gxTpr_Lugarsectorprecio_Z");
         state.Add("gxTpr_Lugarsectorvendidas_Z");
         state.Add("gxTpr_Lugarsectordisponibles_Z");
         state.Add("gxTpr_Lugarsectorvendidas_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEspectaculo_LugarSector sdt;
         sdt = (SdtEspectaculo_LugarSector)(source);
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorid = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorid ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorname = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorname ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles ;
         gxTv_SdtEspectaculo_LugarSector_Mode = sdt.gxTv_SdtEspectaculo_LugarSector_Mode ;
         gxTv_SdtEspectaculo_LugarSector_Modified = sdt.gxTv_SdtEspectaculo_LugarSector_Modified ;
         gxTv_SdtEspectaculo_LugarSector_Initialized = sdt.gxTv_SdtEspectaculo_LugarSector_Initialized ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z ;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N ;
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
         AddObjectProperty("LugarSectorId", gxTv_SdtEspectaculo_LugarSector_Lugarsectorid, false, includeNonInitialized);
         AddObjectProperty("LugarSectorName", gxTv_SdtEspectaculo_LugarSector_Lugarsectorname, false, includeNonInitialized);
         AddObjectProperty("LugarSectorCantidad", gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad, false, includeNonInitialized);
         AddObjectProperty("LugarSectorEstadoSector", gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector, false, includeNonInitialized);
         AddObjectProperty("LugarSectorPrecio", gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio, false, includeNonInitialized);
         AddObjectProperty("LugarSectorVendidas", gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas, false, includeNonInitialized);
         AddObjectProperty("LugarSectorVendidas_N", gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N, false, includeNonInitialized);
         AddObjectProperty("LugarSectorDisponibles", gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEspectaculo_LugarSector_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtEspectaculo_LugarSector_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEspectaculo_LugarSector_Initialized, false, includeNonInitialized);
            AddObjectProperty("LugarSectorId_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorName_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorCantidad_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorEstadoSector_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorPrecio_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorVendidas_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorDisponibles_Z", gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorVendidas_N", gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEspectaculo_LugarSector sdt )
      {
         if ( sdt.IsDirty("LugarSectorId") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorid = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorid ;
         }
         if ( sdt.IsDirty("LugarSectorName") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorname = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorname ;
         }
         if ( sdt.IsDirty("LugarSectorCantidad") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad ;
         }
         if ( sdt.IsDirty("LugarSectorEstadoSector") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector ;
         }
         if ( sdt.IsDirty("LugarSectorPrecio") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio ;
         }
         if ( sdt.IsDirty("LugarSectorVendidas") )
         {
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = (short)(sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N);
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas ;
         }
         if ( sdt.IsDirty("LugarSectorDisponibles") )
         {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles = sdt.gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LugarSectorId" )]
      [  XmlElement( ElementName = "LugarSectorId"   )]
      public short gxTpr_Lugarsectorid
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorid ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorid = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorid");
         }

      }

      [  SoapElement( ElementName = "LugarSectorName" )]
      [  XmlElement( ElementName = "LugarSectorName"   )]
      public string gxTpr_Lugarsectorname
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorname ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorname = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorname");
         }

      }

      [  SoapElement( ElementName = "LugarSectorCantidad" )]
      [  XmlElement( ElementName = "LugarSectorCantidad"   )]
      public short gxTpr_Lugarsectorcantidad
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorcantidad");
         }

      }

      [  SoapElement( ElementName = "LugarSectorEstadoSector" )]
      [  XmlElement( ElementName = "LugarSectorEstadoSector"   )]
      public bool gxTpr_Lugarsectorestadosector
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorestadosector");
         }

      }

      [  SoapElement( ElementName = "LugarSectorPrecio" )]
      [  XmlElement( ElementName = "LugarSectorPrecio"   )]
      public short gxTpr_Lugarsectorprecio
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorprecio");
         }

      }

      [  SoapElement( ElementName = "LugarSectorVendidas" )]
      [  XmlElement( ElementName = "LugarSectorVendidas"   )]
      public short gxTpr_Lugarsectorvendidas
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = 0;
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorvendidas");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = 1;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas = 0;
         SetDirty("Lugarsectorvendidas");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_IsNull( )
      {
         return (gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N==1) ;
      }

      [  SoapElement( ElementName = "LugarSectorDisponibles" )]
      [  XmlElement( ElementName = "LugarSectorDisponibles"   )]
      public short gxTpr_Lugarsectordisponibles
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectordisponibles");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles = 0;
         SetDirty("Lugarsectordisponibles");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Mode ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Mode_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Modified ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Modified_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Initialized ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Initialized = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Initialized_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorId_Z" )]
      [  XmlElement( ElementName = "LugarSectorId_Z"   )]
      public short gxTpr_Lugarsectorid_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z = 0;
         SetDirty("Lugarsectorid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorName_Z" )]
      [  XmlElement( ElementName = "LugarSectorName_Z"   )]
      public string gxTpr_Lugarsectorname_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z = "";
         SetDirty("Lugarsectorname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorCantidad_Z" )]
      [  XmlElement( ElementName = "LugarSectorCantidad_Z"   )]
      public short gxTpr_Lugarsectorcantidad_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorcantidad_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z = 0;
         SetDirty("Lugarsectorcantidad_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorEstadoSector_Z" )]
      [  XmlElement( ElementName = "LugarSectorEstadoSector_Z"   )]
      public bool gxTpr_Lugarsectorestadosector_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorestadosector_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z = false;
         SetDirty("Lugarsectorestadosector_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorPrecio_Z" )]
      [  XmlElement( ElementName = "LugarSectorPrecio_Z"   )]
      public short gxTpr_Lugarsectorprecio_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorprecio_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z = 0;
         SetDirty("Lugarsectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorVendidas_Z" )]
      [  XmlElement( ElementName = "LugarSectorVendidas_Z"   )]
      public short gxTpr_Lugarsectorvendidas_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorvendidas_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z = 0;
         SetDirty("Lugarsectorvendidas_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorDisponibles_Z" )]
      [  XmlElement( ElementName = "LugarSectorDisponibles_Z"   )]
      public short gxTpr_Lugarsectordisponibles_Z
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectordisponibles_Z");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z = 0;
         SetDirty("Lugarsectordisponibles_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorVendidas_N" )]
      [  XmlElement( ElementName = "LugarSectorVendidas_N"   )]
      public short gxTpr_Lugarsectorvendidas_N
      {
         get {
            return gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N ;
         }

         set {
            gxTv_SdtEspectaculo_LugarSector_N = 0;
            gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = value;
            gxTv_SdtEspectaculo_LugarSector_Modified = 1;
            SetDirty("Lugarsectorvendidas_N");
         }

      }

      public void gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N_SetNull( )
      {
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N = 0;
         SetDirty("Lugarsectorvendidas_N");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEspectaculo_LugarSector_N = 1;
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorname = "";
         gxTv_SdtEspectaculo_LugarSector_Mode = "";
         gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEspectaculo_LugarSector_N ;
      }

      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorid ;
      private short gxTv_SdtEspectaculo_LugarSector_N ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles ;
      private short gxTv_SdtEspectaculo_LugarSector_Modified ;
      private short gxTv_SdtEspectaculo_LugarSector_Initialized ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorid_Z ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorcantidad_Z ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorprecio_Z ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_Z ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectordisponibles_Z ;
      private short gxTv_SdtEspectaculo_LugarSector_Lugarsectorvendidas_N ;
      private string gxTv_SdtEspectaculo_LugarSector_Mode ;
      private bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector ;
      private bool gxTv_SdtEspectaculo_LugarSector_Lugarsectorestadosector_Z ;
      private string gxTv_SdtEspectaculo_LugarSector_Lugarsectorname ;
      private string gxTv_SdtEspectaculo_LugarSector_Lugarsectorname_Z ;
   }

   [DataContract(Name = @"Espectaculo.LugarSector", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_LugarSector_RESTInterface : GxGenericCollectionItem<SdtEspectaculo_LugarSector>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_LugarSector_RESTInterface( ) : base()
      {
      }

      public SdtEspectaculo_LugarSector_RESTInterface( SdtEspectaculo_LugarSector psdt ) : base(psdt)
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

      [DataMember( Name = "LugarSectorEstadoSector" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Lugarsectorestadosector
      {
         get {
            return sdt.gxTpr_Lugarsectorestadosector ;
         }

         set {
            sdt.gxTpr_Lugarsectorestadosector = value;
         }

      }

      [DataMember( Name = "LugarSectorPrecio" , Order = 4 )]
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

      [DataMember( Name = "LugarSectorVendidas" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarsectorvendidas
      {
         get {
            return sdt.gxTpr_Lugarsectorvendidas ;
         }

         set {
            sdt.gxTpr_Lugarsectorvendidas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarSectorDisponibles" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarsectordisponibles
      {
         get {
            return sdt.gxTpr_Lugarsectordisponibles ;
         }

         set {
            sdt.gxTpr_Lugarsectordisponibles = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEspectaculo_LugarSector sdt
      {
         get {
            return (SdtEspectaculo_LugarSector)Sdt ;
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
            sdt = new SdtEspectaculo_LugarSector() ;
         }
      }

   }

   [DataContract(Name = @"Espectaculo.LugarSector", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_LugarSector_RESTLInterface : GxGenericCollectionItem<SdtEspectaculo_LugarSector>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_LugarSector_RESTLInterface( ) : base()
      {
      }

      public SdtEspectaculo_LugarSector_RESTLInterface( SdtEspectaculo_LugarSector psdt ) : base(psdt)
      {
      }

      public SdtEspectaculo_LugarSector sdt
      {
         get {
            return (SdtEspectaculo_LugarSector)Sdt ;
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
            sdt = new SdtEspectaculo_LugarSector() ;
         }
      }

   }

}
