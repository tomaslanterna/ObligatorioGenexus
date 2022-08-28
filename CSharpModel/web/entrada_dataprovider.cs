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
   public class entrada_dataprovider : GXProcedure
   {
      public entrada_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public entrada_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtEntrada> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtEntrada>( context, "Entrada", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtEntrada> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtEntrada> aP0_ReturnValue )
      {
         entrada_dataprovider objentrada_dataprovider;
         objentrada_dataprovider = new entrada_dataprovider();
         objentrada_dataprovider.AV2ReturnValue = new GXBCCollection<SdtEntrada>( context, "Entrada", "Obligatorio1v2") ;
         objentrada_dataprovider.context.SetSubmitInitialConfig(context);
         objentrada_dataprovider.initialize();
         Submit( executePrivateCatch,objentrada_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((entrada_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<SdtEntrada>)AV2ReturnValue} ;
         ClassLoader.Execute("aentrada_dataprovider","GeneXus.Programs","aentrada_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtEntrada>)(args[0]) ;
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
         AV2ReturnValue = new GXBCCollection<SdtEntrada>( context, "Entrada", "Obligatorio1v2");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtEntrada> aP0_ReturnValue ;
      private GXBCCollection<SdtEntrada> AV2ReturnValue ;
   }

}
