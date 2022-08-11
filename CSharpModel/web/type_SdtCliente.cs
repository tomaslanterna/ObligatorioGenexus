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
   [XmlRoot(ElementName = "Cliente" )]
   [XmlType(TypeName =  "Cliente" , Namespace = "Obligatorio1v2" )]
   [Serializable]
   public class SdtCliente : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCliente( )
      {
      }

      public SdtCliente( IGxContext context )
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

      public void Load( short AV9ClienteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV9ClienteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Cliente");
         metadata.Set("BT", "Cliente");
         metadata.Set("PK", "[ \"ClienteId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteId\" ]");
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
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clientename_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCliente sdt;
         sdt = (SdtCliente)(source);
         gxTv_SdtCliente_Clienteid = sdt.gxTv_SdtCliente_Clienteid ;
         gxTv_SdtCliente_Clientename = sdt.gxTv_SdtCliente_Clientename ;
         gxTv_SdtCliente_Paisid = sdt.gxTv_SdtCliente_Paisid ;
         gxTv_SdtCliente_Paisname = sdt.gxTv_SdtCliente_Paisname ;
         gxTv_SdtCliente_Mode = sdt.gxTv_SdtCliente_Mode ;
         gxTv_SdtCliente_Initialized = sdt.gxTv_SdtCliente_Initialized ;
         gxTv_SdtCliente_Clienteid_Z = sdt.gxTv_SdtCliente_Clienteid_Z ;
         gxTv_SdtCliente_Clientename_Z = sdt.gxTv_SdtCliente_Clientename_Z ;
         gxTv_SdtCliente_Paisid_Z = sdt.gxTv_SdtCliente_Paisid_Z ;
         gxTv_SdtCliente_Paisname_Z = sdt.gxTv_SdtCliente_Paisname_Z ;
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
         AddObjectProperty("ClienteId", gxTv_SdtCliente_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteName", gxTv_SdtCliente_Clientename, false, includeNonInitialized);
         AddObjectProperty("PaisId", gxTv_SdtCliente_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisName", gxTv_SdtCliente_Paisname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCliente_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCliente_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtCliente_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteName_Z", gxTv_SdtCliente_Clientename_Z, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtCliente_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisName_Z", gxTv_SdtCliente_Paisname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCliente sdt )
      {
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Clienteid = sdt.gxTv_SdtCliente_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteName") )
         {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Clientename = sdt.gxTv_SdtCliente_Clientename ;
         }
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisid = sdt.gxTv_SdtCliente_Paisid ;
         }
         if ( sdt.IsDirty("PaisName") )
         {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisname = sdt.gxTv_SdtCliente_Paisname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public short gxTpr_Clienteid
      {
         get {
            return gxTv_SdtCliente_Clienteid ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            if ( gxTv_SdtCliente_Clienteid != value )
            {
               gxTv_SdtCliente_Mode = "INS";
               this.gxTv_SdtCliente_Clienteid_Z_SetNull( );
               this.gxTv_SdtCliente_Clientename_Z_SetNull( );
               this.gxTv_SdtCliente_Paisid_Z_SetNull( );
               this.gxTv_SdtCliente_Paisname_Z_SetNull( );
            }
            gxTv_SdtCliente_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      [  SoapElement( ElementName = "ClienteName" )]
      [  XmlElement( ElementName = "ClienteName"   )]
      public string gxTpr_Clientename
      {
         get {
            return gxTv_SdtCliente_Clientename ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Clientename = value;
            SetDirty("Clientename");
         }

      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtCliente_Paisid ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisName" )]
      [  XmlElement( ElementName = "PaisName"   )]
      public string gxTpr_Paisname
      {
         get {
            return gxTv_SdtCliente_Paisname ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisname = value;
            SetDirty("Paisname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCliente_Mode ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCliente_Mode_SetNull( )
      {
         gxTv_SdtCliente_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCliente_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCliente_Initialized ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCliente_Initialized_SetNull( )
      {
         gxTv_SdtCliente_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCliente_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public short gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtCliente_Clienteid_Z ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtCliente_Clienteid_Z_SetNull( )
      {
         gxTv_SdtCliente_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteName_Z" )]
      [  XmlElement( ElementName = "ClienteName_Z"   )]
      public string gxTpr_Clientename_Z
      {
         get {
            return gxTv_SdtCliente_Clientename_Z ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Clientename_Z = value;
            SetDirty("Clientename_Z");
         }

      }

      public void gxTv_SdtCliente_Clientename_Z_SetNull( )
      {
         gxTv_SdtCliente_Clientename_Z = "";
         SetDirty("Clientename_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Clientename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtCliente_Paisid_Z ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtCliente_Paisid_Z_SetNull( )
      {
         gxTv_SdtCliente_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisName_Z" )]
      [  XmlElement( ElementName = "PaisName_Z"   )]
      public string gxTpr_Paisname_Z
      {
         get {
            return gxTv_SdtCliente_Paisname_Z ;
         }

         set {
            gxTv_SdtCliente_N = 0;
            gxTv_SdtCliente_Paisname_Z = value;
            SetDirty("Paisname_Z");
         }

      }

      public void gxTv_SdtCliente_Paisname_Z_SetNull( )
      {
         gxTv_SdtCliente_Paisname_Z = "";
         SetDirty("Paisname_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Paisname_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCliente_N = 1;
         gxTv_SdtCliente_Clientename = "";
         gxTv_SdtCliente_Paisname = "";
         gxTv_SdtCliente_Mode = "";
         gxTv_SdtCliente_Clientename_Z = "";
         gxTv_SdtCliente_Paisname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "cliente", "GeneXus.Programs.cliente_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCliente_N ;
      }

      private short gxTv_SdtCliente_Clienteid ;
      private short gxTv_SdtCliente_N ;
      private short gxTv_SdtCliente_Paisid ;
      private short gxTv_SdtCliente_Initialized ;
      private short gxTv_SdtCliente_Clienteid_Z ;
      private short gxTv_SdtCliente_Paisid_Z ;
      private string gxTv_SdtCliente_Mode ;
      private string gxTv_SdtCliente_Clientename ;
      private string gxTv_SdtCliente_Paisname ;
      private string gxTv_SdtCliente_Clientename_Z ;
      private string gxTv_SdtCliente_Paisname_Z ;
   }

   [DataContract(Name = @"Cliente", Namespace = "Obligatorio1v2")]
   public class SdtCliente_RESTInterface : GxGenericCollectionItem<SdtCliente>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCliente_RESTInterface( ) : base()
      {
      }

      public SdtCliente_RESTInterface( SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteId" , Order = 0 )]
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

      [DataMember( Name = "ClienteName" , Order = 1 )]
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

      public SdtCliente sdt
      {
         get {
            return (SdtCliente)Sdt ;
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
            sdt = new SdtCliente() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"Cliente", Namespace = "Obligatorio1v2")]
   public class SdtCliente_RESTLInterface : GxGenericCollectionItem<SdtCliente>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtCliente_RESTLInterface( ) : base()
      {
      }

      public SdtCliente_RESTLInterface( SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCliente sdt
      {
         get {
            return (SdtCliente)Sdt ;
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
            sdt = new SdtCliente() ;
         }
      }

   }

}
