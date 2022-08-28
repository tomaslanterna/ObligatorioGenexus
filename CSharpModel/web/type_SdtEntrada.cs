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
   [XmlRoot(ElementName = "Entrada" )]
   [XmlType(TypeName =  "Entrada" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtEntrada : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEntrada( )
      {
      }

      public SdtEntrada( IGxContext context )
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

      public void Load( short AV23EntradaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV23EntradaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EntradaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Entrada");
         metadata.Set("BT", "Entrada");
         metadata.Set("PK", "[ \"EntradaId\" ]");
         metadata.Set("PKAssigned", "[ \"EntradaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"EspectaculoId\",\"EspectaculoFuncionId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"EspectaculoId\",\"LugarSectorId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Espectaculoimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Entradaid_Z");
         state.Add("gxTpr_Entradafecha_Z_Nullable");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisname_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clientename_Z");
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculoname_Z");
         state.Add("gxTpr_Espectaculofecha_Z_Nullable");
         state.Add("gxTpr_Espectaculofuncionid_Z");
         state.Add("gxTpr_Espectaculofuncionname_Z");
         state.Add("gxTpr_Espectaculopaisname_Z");
         state.Add("gxTpr_Lugarname_Z");
         state.Add("gxTpr_Lugarsectorid_Z");
         state.Add("gxTpr_Lugarsectorname_Z");
         state.Add("gxTpr_Lugarsectorprecio_Z");
         state.Add("gxTpr_Lugarsectordisponibles_Z");
         state.Add("gxTpr_Tipoespectaculoname_Z");
         state.Add("gxTpr_Espectaculoimagen_gxi_Z");
         state.Add("gxTpr_Espectaculoid_N");
         state.Add("gxTpr_Lugarsectorid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEntrada sdt;
         sdt = (SdtEntrada)(source);
         gxTv_SdtEntrada_Entradaid = sdt.gxTv_SdtEntrada_Entradaid ;
         gxTv_SdtEntrada_Entradafecha = sdt.gxTv_SdtEntrada_Entradafecha ;
         gxTv_SdtEntrada_Paisid = sdt.gxTv_SdtEntrada_Paisid ;
         gxTv_SdtEntrada_Paisname = sdt.gxTv_SdtEntrada_Paisname ;
         gxTv_SdtEntrada_Clienteid = sdt.gxTv_SdtEntrada_Clienteid ;
         gxTv_SdtEntrada_Clientename = sdt.gxTv_SdtEntrada_Clientename ;
         gxTv_SdtEntrada_Espectaculoid = sdt.gxTv_SdtEntrada_Espectaculoid ;
         gxTv_SdtEntrada_Espectaculoname = sdt.gxTv_SdtEntrada_Espectaculoname ;
         gxTv_SdtEntrada_Espectaculofecha = sdt.gxTv_SdtEntrada_Espectaculofecha ;
         gxTv_SdtEntrada_Espectaculofuncionid = sdt.gxTv_SdtEntrada_Espectaculofuncionid ;
         gxTv_SdtEntrada_Espectaculofuncionname = sdt.gxTv_SdtEntrada_Espectaculofuncionname ;
         gxTv_SdtEntrada_Espectaculoimagen = sdt.gxTv_SdtEntrada_Espectaculoimagen ;
         gxTv_SdtEntrada_Espectaculoimagen_gxi = sdt.gxTv_SdtEntrada_Espectaculoimagen_gxi ;
         gxTv_SdtEntrada_Espectaculopaisname = sdt.gxTv_SdtEntrada_Espectaculopaisname ;
         gxTv_SdtEntrada_Lugarname = sdt.gxTv_SdtEntrada_Lugarname ;
         gxTv_SdtEntrada_Lugarsectorid = sdt.gxTv_SdtEntrada_Lugarsectorid ;
         gxTv_SdtEntrada_Lugarsectorname = sdt.gxTv_SdtEntrada_Lugarsectorname ;
         gxTv_SdtEntrada_Lugarsectorprecio = sdt.gxTv_SdtEntrada_Lugarsectorprecio ;
         gxTv_SdtEntrada_Lugarsectordisponibles = sdt.gxTv_SdtEntrada_Lugarsectordisponibles ;
         gxTv_SdtEntrada_Tipoespectaculoname = sdt.gxTv_SdtEntrada_Tipoespectaculoname ;
         gxTv_SdtEntrada_Mode = sdt.gxTv_SdtEntrada_Mode ;
         gxTv_SdtEntrada_Initialized = sdt.gxTv_SdtEntrada_Initialized ;
         gxTv_SdtEntrada_Entradaid_Z = sdt.gxTv_SdtEntrada_Entradaid_Z ;
         gxTv_SdtEntrada_Entradafecha_Z = sdt.gxTv_SdtEntrada_Entradafecha_Z ;
         gxTv_SdtEntrada_Paisid_Z = sdt.gxTv_SdtEntrada_Paisid_Z ;
         gxTv_SdtEntrada_Paisname_Z = sdt.gxTv_SdtEntrada_Paisname_Z ;
         gxTv_SdtEntrada_Clienteid_Z = sdt.gxTv_SdtEntrada_Clienteid_Z ;
         gxTv_SdtEntrada_Clientename_Z = sdt.gxTv_SdtEntrada_Clientename_Z ;
         gxTv_SdtEntrada_Espectaculoid_Z = sdt.gxTv_SdtEntrada_Espectaculoid_Z ;
         gxTv_SdtEntrada_Espectaculoname_Z = sdt.gxTv_SdtEntrada_Espectaculoname_Z ;
         gxTv_SdtEntrada_Espectaculofecha_Z = sdt.gxTv_SdtEntrada_Espectaculofecha_Z ;
         gxTv_SdtEntrada_Espectaculofuncionid_Z = sdt.gxTv_SdtEntrada_Espectaculofuncionid_Z ;
         gxTv_SdtEntrada_Espectaculofuncionname_Z = sdt.gxTv_SdtEntrada_Espectaculofuncionname_Z ;
         gxTv_SdtEntrada_Espectaculopaisname_Z = sdt.gxTv_SdtEntrada_Espectaculopaisname_Z ;
         gxTv_SdtEntrada_Lugarname_Z = sdt.gxTv_SdtEntrada_Lugarname_Z ;
         gxTv_SdtEntrada_Lugarsectorid_Z = sdt.gxTv_SdtEntrada_Lugarsectorid_Z ;
         gxTv_SdtEntrada_Lugarsectorname_Z = sdt.gxTv_SdtEntrada_Lugarsectorname_Z ;
         gxTv_SdtEntrada_Lugarsectorprecio_Z = sdt.gxTv_SdtEntrada_Lugarsectorprecio_Z ;
         gxTv_SdtEntrada_Lugarsectordisponibles_Z = sdt.gxTv_SdtEntrada_Lugarsectordisponibles_Z ;
         gxTv_SdtEntrada_Tipoespectaculoname_Z = sdt.gxTv_SdtEntrada_Tipoespectaculoname_Z ;
         gxTv_SdtEntrada_Espectaculoimagen_gxi_Z = sdt.gxTv_SdtEntrada_Espectaculoimagen_gxi_Z ;
         gxTv_SdtEntrada_Espectaculoid_N = sdt.gxTv_SdtEntrada_Espectaculoid_N ;
         gxTv_SdtEntrada_Lugarsectorid_N = sdt.gxTv_SdtEntrada_Lugarsectorid_N ;
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
         AddObjectProperty("EntradaId", gxTv_SdtEntrada_Entradaid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Entradafecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Entradafecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Entradafecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EntradaFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PaisId", gxTv_SdtEntrada_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisName", gxTv_SdtEntrada_Paisname, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtEntrada_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteName", gxTv_SdtEntrada_Clientename, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId", gxTv_SdtEntrada_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoId_N", gxTv_SdtEntrada_Espectaculoid_N, false, includeNonInitialized);
         AddObjectProperty("EspectaculoName", gxTv_SdtEntrada_Espectaculoname, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EspectaculoFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EspectaculoFuncionId", gxTv_SdtEntrada_Espectaculofuncionid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoFuncionName", gxTv_SdtEntrada_Espectaculofuncionname, false, includeNonInitialized);
         AddObjectProperty("EspectaculoImagen", gxTv_SdtEntrada_Espectaculoimagen, false, includeNonInitialized);
         AddObjectProperty("EspectaculoPaisName", gxTv_SdtEntrada_Espectaculopaisname, false, includeNonInitialized);
         AddObjectProperty("LugarName", gxTv_SdtEntrada_Lugarname, false, includeNonInitialized);
         AddObjectProperty("LugarSectorId", gxTv_SdtEntrada_Lugarsectorid, false, includeNonInitialized);
         AddObjectProperty("LugarSectorId_N", gxTv_SdtEntrada_Lugarsectorid_N, false, includeNonInitialized);
         AddObjectProperty("LugarSectorName", gxTv_SdtEntrada_Lugarsectorname, false, includeNonInitialized);
         AddObjectProperty("LugarSectorPrecio", gxTv_SdtEntrada_Lugarsectorprecio, false, includeNonInitialized);
         AddObjectProperty("LugarSectorDisponibles", gxTv_SdtEntrada_Lugarsectordisponibles, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoName", gxTv_SdtEntrada_Tipoespectaculoname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("EspectaculoImagen_GXI", gxTv_SdtEntrada_Espectaculoimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtEntrada_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEntrada_Initialized, false, includeNonInitialized);
            AddObjectProperty("EntradaId_Z", gxTv_SdtEntrada_Entradaid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Entradafecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Entradafecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Entradafecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EntradaFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtEntrada_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisName_Z", gxTv_SdtEntrada_Paisname_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtEntrada_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteName_Z", gxTv_SdtEntrada_Clientename_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtEntrada_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoName_Z", gxTv_SdtEntrada_Espectaculoname_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEntrada_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EspectaculoFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EspectaculoFuncionId_Z", gxTv_SdtEntrada_Espectaculofuncionid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoFuncionName_Z", gxTv_SdtEntrada_Espectaculofuncionname_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoPaisName_Z", gxTv_SdtEntrada_Espectaculopaisname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarName_Z", gxTv_SdtEntrada_Lugarname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorId_Z", gxTv_SdtEntrada_Lugarsectorid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorName_Z", gxTv_SdtEntrada_Lugarsectorname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorPrecio_Z", gxTv_SdtEntrada_Lugarsectorprecio_Z, false, includeNonInitialized);
            AddObjectProperty("LugarSectorDisponibles_Z", gxTv_SdtEntrada_Lugarsectordisponibles_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoName_Z", gxTv_SdtEntrada_Tipoespectaculoname_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoImagen_GXI_Z", gxTv_SdtEntrada_Espectaculoimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_N", gxTv_SdtEntrada_Espectaculoid_N, false, includeNonInitialized);
            AddObjectProperty("LugarSectorId_N", gxTv_SdtEntrada_Lugarsectorid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEntrada sdt )
      {
         if ( sdt.IsDirty("EntradaId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Entradaid = sdt.gxTv_SdtEntrada_Entradaid ;
         }
         if ( sdt.IsDirty("EntradaFecha") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Entradafecha = sdt.gxTv_SdtEntrada_Entradafecha ;
         }
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisid = sdt.gxTv_SdtEntrada_Paisid ;
         }
         if ( sdt.IsDirty("PaisName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisname = sdt.gxTv_SdtEntrada_Paisname ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clienteid = sdt.gxTv_SdtEntrada_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clientename = sdt.gxTv_SdtEntrada_Clientename ;
         }
         if ( sdt.IsDirty("EspectaculoId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoid = sdt.gxTv_SdtEntrada_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoname = sdt.gxTv_SdtEntrada_Espectaculoname ;
         }
         if ( sdt.IsDirty("EspectaculoFecha") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofecha = sdt.gxTv_SdtEntrada_Espectaculofecha ;
         }
         if ( sdt.IsDirty("EspectaculoFuncionId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionid = sdt.gxTv_SdtEntrada_Espectaculofuncionid ;
         }
         if ( sdt.IsDirty("EspectaculoFuncionName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionname = sdt.gxTv_SdtEntrada_Espectaculofuncionname ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoimagen = sdt.gxTv_SdtEntrada_Espectaculoimagen ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoimagen_gxi = sdt.gxTv_SdtEntrada_Espectaculoimagen_gxi ;
         }
         if ( sdt.IsDirty("EspectaculoPaisName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculopaisname = sdt.gxTv_SdtEntrada_Espectaculopaisname ;
         }
         if ( sdt.IsDirty("LugarName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarname = sdt.gxTv_SdtEntrada_Lugarname ;
         }
         if ( sdt.IsDirty("LugarSectorId") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorid = sdt.gxTv_SdtEntrada_Lugarsectorid ;
         }
         if ( sdt.IsDirty("LugarSectorName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorname = sdt.gxTv_SdtEntrada_Lugarsectorname ;
         }
         if ( sdt.IsDirty("LugarSectorPrecio") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorprecio = sdt.gxTv_SdtEntrada_Lugarsectorprecio ;
         }
         if ( sdt.IsDirty("LugarSectorDisponibles") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectordisponibles = sdt.gxTv_SdtEntrada_Lugarsectordisponibles ;
         }
         if ( sdt.IsDirty("TipoEspectaculoName") )
         {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Tipoespectaculoname = sdt.gxTv_SdtEntrada_Tipoespectaculoname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EntradaId" )]
      [  XmlElement( ElementName = "EntradaId"   )]
      public short gxTpr_Entradaid
      {
         get {
            return gxTv_SdtEntrada_Entradaid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            if ( gxTv_SdtEntrada_Entradaid != value )
            {
               gxTv_SdtEntrada_Mode = "INS";
               this.gxTv_SdtEntrada_Entradaid_Z_SetNull( );
               this.gxTv_SdtEntrada_Entradafecha_Z_SetNull( );
               this.gxTv_SdtEntrada_Paisid_Z_SetNull( );
               this.gxTv_SdtEntrada_Paisname_Z_SetNull( );
               this.gxTv_SdtEntrada_Clienteid_Z_SetNull( );
               this.gxTv_SdtEntrada_Clientename_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculoname_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculofecha_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculofuncionid_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculofuncionname_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculopaisname_Z_SetNull( );
               this.gxTv_SdtEntrada_Lugarname_Z_SetNull( );
               this.gxTv_SdtEntrada_Lugarsectorid_Z_SetNull( );
               this.gxTv_SdtEntrada_Lugarsectorname_Z_SetNull( );
               this.gxTv_SdtEntrada_Lugarsectorprecio_Z_SetNull( );
               this.gxTv_SdtEntrada_Lugarsectordisponibles_Z_SetNull( );
               this.gxTv_SdtEntrada_Tipoespectaculoname_Z_SetNull( );
               this.gxTv_SdtEntrada_Espectaculoimagen_gxi_Z_SetNull( );
            }
            gxTv_SdtEntrada_Entradaid = value;
            SetDirty("Entradaid");
         }

      }

      [  SoapElement( ElementName = "EntradaFecha" )]
      [  XmlElement( ElementName = "EntradaFecha"  , IsNullable=true )]
      public string gxTpr_Entradafecha_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Entradafecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Entradafecha).value ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Entradafecha = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Entradafecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Entradafecha
      {
         get {
            return gxTv_SdtEntrada_Entradafecha ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Entradafecha = value;
            SetDirty("Entradafecha");
         }

      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtEntrada_Paisid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisName" )]
      [  XmlElement( ElementName = "PaisName"   )]
      public string gxTpr_Paisname
      {
         get {
            return gxTv_SdtEntrada_Paisname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisname = value;
            SetDirty("Paisname");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public short gxTpr_Clienteid
      {
         get {
            return gxTv_SdtEntrada_Clienteid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      [  SoapElement( ElementName = "ClienteName" )]
      [  XmlElement( ElementName = "ClienteName"   )]
      public string gxTpr_Clientename
      {
         get {
            return gxTv_SdtEntrada_Clientename ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clientename = value;
            SetDirty("Clientename");
         }

      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtEntrada_Espectaculoid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoName" )]
      [  XmlElement( ElementName = "EspectaculoName"   )]
      public string gxTpr_Espectaculoname
      {
         get {
            return gxTv_SdtEntrada_Espectaculoname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoname = value;
            SetDirty("Espectaculoname");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFecha" )]
      [  XmlElement( ElementName = "EspectaculoFecha"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Espectaculofecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Espectaculofecha).value ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Espectaculofecha = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Espectaculofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha
      {
         get {
            return gxTv_SdtEntrada_Espectaculofecha ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofecha = value;
            SetDirty("Espectaculofecha");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFuncionId" )]
      [  XmlElement( ElementName = "EspectaculoFuncionId"   )]
      public short gxTpr_Espectaculofuncionid
      {
         get {
            return gxTv_SdtEntrada_Espectaculofuncionid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionid = value;
            SetDirty("Espectaculofuncionid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFuncionName" )]
      [  XmlElement( ElementName = "EspectaculoFuncionName"   )]
      public string gxTpr_Espectaculofuncionname
      {
         get {
            return gxTv_SdtEntrada_Espectaculofuncionname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionname = value;
            SetDirty("Espectaculofuncionname");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen" )]
      [  XmlElement( ElementName = "EspectaculoImagen"   )]
      [GxUpload()]
      public string gxTpr_Espectaculoimagen
      {
         get {
            return gxTv_SdtEntrada_Espectaculoimagen ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoimagen = value;
            SetDirty("Espectaculoimagen");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI"   )]
      public string gxTpr_Espectaculoimagen_gxi
      {
         get {
            return gxTv_SdtEntrada_Espectaculoimagen_gxi ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoimagen_gxi = value;
            SetDirty("Espectaculoimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "EspectaculoPaisName" )]
      [  XmlElement( ElementName = "EspectaculoPaisName"   )]
      public string gxTpr_Espectaculopaisname
      {
         get {
            return gxTv_SdtEntrada_Espectaculopaisname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculopaisname = value;
            SetDirty("Espectaculopaisname");
         }

      }

      [  SoapElement( ElementName = "LugarName" )]
      [  XmlElement( ElementName = "LugarName"   )]
      public string gxTpr_Lugarname
      {
         get {
            return gxTv_SdtEntrada_Lugarname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarname = value;
            SetDirty("Lugarname");
         }

      }

      [  SoapElement( ElementName = "LugarSectorId" )]
      [  XmlElement( ElementName = "LugarSectorId"   )]
      public short gxTpr_Lugarsectorid
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorid ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorid = value;
            SetDirty("Lugarsectorid");
         }

      }

      [  SoapElement( ElementName = "LugarSectorName" )]
      [  XmlElement( ElementName = "LugarSectorName"   )]
      public string gxTpr_Lugarsectorname
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorname = value;
            SetDirty("Lugarsectorname");
         }

      }

      [  SoapElement( ElementName = "LugarSectorPrecio" )]
      [  XmlElement( ElementName = "LugarSectorPrecio"   )]
      public short gxTpr_Lugarsectorprecio
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorprecio ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorprecio = value;
            SetDirty("Lugarsectorprecio");
         }

      }

      [  SoapElement( ElementName = "LugarSectorDisponibles" )]
      [  XmlElement( ElementName = "LugarSectorDisponibles"   )]
      public short gxTpr_Lugarsectordisponibles
      {
         get {
            return gxTv_SdtEntrada_Lugarsectordisponibles ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectordisponibles = value;
            SetDirty("Lugarsectordisponibles");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectordisponibles_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectordisponibles = 0;
         SetDirty("Lugarsectordisponibles");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectordisponibles_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoName" )]
      [  XmlElement( ElementName = "TipoEspectaculoName"   )]
      public string gxTpr_Tipoespectaculoname
      {
         get {
            return gxTv_SdtEntrada_Tipoespectaculoname ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Tipoespectaculoname = value;
            SetDirty("Tipoespectaculoname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEntrada_Mode ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEntrada_Mode_SetNull( )
      {
         gxTv_SdtEntrada_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEntrada_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEntrada_Initialized ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEntrada_Initialized_SetNull( )
      {
         gxTv_SdtEntrada_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEntrada_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EntradaId_Z" )]
      [  XmlElement( ElementName = "EntradaId_Z"   )]
      public short gxTpr_Entradaid_Z
      {
         get {
            return gxTv_SdtEntrada_Entradaid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Entradaid_Z = value;
            SetDirty("Entradaid_Z");
         }

      }

      public void gxTv_SdtEntrada_Entradaid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Entradaid_Z = 0;
         SetDirty("Entradaid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Entradaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EntradaFecha_Z" )]
      [  XmlElement( ElementName = "EntradaFecha_Z"  , IsNullable=true )]
      public string gxTpr_Entradafecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Entradafecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Entradafecha_Z).value ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Entradafecha_Z = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Entradafecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Entradafecha_Z
      {
         get {
            return gxTv_SdtEntrada_Entradafecha_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Entradafecha_Z = value;
            SetDirty("Entradafecha_Z");
         }

      }

      public void gxTv_SdtEntrada_Entradafecha_Z_SetNull( )
      {
         gxTv_SdtEntrada_Entradafecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Entradafecha_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Entradafecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtEntrada_Paisid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtEntrada_Paisid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisName_Z" )]
      [  XmlElement( ElementName = "PaisName_Z"   )]
      public string gxTpr_Paisname_Z
      {
         get {
            return gxTv_SdtEntrada_Paisname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Paisname_Z = value;
            SetDirty("Paisname_Z");
         }

      }

      public void gxTv_SdtEntrada_Paisname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Paisname_Z = "";
         SetDirty("Paisname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Paisname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public short gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtEntrada_Clienteid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtEntrada_Clienteid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteName_Z" )]
      [  XmlElement( ElementName = "ClienteName_Z"   )]
      public string gxTpr_Clientename_Z
      {
         get {
            return gxTv_SdtEntrada_Clientename_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Clientename_Z = value;
            SetDirty("Clientename_Z");
         }

      }

      public void gxTv_SdtEntrada_Clientename_Z_SetNull( )
      {
         gxTv_SdtEntrada_Clientename_Z = "";
         SetDirty("Clientename_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Clientename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculoid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoName_Z" )]
      [  XmlElement( ElementName = "EspectaculoName_Z"   )]
      public string gxTpr_Espectaculoname_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculoname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoname_Z = value;
            SetDirty("Espectaculoname_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculoname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculoname_Z = "";
         SetDirty("Espectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFecha_Z" )]
      [  XmlElement( ElementName = "EspectaculoFecha_Z"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtEntrada_Espectaculofecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEntrada_Espectaculofecha_Z).value ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculofecha_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofecha_Z = value;
            SetDirty("Espectaculofecha_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculofecha_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Espectaculofecha_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionId_Z" )]
      [  XmlElement( ElementName = "EspectaculoFuncionId_Z"   )]
      public short gxTpr_Espectaculofuncionid_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculofuncionid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionid_Z = value;
            SetDirty("Espectaculofuncionid_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculofuncionid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculofuncionid_Z = 0;
         SetDirty("Espectaculofuncionid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculofuncionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncionName_Z" )]
      [  XmlElement( ElementName = "EspectaculoFuncionName_Z"   )]
      public string gxTpr_Espectaculofuncionname_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculofuncionname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculofuncionname_Z = value;
            SetDirty("Espectaculofuncionname_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculofuncionname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculofuncionname_Z = "";
         SetDirty("Espectaculofuncionname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculofuncionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoPaisName_Z" )]
      [  XmlElement( ElementName = "EspectaculoPaisName_Z"   )]
      public string gxTpr_Espectaculopaisname_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculopaisname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculopaisname_Z = value;
            SetDirty("Espectaculopaisname_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculopaisname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculopaisname_Z = "";
         SetDirty("Espectaculopaisname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculopaisname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarName_Z" )]
      [  XmlElement( ElementName = "LugarName_Z"   )]
      public string gxTpr_Lugarname_Z
      {
         get {
            return gxTv_SdtEntrada_Lugarname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarname_Z = value;
            SetDirty("Lugarname_Z");
         }

      }

      public void gxTv_SdtEntrada_Lugarname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Lugarname_Z = "";
         SetDirty("Lugarname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorId_Z" )]
      [  XmlElement( ElementName = "LugarSectorId_Z"   )]
      public short gxTpr_Lugarsectorid_Z
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorid_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorid_Z = value;
            SetDirty("Lugarsectorid_Z");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectorid_Z_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectorid_Z = 0;
         SetDirty("Lugarsectorid_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorName_Z" )]
      [  XmlElement( ElementName = "LugarSectorName_Z"   )]
      public string gxTpr_Lugarsectorname_Z
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorname_Z = value;
            SetDirty("Lugarsectorname_Z");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectorname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectorname_Z = "";
         SetDirty("Lugarsectorname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectorname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorPrecio_Z" )]
      [  XmlElement( ElementName = "LugarSectorPrecio_Z"   )]
      public short gxTpr_Lugarsectorprecio_Z
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorprecio_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorprecio_Z = value;
            SetDirty("Lugarsectorprecio_Z");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectorprecio_Z_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectorprecio_Z = 0;
         SetDirty("Lugarsectorprecio_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectorprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorDisponibles_Z" )]
      [  XmlElement( ElementName = "LugarSectorDisponibles_Z"   )]
      public short gxTpr_Lugarsectordisponibles_Z
      {
         get {
            return gxTv_SdtEntrada_Lugarsectordisponibles_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectordisponibles_Z = value;
            SetDirty("Lugarsectordisponibles_Z");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectordisponibles_Z_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectordisponibles_Z = 0;
         SetDirty("Lugarsectordisponibles_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectordisponibles_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoName_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoName_Z"   )]
      public string gxTpr_Tipoespectaculoname_Z
      {
         get {
            return gxTv_SdtEntrada_Tipoespectaculoname_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Tipoespectaculoname_Z = value;
            SetDirty("Tipoespectaculoname_Z");
         }

      }

      public void gxTv_SdtEntrada_Tipoespectaculoname_Z_SetNull( )
      {
         gxTv_SdtEntrada_Tipoespectaculoname_Z = "";
         SetDirty("Tipoespectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Tipoespectaculoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI_Z" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI_Z"   )]
      public string gxTpr_Espectaculoimagen_gxi_Z
      {
         get {
            return gxTv_SdtEntrada_Espectaculoimagen_gxi_Z ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoimagen_gxi_Z = value;
            SetDirty("Espectaculoimagen_gxi_Z");
         }

      }

      public void gxTv_SdtEntrada_Espectaculoimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculoimagen_gxi_Z = "";
         SetDirty("Espectaculoimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculoimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_N" )]
      [  XmlElement( ElementName = "EspectaculoId_N"   )]
      public short gxTpr_Espectaculoid_N
      {
         get {
            return gxTv_SdtEntrada_Espectaculoid_N ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Espectaculoid_N = value;
            SetDirty("Espectaculoid_N");
         }

      }

      public void gxTv_SdtEntrada_Espectaculoid_N_SetNull( )
      {
         gxTv_SdtEntrada_Espectaculoid_N = 0;
         SetDirty("Espectaculoid_N");
         return  ;
      }

      public bool gxTv_SdtEntrada_Espectaculoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarSectorId_N" )]
      [  XmlElement( ElementName = "LugarSectorId_N"   )]
      public short gxTpr_Lugarsectorid_N
      {
         get {
            return gxTv_SdtEntrada_Lugarsectorid_N ;
         }

         set {
            gxTv_SdtEntrada_N = 0;
            gxTv_SdtEntrada_Lugarsectorid_N = value;
            SetDirty("Lugarsectorid_N");
         }

      }

      public void gxTv_SdtEntrada_Lugarsectorid_N_SetNull( )
      {
         gxTv_SdtEntrada_Lugarsectorid_N = 0;
         SetDirty("Lugarsectorid_N");
         return  ;
      }

      public bool gxTv_SdtEntrada_Lugarsectorid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEntrada_N = 1;
         gxTv_SdtEntrada_Entradafecha = DateTime.MinValue;
         gxTv_SdtEntrada_Paisname = "";
         gxTv_SdtEntrada_Clientename = "";
         gxTv_SdtEntrada_Espectaculoname = "";
         gxTv_SdtEntrada_Espectaculofecha = DateTime.MinValue;
         gxTv_SdtEntrada_Espectaculofuncionname = "";
         gxTv_SdtEntrada_Espectaculoimagen = "";
         gxTv_SdtEntrada_Espectaculoimagen_gxi = "";
         gxTv_SdtEntrada_Espectaculopaisname = "";
         gxTv_SdtEntrada_Lugarname = "";
         gxTv_SdtEntrada_Lugarsectorname = "";
         gxTv_SdtEntrada_Tipoespectaculoname = "";
         gxTv_SdtEntrada_Mode = "";
         gxTv_SdtEntrada_Entradafecha_Z = DateTime.MinValue;
         gxTv_SdtEntrada_Paisname_Z = "";
         gxTv_SdtEntrada_Clientename_Z = "";
         gxTv_SdtEntrada_Espectaculoname_Z = "";
         gxTv_SdtEntrada_Espectaculofecha_Z = DateTime.MinValue;
         gxTv_SdtEntrada_Espectaculofuncionname_Z = "";
         gxTv_SdtEntrada_Espectaculopaisname_Z = "";
         gxTv_SdtEntrada_Lugarname_Z = "";
         gxTv_SdtEntrada_Lugarsectorname_Z = "";
         gxTv_SdtEntrada_Tipoespectaculoname_Z = "";
         gxTv_SdtEntrada_Espectaculoimagen_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "entrada", "GeneXus.Programs.entrada_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEntrada_N ;
      }

      private short gxTv_SdtEntrada_Entradaid ;
      private short gxTv_SdtEntrada_N ;
      private short gxTv_SdtEntrada_Paisid ;
      private short gxTv_SdtEntrada_Clienteid ;
      private short gxTv_SdtEntrada_Espectaculoid ;
      private short gxTv_SdtEntrada_Espectaculofuncionid ;
      private short gxTv_SdtEntrada_Lugarsectorid ;
      private short gxTv_SdtEntrada_Lugarsectorprecio ;
      private short gxTv_SdtEntrada_Lugarsectordisponibles ;
      private short gxTv_SdtEntrada_Initialized ;
      private short gxTv_SdtEntrada_Entradaid_Z ;
      private short gxTv_SdtEntrada_Paisid_Z ;
      private short gxTv_SdtEntrada_Clienteid_Z ;
      private short gxTv_SdtEntrada_Espectaculoid_Z ;
      private short gxTv_SdtEntrada_Espectaculofuncionid_Z ;
      private short gxTv_SdtEntrada_Lugarsectorid_Z ;
      private short gxTv_SdtEntrada_Lugarsectorprecio_Z ;
      private short gxTv_SdtEntrada_Lugarsectordisponibles_Z ;
      private short gxTv_SdtEntrada_Espectaculoid_N ;
      private short gxTv_SdtEntrada_Lugarsectorid_N ;
      private string gxTv_SdtEntrada_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEntrada_Entradafecha ;
      private DateTime gxTv_SdtEntrada_Espectaculofecha ;
      private DateTime gxTv_SdtEntrada_Entradafecha_Z ;
      private DateTime gxTv_SdtEntrada_Espectaculofecha_Z ;
      private string gxTv_SdtEntrada_Paisname ;
      private string gxTv_SdtEntrada_Clientename ;
      private string gxTv_SdtEntrada_Espectaculoname ;
      private string gxTv_SdtEntrada_Espectaculofuncionname ;
      private string gxTv_SdtEntrada_Espectaculoimagen_gxi ;
      private string gxTv_SdtEntrada_Espectaculopaisname ;
      private string gxTv_SdtEntrada_Lugarname ;
      private string gxTv_SdtEntrada_Lugarsectorname ;
      private string gxTv_SdtEntrada_Tipoespectaculoname ;
      private string gxTv_SdtEntrada_Paisname_Z ;
      private string gxTv_SdtEntrada_Clientename_Z ;
      private string gxTv_SdtEntrada_Espectaculoname_Z ;
      private string gxTv_SdtEntrada_Espectaculofuncionname_Z ;
      private string gxTv_SdtEntrada_Espectaculopaisname_Z ;
      private string gxTv_SdtEntrada_Lugarname_Z ;
      private string gxTv_SdtEntrada_Lugarsectorname_Z ;
      private string gxTv_SdtEntrada_Tipoespectaculoname_Z ;
      private string gxTv_SdtEntrada_Espectaculoimagen_gxi_Z ;
      private string gxTv_SdtEntrada_Espectaculoimagen ;
   }

   [DataContract(Name = @"Entrada", Namespace = "Obligatorio1v2")]
   public class SdtEntrada_RESTInterface : GxGenericCollectionItem<SdtEntrada>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEntrada_RESTInterface( ) : base()
      {
      }

      public SdtEntrada_RESTInterface( SdtEntrada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EntradaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Entradaid
      {
         get {
            return sdt.gxTpr_Entradaid ;
         }

         set {
            sdt.gxTpr_Entradaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EntradaFecha" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Entradafecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Entradafecha) ;
         }

         set {
            sdt.gxTpr_Entradafecha = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PaisId" , Order = 2 )]
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

      [DataMember( Name = "PaisName" , Order = 3 )]
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

      [DataMember( Name = "ClienteId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clienteid
      {
         get {
            return sdt.gxTpr_Clienteid ;
         }

         set {
            sdt.gxTpr_Clienteid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Clientename
      {
         get {
            return sdt.gxTpr_Clientename ;
         }

         set {
            sdt.gxTpr_Clientename = value;
         }

      }

      [DataMember( Name = "EspectaculoId" , Order = 6 )]
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

      [DataMember( Name = "EspectaculoName" , Order = 7 )]
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

      [DataMember( Name = "EspectaculoFecha" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Espectaculofecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Espectaculofecha) ;
         }

         set {
            sdt.gxTpr_Espectaculofecha = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "EspectaculoFuncionId" , Order = 9 )]
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

      [DataMember( Name = "EspectaculoFuncionName" , Order = 10 )]
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

      [DataMember( Name = "EspectaculoImagen" , Order = 11 )]
      [GxUpload()]
      public string gxTpr_Espectaculoimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Espectaculoimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Espectaculoimagen) : StringUtil.RTrim( sdt.gxTpr_Espectaculoimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Espectaculoimagen = value;
         }

      }

      [DataMember( Name = "EspectaculoPaisName" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Espectaculopaisname
      {
         get {
            return sdt.gxTpr_Espectaculopaisname ;
         }

         set {
            sdt.gxTpr_Espectaculopaisname = value;
         }

      }

      [DataMember( Name = "LugarName" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Lugarname
      {
         get {
            return sdt.gxTpr_Lugarname ;
         }

         set {
            sdt.gxTpr_Lugarname = value;
         }

      }

      [DataMember( Name = "LugarSectorId" , Order = 14 )]
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

      [DataMember( Name = "LugarSectorName" , Order = 15 )]
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

      [DataMember( Name = "LugarSectorPrecio" , Order = 16 )]
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

      [DataMember( Name = "LugarSectorDisponibles" , Order = 17 )]
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

      [DataMember( Name = "TipoEspectaculoName" , Order = 18 )]
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

      public SdtEntrada sdt
      {
         get {
            return (SdtEntrada)Sdt ;
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
            sdt = new SdtEntrada() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 19 )]
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

   [DataContract(Name = @"Entrada", Namespace = "Obligatorio1v2")]
   public class SdtEntrada_RESTLInterface : GxGenericCollectionItem<SdtEntrada>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEntrada_RESTLInterface( ) : base()
      {
      }

      public SdtEntrada_RESTLInterface( SdtEntrada psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EntradaFecha" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Entradafecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Entradafecha) ;
         }

         set {
            sdt.gxTpr_Entradafecha = DateTimeUtil.CToD2( value);
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

      public SdtEntrada sdt
      {
         get {
            return (SdtEntrada)Sdt ;
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
            sdt = new SdtEntrada() ;
         }
      }

   }

}
