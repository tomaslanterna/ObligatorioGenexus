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
   public class aentrada_dataprovider : GXProcedure
   {
      public aentrada_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aentrada_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtEntrada> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtEntrada>( context, "Entrada", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtEntrada> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtEntrada> aP0_Gxm2rootcol )
      {
         aentrada_dataprovider objaentrada_dataprovider;
         objaentrada_dataprovider = new aentrada_dataprovider();
         objaentrada_dataprovider.Gxm2rootcol = new GXBCCollection<SdtEntrada>( context, "Entrada", "Obligatorio1v2") ;
         objaentrada_dataprovider.context.SetSubmitInitialConfig(context);
         objaentrada_dataprovider.initialize();
         Submit( executePrivateCatch,objaentrada_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aentrada_dataprovider)stateInfo).executePrivate();
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
         Gxm1entrada = new SdtEntrada(context);
         Gxm2rootcol.Add(Gxm1entrada, 0);
         Gxm1entrada.gxTpr_Entradafecha = Gx_date;
         Gxm1entrada.gxTpr_Clienteid = 2;
         Gxm1entrada.gxTpr_Espectaculoid = 1;
         Gxm1entrada.gxTpr_Espectaculofuncionid = 0;
         Gxm1entrada.gxTpr_Espectaculopaisname = "Uruguay";
         Gxm1entrada.gxTpr_Lugarsectorid = 2;
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
         Gxm1entrada = new SdtEntrada(context);
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private DateTime Gx_date ;
      private GXBCCollection<SdtEntrada> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtEntrada> Gxm2rootcol ;
      private SdtEntrada Gxm1entrada ;
   }

}
