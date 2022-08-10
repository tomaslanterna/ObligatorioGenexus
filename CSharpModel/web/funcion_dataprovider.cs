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
   public class funcion_dataprovider : GXProcedure
   {
      public funcion_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public funcion_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtFuncion> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtFuncion>( context, "Funcion", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtFuncion> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtFuncion> aP0_ReturnValue )
      {
         funcion_dataprovider objfuncion_dataprovider;
         objfuncion_dataprovider = new funcion_dataprovider();
         objfuncion_dataprovider.AV2ReturnValue = new GXBCCollection<SdtFuncion>( context, "Funcion", "Obligatorio1v2") ;
         objfuncion_dataprovider.context.SetSubmitInitialConfig(context);
         objfuncion_dataprovider.initialize();
         Submit( executePrivateCatch,objfuncion_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((funcion_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<SdtFuncion>)AV2ReturnValue} ;
         ClassLoader.Execute("afuncion_dataprovider","GeneXus.Programs","afuncion_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtFuncion>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<SdtFuncion>( context, "Funcion", "Obligatorio1v2");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtFuncion> aP0_ReturnValue ;
      private GXBCCollection<SdtFuncion> AV2ReturnValue ;
   }

}
