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
   [XmlRoot(ElementName = "Lugar" )]
   [XmlType(TypeName =  "Lugar" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtLugar : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtLugar( )
      {
      }

      public SdtLugar( IGxContext context )
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

      public void Load( short AV4LugarId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV4LugarId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LugarId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Lugar");
         metadata.Set("BT", "Lugar");
         metadata.Set("PK", "[ \"LugarId\" ]");
         metadata.Set("PKAssigned", "[ \"LugarId\" ]");
         metadata.Set("Levels", "[ \"Sector\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PaisId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Lugarid_Z");
         state.Add("gxTpr_Lugarname_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLugar sdt;
         sdt = (SdtLugar)(source);
         gxTv_SdtLugar_Lugarid = sdt.gxTv_SdtLugar_Lugarid ;
         gxTv_SdtLugar_Lugarname = sdt.gxTv_SdtLugar_Lugarname ;
         gxTv_SdtLugar_Paisid = sdt.gxTv_SdtLugar_Paisid ;
         gxTv_SdtLugar_Paisname = sdt.gxTv_SdtLugar_Paisname ;
         gxTv_SdtLugar_Sector = sdt.gxTv_SdtLugar_Sector ;
         gxTv_SdtLugar_Mode = sdt.gxTv_SdtLugar_Mode ;
         gxTv_SdtLugar_Initialized = sdt.gxTv_SdtLugar_Initialized ;
         gxTv_SdtLugar_Lugarid_Z = sdt.gxTv_SdtLugar_Lugarid_Z ;
         gxTv_SdtLugar_Lugarname_Z = sdt.gxTv_SdtLugar_Lugarname_Z ;
         gxTv_SdtLugar_Paisid_Z = sdt.gxTv_SdtLugar_Paisid_Z ;
         gxTv_SdtLugar_Paisname_Z = sdt.gxTv_SdtLugar_Paisname_Z ;
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
         AddObjectProperty("LugarId", gxTv_SdtLugar_Lugarid, false, includeNonInitialized);
         AddObjectProperty("LugarName", gxTv_SdtLugar_Lugarname, false, includeNonInitialized);
         AddObjectProperty("PaisId", gxTv_SdtLugar_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisName", gxTv_SdtLugar_Paisname, false, includeNonInitialized);
         if ( gxTv_SdtLugar_Sector != null )
         {
            AddObjectProperty("Sector", gxTv_SdtLugar_Sector, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLugar_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLugar_Initialized, false, includeNonInitialized);
            AddObjectProperty("LugarId_Z", gxTv_SdtLugar_Lugarid_Z, false, includeNonInitialized);
            AddObjectProperty("LugarName_Z", gxTv_SdtLugar_Lugarname_Z, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtLugar_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisName_Z", gxTv_SdtLugar_Paisname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLugar sdt )
      {
         if ( sdt.IsDirty("LugarId") )
         {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Lugarid = sdt.gxTv_SdtLugar_Lugarid ;
         }
         if ( sdt.IsDirty("LugarName") )
         {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Lugarname = sdt.gxTv_SdtLugar_Lugarname ;
         }
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisid = sdt.gxTv_SdtLugar_Paisid ;
         }
         if ( sdt.IsDirty("PaisName") )
         {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisname = sdt.gxTv_SdtLugar_Paisname ;
         }
         if ( gxTv_SdtLugar_Sector != null )
         {
            GXBCLevelCollection<SdtLugar_Sector> newCollectionSector = sdt.gxTpr_Sector;
            SdtLugar_Sector currItemSector;
            SdtLugar_Sector newItemSector;
            short idx = 1;
            while ( idx <= newCollectionSector.Count )
            {
               newItemSector = ((SdtLugar_Sector)newCollectionSector.Item(idx));
               currItemSector = gxTv_SdtLugar_Sector.GetByKey(newItemSector.gxTpr_Lugarsectorid);
               if ( StringUtil.StrCmp(currItemSector.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemSector.UpdateDirties(newItemSector);
                  if ( StringUtil.StrCmp(newItemSector.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemSector.gxTpr_Mode = "DLT";
                  }
                  currItemSector.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtLugar_Sector.Add(newItemSector, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "LugarId" )]
      [  XmlElement( ElementName = "LugarId"   )]
      public short gxTpr_Lugarid
      {
         get {
            return gxTv_SdtLugar_Lugarid ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            if ( gxTv_SdtLugar_Lugarid != value )
            {
               gxTv_SdtLugar_Mode = "INS";
               this.gxTv_SdtLugar_Lugarid_Z_SetNull( );
               this.gxTv_SdtLugar_Lugarname_Z_SetNull( );
               this.gxTv_SdtLugar_Paisid_Z_SetNull( );
               this.gxTv_SdtLugar_Paisname_Z_SetNull( );
               if ( gxTv_SdtLugar_Sector != null )
               {
                  GXBCLevelCollection<SdtLugar_Sector> collectionSector = gxTv_SdtLugar_Sector;
                  SdtLugar_Sector currItemSector;
                  short idx = 1;
                  while ( idx <= collectionSector.Count )
                  {
                     currItemSector = ((SdtLugar_Sector)collectionSector.Item(idx));
                     currItemSector.gxTpr_Mode = "INS";
                     currItemSector.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtLugar_Lugarid = value;
            SetDirty("Lugarid");
         }

      }

      [  SoapElement( ElementName = "LugarName" )]
      [  XmlElement( ElementName = "LugarName"   )]
      public string gxTpr_Lugarname
      {
         get {
            return gxTv_SdtLugar_Lugarname ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Lugarname = value;
            SetDirty("Lugarname");
         }

      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtLugar_Paisid ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisName" )]
      [  XmlElement( ElementName = "PaisName"   )]
      public string gxTpr_Paisname
      {
         get {
            return gxTv_SdtLugar_Paisname ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisname = value;
            SetDirty("Paisname");
         }

      }

      [  SoapElement( ElementName = "Sector" )]
      [  XmlArray( ElementName = "Sector"  )]
      [  XmlArrayItemAttribute( ElementName= "Lugar.Sector"  , IsNullable=false)]
      public GXBCLevelCollection<SdtLugar_Sector> gxTpr_Sector_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtLugar_Sector == null )
            {
               gxTv_SdtLugar_Sector = new GXBCLevelCollection<SdtLugar_Sector>( context, "Lugar.Sector", "Obligatorio1v2");
            }
            return gxTv_SdtLugar_Sector ;
         }

         set {
            if ( gxTv_SdtLugar_Sector == null )
            {
               gxTv_SdtLugar_Sector = new GXBCLevelCollection<SdtLugar_Sector>( context, "Lugar.Sector", "Obligatorio1v2");
            }
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Sector = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtLugar_Sector> gxTpr_Sector
      {
         get {
            if ( gxTv_SdtLugar_Sector == null )
            {
               gxTv_SdtLugar_Sector = new GXBCLevelCollection<SdtLugar_Sector>( context, "Lugar.Sector", "Obligatorio1v2");
            }
            gxTv_SdtLugar_N = 0;
            return gxTv_SdtLugar_Sector ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Sector = value;
            SetDirty("Sector");
         }

      }

      public void gxTv_SdtLugar_Sector_SetNull( )
      {
         gxTv_SdtLugar_Sector = null;
         SetDirty("Sector");
         return  ;
      }

      public bool gxTv_SdtLugar_Sector_IsNull( )
      {
         if ( gxTv_SdtLugar_Sector == null )
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
            return gxTv_SdtLugar_Mode ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLugar_Mode_SetNull( )
      {
         gxTv_SdtLugar_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLugar_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLugar_Initialized ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLugar_Initialized_SetNull( )
      {
         gxTv_SdtLugar_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLugar_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarId_Z" )]
      [  XmlElement( ElementName = "LugarId_Z"   )]
      public short gxTpr_Lugarid_Z
      {
         get {
            return gxTv_SdtLugar_Lugarid_Z ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Lugarid_Z = value;
            SetDirty("Lugarid_Z");
         }

      }

      public void gxTv_SdtLugar_Lugarid_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugarid_Z = 0;
         SetDirty("Lugarid_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LugarName_Z" )]
      [  XmlElement( ElementName = "LugarName_Z"   )]
      public string gxTpr_Lugarname_Z
      {
         get {
            return gxTv_SdtLugar_Lugarname_Z ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Lugarname_Z = value;
            SetDirty("Lugarname_Z");
         }

      }

      public void gxTv_SdtLugar_Lugarname_Z_SetNull( )
      {
         gxTv_SdtLugar_Lugarname_Z = "";
         SetDirty("Lugarname_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Lugarname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtLugar_Paisid_Z ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtLugar_Paisid_Z_SetNull( )
      {
         gxTv_SdtLugar_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisName_Z" )]
      [  XmlElement( ElementName = "PaisName_Z"   )]
      public string gxTpr_Paisname_Z
      {
         get {
            return gxTv_SdtLugar_Paisname_Z ;
         }

         set {
            gxTv_SdtLugar_N = 0;
            gxTv_SdtLugar_Paisname_Z = value;
            SetDirty("Paisname_Z");
         }

      }

      public void gxTv_SdtLugar_Paisname_Z_SetNull( )
      {
         gxTv_SdtLugar_Paisname_Z = "";
         SetDirty("Paisname_Z");
         return  ;
      }

      public bool gxTv_SdtLugar_Paisname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtLugar_N = 1;
         gxTv_SdtLugar_Lugarname = "";
         gxTv_SdtLugar_Paisname = "";
         gxTv_SdtLugar_Mode = "";
         gxTv_SdtLugar_Lugarname_Z = "";
         gxTv_SdtLugar_Paisname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "lugar", "GeneXus.Programs.lugar_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtLugar_N ;
      }

      private short gxTv_SdtLugar_Lugarid ;
      private short gxTv_SdtLugar_N ;
      private short gxTv_SdtLugar_Paisid ;
      private short gxTv_SdtLugar_Initialized ;
      private short gxTv_SdtLugar_Lugarid_Z ;
      private short gxTv_SdtLugar_Paisid_Z ;
      private string gxTv_SdtLugar_Mode ;
      private string gxTv_SdtLugar_Lugarname ;
      private string gxTv_SdtLugar_Paisname ;
      private string gxTv_SdtLugar_Lugarname_Z ;
      private string gxTv_SdtLugar_Paisname_Z ;
      private GXBCLevelCollection<SdtLugar_Sector> gxTv_SdtLugar_Sector=null ;
   }

   [DataContract(Name = @"Lugar", Namespace = "Obligatorio1v2")]
   public class SdtLugar_RESTInterface : GxGenericCollectionItem<SdtLugar>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtLugar_RESTInterface( ) : base()
      {
      }

      public SdtLugar_RESTInterface( SdtLugar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LugarId" , Order = 0 )]
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

      [DataMember( Name = "LugarName" , Order = 1 )]
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

      [DataMember( Name = "Sector" , Order = 4 )]
      public GxGenericCollection<SdtLugar_Sector_RESTInterface> gxTpr_Sector
      {
         get {
            return new GxGenericCollection<SdtLugar_Sector_RESTInterface>(sdt.gxTpr_Sector) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Sector);
         }

      }

      public SdtLugar sdt
      {
         get {
            return (SdtLugar)Sdt ;
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
            sdt = new SdtLugar() ;
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

   [DataContract(Name = @"Lugar", Namespace = "Obligatorio1v2")]
   public class SdtLugar_RESTLInterface : GxGenericCollectionItem<SdtLugar>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtLugar_RESTLInterface( ) : base()
      {
      }

      public SdtLugar_RESTLInterface( SdtLugar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LugarName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtLugar sdt
      {
         get {
            return (SdtLugar)Sdt ;
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
            sdt = new SdtLugar() ;
         }
      }

   }

}
