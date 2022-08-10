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
   [XmlRoot(ElementName = "Espectaculo" )]
   [XmlType(TypeName =  "Espectaculo" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtEspectaculo : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo( )
      {
      }

      public SdtEspectaculo( IGxContext context )
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

      public void Load( short AV1EspectaculoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1EspectaculoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EspectaculoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Espectaculo");
         metadata.Set("BT", "Espectaculo");
         metadata.Set("PK", "[ \"EspectaculoId\" ]");
         metadata.Set("PKAssigned", "[ \"EspectaculoId\" ]");
         metadata.Set("Levels", "[ \"EspectaculoFuncion\",\"LugarSector\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LugarId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TipoEspectaculoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Espectaculoid_Z");
         state.Add("gxTpr_Espectaculoname_Z");
         state.Add("gxTpr_Espectaculofecha_Z_Nullable");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisname_Z");
         state.Add("gxTpr_Lugarid_Z");
         state.Add("gxTpr_Lugarname_Z");
         state.Add("gxTpr_Tipoespectaculoid_Z");
         state.Add("gxTpr_Tipoespectaculoname_Z");
         state.Add("gxTpr_Espectaculoimagen_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEspectaculo sdt;
         sdt = (SdtEspectaculo)(source);
         gxTv_SdtEspectaculo_Espectaculoid = sdt.gxTv_SdtEspectaculo_Espectaculoid ;
         gxTv_SdtEspectaculo_Espectaculoname = sdt.gxTv_SdtEspectaculo_Espectaculoname ;
         gxTv_SdtEspectaculo_Espectaculofecha = sdt.gxTv_SdtEspectaculo_Espectaculofecha ;
         gxTv_SdtEspectaculo_Paisid = sdt.gxTv_SdtEspectaculo_Paisid ;
         gxTv_SdtEspectaculo_Paisname = sdt.gxTv_SdtEspectaculo_Paisname ;
         gxTv_SdtEspectaculo_Lugarid = sdt.gxTv_SdtEspectaculo_Lugarid ;
         gxTv_SdtEspectaculo_Lugarname = sdt.gxTv_SdtEspectaculo_Lugarname ;
         gxTv_SdtEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid ;
         gxTv_SdtEspectaculo_Tipoespectaculoname = sdt.gxTv_SdtEspectaculo_Tipoespectaculoname ;
         gxTv_SdtEspectaculo_Espectaculoimagen = sdt.gxTv_SdtEspectaculo_Espectaculoimagen ;
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         gxTv_SdtEspectaculo_Lugarsector = sdt.gxTv_SdtEspectaculo_Lugarsector ;
         gxTv_SdtEspectaculo_Espectaculofuncion = sdt.gxTv_SdtEspectaculo_Espectaculofuncion ;
         gxTv_SdtEspectaculo_Mode = sdt.gxTv_SdtEspectaculo_Mode ;
         gxTv_SdtEspectaculo_Initialized = sdt.gxTv_SdtEspectaculo_Initialized ;
         gxTv_SdtEspectaculo_Espectaculoid_Z = sdt.gxTv_SdtEspectaculo_Espectaculoid_Z ;
         gxTv_SdtEspectaculo_Espectaculoname_Z = sdt.gxTv_SdtEspectaculo_Espectaculoname_Z ;
         gxTv_SdtEspectaculo_Espectaculofecha_Z = sdt.gxTv_SdtEspectaculo_Espectaculofecha_Z ;
         gxTv_SdtEspectaculo_Paisid_Z = sdt.gxTv_SdtEspectaculo_Paisid_Z ;
         gxTv_SdtEspectaculo_Paisname_Z = sdt.gxTv_SdtEspectaculo_Paisname_Z ;
         gxTv_SdtEspectaculo_Lugarid_Z = sdt.gxTv_SdtEspectaculo_Lugarid_Z ;
         gxTv_SdtEspectaculo_Lugarname_Z = sdt.gxTv_SdtEspectaculo_Lugarname_Z ;
         gxTv_SdtEspectaculo_Tipoespectaculoid_Z = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
         gxTv_SdtEspectaculo_Tipoespectaculoname_Z = sdt.gxTv_SdtEspectaculo_Tipoespectaculoname_Z ;
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
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
         AddObjectProperty("EspectaculoId", gxTv_SdtEspectaculo_Espectaculoid, false, includeNonInitialized);
         AddObjectProperty("EspectaculoName", gxTv_SdtEspectaculo_Espectaculoname, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEspectaculo_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEspectaculo_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEspectaculo_Espectaculofecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EspectaculoFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PaisId", gxTv_SdtEspectaculo_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisName", gxTv_SdtEspectaculo_Paisname, false, includeNonInitialized);
         AddObjectProperty("LugarId", gxTv_SdtEspectaculo_Lugarid, false, includeNonInitialized);
         AddObjectProperty("LugarName", gxTv_SdtEspectaculo_Lugarname, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoId", gxTv_SdtEspectaculo_Tipoespectaculoid, false, includeNonInitialized);
         AddObjectProperty("TipoEspectaculoName", gxTv_SdtEspectaculo_Tipoespectaculoname, false, includeNonInitialized);
         AddObjectProperty("EspectaculoImagen", gxTv_SdtEspectaculo_Espectaculoimagen, false, includeNonInitialized);
         if ( gxTv_SdtEspectaculo_Lugarsector != null )
         {
            AddObjectProperty("LugarSector", gxTv_SdtEspectaculo_Lugarsector, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtEspectaculo_Espectaculofuncion != null )
         {
            AddObjectProperty("EspectaculoFuncion", gxTv_SdtEspectaculo_Espectaculofuncion, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("EspectaculoImagen_GXI", gxTv_SdtEspectaculo_Espectaculoimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtEspectaculo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEspectaculo_Initialized, false, includeNonInitialized);
            AddObjectProperty("EspectaculoId_Z", gxTv_SdtEspectaculo_Espectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoName_Z", gxTv_SdtEspectaculo_Espectaculoname_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtEspectaculo_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtEspectaculo_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtEspectaculo_Espectaculofecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EspectaculoFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtEspectaculo_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisName_Z", gxTv_SdtEspectaculo_Paisname_Z, false, includeNonInitialized);
            AddObjectProperty("LugarId_Z", gxTv_SdtEspectaculo_Lugarid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarName_Z", gxTv_SdtEspectaculo_Lugarname_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoId_Z", gxTv_SdtEspectaculo_Tipoespectaculoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEspectaculoName_Z", gxTv_SdtEspectaculo_Tipoespectaculoname_Z, false, includeNonInitialized);
            AddObjectProperty("EspectaculoImagen_GXI_Z", gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEspectaculo sdt )
      {
         if ( sdt.IsDirty("EspectaculoId") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoid = sdt.gxTv_SdtEspectaculo_Espectaculoid ;
         }
         if ( sdt.IsDirty("EspectaculoName") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoname = sdt.gxTv_SdtEspectaculo_Espectaculoname ;
         }
         if ( sdt.IsDirty("EspectaculoFecha") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculofecha = sdt.gxTv_SdtEspectaculo_Espectaculofecha ;
         }
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisid = sdt.gxTv_SdtEspectaculo_Paisid ;
         }
         if ( sdt.IsDirty("PaisName") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisname = sdt.gxTv_SdtEspectaculo_Paisname ;
         }
         if ( sdt.IsDirty("LugarId") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarid = sdt.gxTv_SdtEspectaculo_Lugarid ;
         }
         if ( sdt.IsDirty("LugarName") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarname = sdt.gxTv_SdtEspectaculo_Lugarname ;
         }
         if ( sdt.IsDirty("TipoEspectaculoId") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid = sdt.gxTv_SdtEspectaculo_Tipoespectaculoid ;
         }
         if ( sdt.IsDirty("TipoEspectaculoName") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoname = sdt.gxTv_SdtEspectaculo_Tipoespectaculoname ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen = sdt.gxTv_SdtEspectaculo_Espectaculoimagen ;
         }
         if ( sdt.IsDirty("EspectaculoImagen") )
         {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi = sdt.gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         }
         if ( gxTv_SdtEspectaculo_Lugarsector != null )
         {
            GXBCLevelCollection<SdtEspectaculo_LugarSector> newCollectionLugarsector = sdt.gxTpr_Lugarsector;
            SdtEspectaculo_LugarSector currItemLugarsector;
            SdtEspectaculo_LugarSector newItemLugarsector;
            short idx = 1;
            while ( idx <= newCollectionLugarsector.Count )
            {
               newItemLugarsector = ((SdtEspectaculo_LugarSector)newCollectionLugarsector.Item(idx));
               currItemLugarsector = gxTv_SdtEspectaculo_Lugarsector.GetByKey(newItemLugarsector.gxTpr_Lugarsectorid);
               if ( StringUtil.StrCmp(currItemLugarsector.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemLugarsector.UpdateDirties(newItemLugarsector);
                  if ( StringUtil.StrCmp(newItemLugarsector.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemLugarsector.gxTpr_Mode = "DLT";
                  }
                  currItemLugarsector.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEspectaculo_Lugarsector.Add(newItemLugarsector, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtEspectaculo_Espectaculofuncion != null )
         {
            GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion> newCollectionEspectaculofuncion = sdt.gxTpr_Espectaculofuncion;
            SdtEspectaculo_EspectaculoFuncion currItemEspectaculofuncion;
            SdtEspectaculo_EspectaculoFuncion newItemEspectaculofuncion;
            short idx = 1;
            while ( idx <= newCollectionEspectaculofuncion.Count )
            {
               newItemEspectaculofuncion = ((SdtEspectaculo_EspectaculoFuncion)newCollectionEspectaculofuncion.Item(idx));
               currItemEspectaculofuncion = gxTv_SdtEspectaculo_Espectaculofuncion.GetByKey(newItemEspectaculofuncion.gxTpr_Espectaculofuncionid);
               if ( StringUtil.StrCmp(currItemEspectaculofuncion.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemEspectaculofuncion.UpdateDirties(newItemEspectaculofuncion);
                  if ( StringUtil.StrCmp(newItemEspectaculofuncion.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemEspectaculofuncion.gxTpr_Mode = "DLT";
                  }
                  currItemEspectaculofuncion.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtEspectaculo_Espectaculofuncion.Add(newItemEspectaculofuncion, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "EspectaculoId" )]
      [  XmlElement( ElementName = "EspectaculoId"   )]
      public short gxTpr_Espectaculoid
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoid ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            if ( gxTv_SdtEspectaculo_Espectaculoid != value )
            {
               gxTv_SdtEspectaculo_Mode = "INS";
               this.gxTv_SdtEspectaculo_Espectaculoid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculoname_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculofecha_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Paisid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Paisname_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Lugarid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Lugarname_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Tipoespectaculoid_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Tipoespectaculoname_Z_SetNull( );
               this.gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_SetNull( );
               if ( gxTv_SdtEspectaculo_Lugarsector != null )
               {
                  GXBCLevelCollection<SdtEspectaculo_LugarSector> collectionLugarsector = gxTv_SdtEspectaculo_Lugarsector;
                  SdtEspectaculo_LugarSector currItemLugarsector;
                  short idx = 1;
                  while ( idx <= collectionLugarsector.Count )
                  {
                     currItemLugarsector = ((SdtEspectaculo_LugarSector)collectionLugarsector.Item(idx));
                     currItemLugarsector.gxTpr_Mode = "INS";
                     currItemLugarsector.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtEspectaculo_Espectaculofuncion != null )
               {
                  GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion> collectionEspectaculofuncion = gxTv_SdtEspectaculo_Espectaculofuncion;
                  SdtEspectaculo_EspectaculoFuncion currItemEspectaculofuncion;
                  short idx = 1;
                  while ( idx <= collectionEspectaculofuncion.Count )
                  {
                     currItemEspectaculofuncion = ((SdtEspectaculo_EspectaculoFuncion)collectionEspectaculofuncion.Item(idx));
                     currItemEspectaculofuncion.gxTpr_Mode = "INS";
                     currItemEspectaculofuncion.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtEspectaculo_Espectaculoid = value;
            SetDirty("Espectaculoid");
         }

      }

      [  SoapElement( ElementName = "EspectaculoName" )]
      [  XmlElement( ElementName = "EspectaculoName"   )]
      public string gxTpr_Espectaculoname
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoname ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoname = value;
            SetDirty("Espectaculoname");
         }

      }

      [  SoapElement( ElementName = "EspectaculoFecha" )]
      [  XmlElement( ElementName = "EspectaculoFecha"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Nullable
      {
         get {
            if ( gxTv_SdtEspectaculo_Espectaculofecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEspectaculo_Espectaculofecha).value ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEspectaculo_Espectaculofecha = DateTime.MinValue;
            else
               gxTv_SdtEspectaculo_Espectaculofecha = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculofecha ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculofecha = value;
            SetDirty("Espectaculofecha");
         }

      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtEspectaculo_Paisid ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisName" )]
      [  XmlElement( ElementName = "PaisName"   )]
      public string gxTpr_Paisname
      {
         get {
            return gxTv_SdtEspectaculo_Paisname ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisname = value;
            SetDirty("Paisname");
         }

      }

      [  SoapElement( ElementName = "LugarId" )]
      [  XmlElement( ElementName = "LugarId"   )]
      public short gxTpr_Lugarid
      {
         get {
            return gxTv_SdtEspectaculo_Lugarid ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarid = value;
            SetDirty("Lugarid");
         }

      }

      [  SoapElement( ElementName = "LugarName" )]
      [  XmlElement( ElementName = "LugarName"   )]
      public string gxTpr_Lugarname
      {
         get {
            return gxTv_SdtEspectaculo_Lugarname ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarname = value;
            SetDirty("Lugarname");
         }

      }

      [  SoapElement( ElementName = "TipoEspectaculoId" )]
      [  XmlElement( ElementName = "TipoEspectaculoId"   )]
      public short gxTpr_Tipoespectaculoid
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoid ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid = value;
            SetDirty("Tipoespectaculoid");
         }

      }

      [  SoapElement( ElementName = "TipoEspectaculoName" )]
      [  XmlElement( ElementName = "TipoEspectaculoName"   )]
      public string gxTpr_Tipoespectaculoname
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoname ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoname = value;
            SetDirty("Tipoespectaculoname");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen" )]
      [  XmlElement( ElementName = "EspectaculoImagen"   )]
      [GxUpload()]
      public string gxTpr_Espectaculoimagen
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen = value;
            SetDirty("Espectaculoimagen");
         }

      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI"   )]
      public string gxTpr_Espectaculoimagen_gxi
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi = value;
            SetDirty("Espectaculoimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "LugarSector" )]
      [  XmlArray( ElementName = "LugarSector"  )]
      [  XmlArrayItemAttribute( ElementName= "Espectaculo.LugarSector"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEspectaculo_LugarSector> gxTpr_Lugarsector_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEspectaculo_Lugarsector == null )
            {
               gxTv_SdtEspectaculo_Lugarsector = new GXBCLevelCollection<SdtEspectaculo_LugarSector>( context, "Espectaculo.LugarSector", "Obligatorio1v2");
            }
            return gxTv_SdtEspectaculo_Lugarsector ;
         }

         set {
            if ( gxTv_SdtEspectaculo_Lugarsector == null )
            {
               gxTv_SdtEspectaculo_Lugarsector = new GXBCLevelCollection<SdtEspectaculo_LugarSector>( context, "Espectaculo.LugarSector", "Obligatorio1v2");
            }
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarsector = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtEspectaculo_LugarSector> gxTpr_Lugarsector
      {
         get {
            if ( gxTv_SdtEspectaculo_Lugarsector == null )
            {
               gxTv_SdtEspectaculo_Lugarsector = new GXBCLevelCollection<SdtEspectaculo_LugarSector>( context, "Espectaculo.LugarSector", "Obligatorio1v2");
            }
            gxTv_SdtEspectaculo_N = 0;
            return gxTv_SdtEspectaculo_Lugarsector ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarsector = value;
            SetDirty("Lugarsector");
         }

      }

      public void gxTv_SdtEspectaculo_Lugarsector_SetNull( )
      {
         gxTv_SdtEspectaculo_Lugarsector = null;
         SetDirty("Lugarsector");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Lugarsector_IsNull( )
      {
         if ( gxTv_SdtEspectaculo_Lugarsector == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFuncion" )]
      [  XmlArray( ElementName = "EspectaculoFuncion"  )]
      [  XmlArrayItemAttribute( ElementName= "Espectaculo.EspectaculoFuncion"  , IsNullable=false)]
      public GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion> gxTpr_Espectaculofuncion_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtEspectaculo_Espectaculofuncion == null )
            {
               gxTv_SdtEspectaculo_Espectaculofuncion = new GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion>( context, "Espectaculo.EspectaculoFuncion", "Obligatorio1v2");
            }
            return gxTv_SdtEspectaculo_Espectaculofuncion ;
         }

         set {
            if ( gxTv_SdtEspectaculo_Espectaculofuncion == null )
            {
               gxTv_SdtEspectaculo_Espectaculofuncion = new GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion>( context, "Espectaculo.EspectaculoFuncion", "Obligatorio1v2");
            }
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculofuncion = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion> gxTpr_Espectaculofuncion
      {
         get {
            if ( gxTv_SdtEspectaculo_Espectaculofuncion == null )
            {
               gxTv_SdtEspectaculo_Espectaculofuncion = new GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion>( context, "Espectaculo.EspectaculoFuncion", "Obligatorio1v2");
            }
            gxTv_SdtEspectaculo_N = 0;
            return gxTv_SdtEspectaculo_Espectaculofuncion ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculofuncion = value;
            SetDirty("Espectaculofuncion");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculofuncion_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculofuncion = null;
         SetDirty("Espectaculofuncion");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculofuncion_IsNull( )
      {
         if ( gxTv_SdtEspectaculo_Espectaculofuncion == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEspectaculo_Mode ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEspectaculo_Mode_SetNull( )
      {
         gxTv_SdtEspectaculo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEspectaculo_Initialized ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEspectaculo_Initialized_SetNull( )
      {
         gxTv_SdtEspectaculo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoId_Z" )]
      [  XmlElement( ElementName = "EspectaculoId_Z"   )]
      public short gxTpr_Espectaculoid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoid_Z = value;
            SetDirty("Espectaculoid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculoid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculoid_Z = 0;
         SetDirty("Espectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoName_Z" )]
      [  XmlElement( ElementName = "EspectaculoName_Z"   )]
      public string gxTpr_Espectaculoname_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoname_Z = value;
            SetDirty("Espectaculoname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculoname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculoname_Z = "";
         SetDirty("Espectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoFecha_Z" )]
      [  XmlElement( ElementName = "EspectaculoFecha_Z"  , IsNullable=true )]
      public string gxTpr_Espectaculofecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtEspectaculo_Espectaculofecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtEspectaculo_Espectaculofecha_Z).value ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtEspectaculo_Espectaculofecha_Z = DateTime.MinValue;
            else
               gxTv_SdtEspectaculo_Espectaculofecha_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Espectaculofecha_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculofecha_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculofecha_Z = value;
            SetDirty("Espectaculofecha_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculofecha_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculofecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Espectaculofecha_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculofecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Paisid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Paisid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisName_Z" )]
      [  XmlElement( ElementName = "PaisName_Z"   )]
      public string gxTpr_Paisname_Z
      {
         get {
            return gxTv_SdtEspectaculo_Paisname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Paisname_Z = value;
            SetDirty("Paisname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Paisname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Paisname_Z = "";
         SetDirty("Paisname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Paisname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarId_Z" )]
      [  XmlElement( ElementName = "LugarId_Z"   )]
      public short gxTpr_Lugarid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Lugarid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarid_Z = value;
            SetDirty("Lugarid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Lugarid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Lugarid_Z = 0;
         SetDirty("Lugarid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Lugarid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarName_Z" )]
      [  XmlElement( ElementName = "LugarName_Z"   )]
      public string gxTpr_Lugarname_Z
      {
         get {
            return gxTv_SdtEspectaculo_Lugarname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Lugarname_Z = value;
            SetDirty("Lugarname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Lugarname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Lugarname_Z = "";
         SetDirty("Lugarname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Lugarname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoId_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoId_Z"   )]
      public short gxTpr_Tipoespectaculoid_Z
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoid_Z = value;
            SetDirty("Tipoespectaculoid_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Tipoespectaculoid_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Tipoespectaculoid_Z = 0;
         SetDirty("Tipoespectaculoid_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Tipoespectaculoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEspectaculoName_Z" )]
      [  XmlElement( ElementName = "TipoEspectaculoName_Z"   )]
      public string gxTpr_Tipoespectaculoname_Z
      {
         get {
            return gxTv_SdtEspectaculo_Tipoespectaculoname_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Tipoespectaculoname_Z = value;
            SetDirty("Tipoespectaculoname_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Tipoespectaculoname_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Tipoespectaculoname_Z = "";
         SetDirty("Tipoespectaculoname_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Tipoespectaculoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspectaculoImagen_GXI_Z" )]
      [  XmlElement( ElementName = "EspectaculoImagen_GXI_Z"   )]
      public string gxTpr_Espectaculoimagen_gxi_Z
      {
         get {
            return gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
         }

         set {
            gxTv_SdtEspectaculo_N = 0;
            gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = value;
            SetDirty("Espectaculoimagen_gxi_Z");
         }

      }

      public void gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = "";
         SetDirty("Espectaculoimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtEspectaculo_N = 1;
         gxTv_SdtEspectaculo_Espectaculoname = "";
         gxTv_SdtEspectaculo_Espectaculofecha = DateTime.MinValue;
         gxTv_SdtEspectaculo_Paisname = "";
         gxTv_SdtEspectaculo_Lugarname = "";
         gxTv_SdtEspectaculo_Tipoespectaculoname = "";
         gxTv_SdtEspectaculo_Espectaculoimagen = "";
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi = "";
         gxTv_SdtEspectaculo_Mode = "";
         gxTv_SdtEspectaculo_Espectaculoname_Z = "";
         gxTv_SdtEspectaculo_Espectaculofecha_Z = DateTime.MinValue;
         gxTv_SdtEspectaculo_Paisname_Z = "";
         gxTv_SdtEspectaculo_Lugarname_Z = "";
         gxTv_SdtEspectaculo_Tipoespectaculoname_Z = "";
         gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "espectaculo", "GeneXus.Programs.espectaculo_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtEspectaculo_N ;
      }

      private short gxTv_SdtEspectaculo_Espectaculoid ;
      private short gxTv_SdtEspectaculo_N ;
      private short gxTv_SdtEspectaculo_Paisid ;
      private short gxTv_SdtEspectaculo_Lugarid ;
      private short gxTv_SdtEspectaculo_Tipoespectaculoid ;
      private short gxTv_SdtEspectaculo_Initialized ;
      private short gxTv_SdtEspectaculo_Espectaculoid_Z ;
      private short gxTv_SdtEspectaculo_Paisid_Z ;
      private short gxTv_SdtEspectaculo_Lugarid_Z ;
      private short gxTv_SdtEspectaculo_Tipoespectaculoid_Z ;
      private string gxTv_SdtEspectaculo_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEspectaculo_Espectaculofecha ;
      private DateTime gxTv_SdtEspectaculo_Espectaculofecha_Z ;
      private string gxTv_SdtEspectaculo_Espectaculoname ;
      private string gxTv_SdtEspectaculo_Paisname ;
      private string gxTv_SdtEspectaculo_Lugarname ;
      private string gxTv_SdtEspectaculo_Tipoespectaculoname ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen_gxi ;
      private string gxTv_SdtEspectaculo_Espectaculoname_Z ;
      private string gxTv_SdtEspectaculo_Paisname_Z ;
      private string gxTv_SdtEspectaculo_Lugarname_Z ;
      private string gxTv_SdtEspectaculo_Tipoespectaculoname_Z ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen_gxi_Z ;
      private string gxTv_SdtEspectaculo_Espectaculoimagen ;
      private GXBCLevelCollection<SdtEspectaculo_LugarSector> gxTv_SdtEspectaculo_Lugarsector=null ;
      private GXBCLevelCollection<SdtEspectaculo_EspectaculoFuncion> gxTv_SdtEspectaculo_Espectaculofuncion=null ;
   }

   [DataContract(Name = @"Espectaculo", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_RESTInterface : GxGenericCollectionItem<SdtEspectaculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_RESTInterface( ) : base()
      {
      }

      public SdtEspectaculo_RESTInterface( SdtEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspectaculoId" , Order = 0 )]
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

      [DataMember( Name = "EspectaculoName" , Order = 1 )]
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

      [DataMember( Name = "EspectaculoFecha" , Order = 2 )]
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

      [DataMember( Name = "PaisId" , Order = 3 )]
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

      [DataMember( Name = "PaisName" , Order = 4 )]
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

      [DataMember( Name = "LugarId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Lugarid
      {
         get {
            return sdt.gxTpr_Lugarid ;
         }

         set {
            sdt.gxTpr_Lugarid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LugarName" , Order = 6 )]
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

      [DataMember( Name = "TipoEspectaculoId" , Order = 7 )]
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

      [DataMember( Name = "TipoEspectaculoName" , Order = 8 )]
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

      [DataMember( Name = "EspectaculoImagen" , Order = 9 )]
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

      [DataMember( Name = "LugarSector" , Order = 10 )]
      public GxGenericCollection<SdtEspectaculo_LugarSector_RESTInterface> gxTpr_Lugarsector
      {
         get {
            return new GxGenericCollection<SdtEspectaculo_LugarSector_RESTInterface>(sdt.gxTpr_Lugarsector) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Lugarsector);
         }

      }

      [DataMember( Name = "EspectaculoFuncion" , Order = 11 )]
      public GxGenericCollection<SdtEspectaculo_EspectaculoFuncion_RESTInterface> gxTpr_Espectaculofuncion
      {
         get {
            return new GxGenericCollection<SdtEspectaculo_EspectaculoFuncion_RESTInterface>(sdt.gxTpr_Espectaculofuncion) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Espectaculofuncion);
         }

      }

      public SdtEspectaculo sdt
      {
         get {
            return (SdtEspectaculo)Sdt ;
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
            sdt = new SdtEspectaculo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 12 )]
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

   [DataContract(Name = @"Espectaculo", Namespace = "Obligatorio1v2")]
   public class SdtEspectaculo_RESTLInterface : GxGenericCollectionItem<SdtEspectaculo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtEspectaculo_RESTLInterface( ) : base()
      {
      }

      public SdtEspectaculo_RESTLInterface( SdtEspectaculo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspectaculoName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtEspectaculo sdt
      {
         get {
            return (SdtEspectaculo)Sdt ;
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
            sdt = new SdtEspectaculo() ;
         }
      }

   }

}
