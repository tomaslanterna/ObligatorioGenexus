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
   public class espectaculo_dataprovider : GXProcedure
   {
      public espectaculo_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public espectaculo_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtEspectaculo> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtEspectaculo>( context, "Espectaculo", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtEspectaculo> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtEspectaculo> aP0_ReturnValue )
      {
         espectaculo_dataprovider objespectaculo_dataprovider;
         objespectaculo_dataprovider = new espectaculo_dataprovider();
         objespectaculo_dataprovider.AV2ReturnValue = new GXBCCollection<SdtEspectaculo>( context, "Espectaculo", "Obligatorio1v2") ;
         objespectaculo_dataprovider.context.SetSubmitInitialConfig(context);
         objespectaculo_dataprovider.initialize();
         Submit( executePrivateCatch,objespectaculo_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((espectaculo_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<SdtEspectaculo>)AV2ReturnValue} ;
         ClassLoader.Execute("aespectaculo_dataprovider","GeneXus.Programs","aespectaculo_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtEspectaculo>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<SdtEspectaculo>( context, "Espectaculo", "Obligatorio1v2");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtEspectaculo> aP0_ReturnValue ;
      private GXBCCollection<SdtEspectaculo> AV2ReturnValue ;
   }

}
