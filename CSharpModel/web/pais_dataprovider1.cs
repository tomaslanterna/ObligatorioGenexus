using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pais_dataprovider1 : GXProcedure
   {
      public pais_dataprovider1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public pais_dataprovider1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtPais> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_ReturnValue )
      {
         pais_dataprovider1 objpais_dataprovider1;
         objpais_dataprovider1 = new pais_dataprovider1();
         objpais_dataprovider1.AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2") ;
         objpais_dataprovider1.context.SetSubmitInitialConfig(context);
         objpais_dataprovider1.initialize();
         Submit( executePrivateCatch,objpais_dataprovider1);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pais_dataprovider1)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(GXBCCollection<SdtPais>)AV2ReturnValue} ;
         ClassLoader.Execute("apais_dataprovider1","GeneXus.Programs","apais_dataprovider1", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtPais>)(args[0]) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtPais> aP0_ReturnValue ;
      private GXBCCollection<SdtPais> AV2ReturnValue ;
   }

}
