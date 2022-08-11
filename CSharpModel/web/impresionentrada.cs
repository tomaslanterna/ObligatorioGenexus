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
   public class impresionentrada : GXProcedure
   {
      public impresionentrada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public impresionentrada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_EntradaId )
      {
         this.AV2EntradaId = aP0_EntradaId;
         initialize();
         executePrivate();
         aP0_EntradaId=this.AV2EntradaId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_EntradaId);
         return AV2EntradaId ;
      }

      public void executeSubmit( ref short aP0_EntradaId )
      {
         impresionentrada objimpresionentrada;
         objimpresionentrada = new impresionentrada();
         objimpresionentrada.AV2EntradaId = aP0_EntradaId;
         objimpresionentrada.context.SetSubmitInitialConfig(context);
         objimpresionentrada.initialize();
         Submit( executePrivateCatch,objimpresionentrada);
         aP0_EntradaId=this.AV2EntradaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((impresionentrada)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2EntradaId} ;
         ClassLoader.Execute("aimpresionentrada","GeneXus.Programs","aimpresionentrada", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2EntradaId = (short)(args[0]) ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2EntradaId ;
      private IGxDataStore dsDefault ;
      private short aP0_EntradaId ;
      private Object[] args ;
   }

}
