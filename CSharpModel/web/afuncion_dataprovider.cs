using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class afuncion_dataprovider : GXProcedure
   {
      public afuncion_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public afuncion_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtFuncion> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtFuncion>( context, "Funcion", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtFuncion> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtFuncion> aP0_Gxm2rootcol )
      {
         afuncion_dataprovider objafuncion_dataprovider;
         objafuncion_dataprovider = new afuncion_dataprovider();
         objafuncion_dataprovider.Gxm2rootcol = new GXBCCollection<SdtFuncion>( context, "Funcion", "Obligatorio1v2") ;
         objafuncion_dataprovider.context.SetSubmitInitialConfig(context);
         objafuncion_dataprovider.initialize();
         Submit( executePrivateCatch,objafuncion_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((afuncion_dataprovider)stateInfo).executePrivate();
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
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "TINI";
         Gxm1funcion.gxTpr_Preciofuncion = 3000;
         Gxm1funcion.gxTpr_Espectaculoid = 1;
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "La Renga";
         Gxm1funcion.gxTpr_Preciofuncion = 1000;
         Gxm1funcion.gxTpr_Espectaculoid = 1;
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "Rels B";
         Gxm1funcion.gxTpr_Preciofuncion = 1500;
         Gxm1funcion.gxTpr_Espectaculoid = 1;
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "Yao Cabrera VS Chino Maidana";
         Gxm1funcion.gxTpr_Preciofuncion = 500;
         Gxm1funcion.gxTpr_Espectaculoid = 2;
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "Genexus VS React Js";
         Gxm1funcion.gxTpr_Preciofuncion = 800;
         Gxm1funcion.gxTpr_Espectaculoid = 2;
         Gxm1funcion = new SdtFuncion(context);
         Gxm2rootcol.Add(Gxm1funcion, 0);
         Gxm1funcion.gxTpr_Funcionname = "MOMO VS VIRUS";
         Gxm1funcion.gxTpr_Preciofuncion = 1800;
         Gxm1funcion.gxTpr_Espectaculoid = 2;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gxm1funcion = new SdtFuncion(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtFuncion> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtFuncion> Gxm2rootcol ;
      private SdtFuncion Gxm1funcion ;
   }

}
