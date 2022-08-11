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
   public class aespectaculo_dataprovider : GXProcedure
   {
      public aespectaculo_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aespectaculo_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtEspectaculo> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtEspectaculo>( context, "Espectaculo", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtEspectaculo> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtEspectaculo> aP0_Gxm2rootcol )
      {
         aespectaculo_dataprovider objaespectaculo_dataprovider;
         objaespectaculo_dataprovider = new aespectaculo_dataprovider();
         objaespectaculo_dataprovider.Gxm2rootcol = new GXBCCollection<SdtEspectaculo>( context, "Espectaculo", "Obligatorio1v2") ;
         objaespectaculo_dataprovider.context.SetSubmitInitialConfig(context);
         objaespectaculo_dataprovider.initialize();
         Submit( executePrivateCatch,objaespectaculo_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aespectaculo_dataprovider)stateInfo).executePrivate();
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
         Gxm1espectaculo = new SdtEspectaculo(context);
         Gxm2rootcol.Add(Gxm1espectaculo, 0);
         Gxm1espectaculo.gxTpr_Espectaculoname = "Antel Fest";
         Gxm1espectaculo.gxTpr_Espectaculofecha = Gx_date;
         Gxm1espectaculo.gxTpr_Lugarid = 1;
         Gxm1espectaculo.gxTpr_Tipoespectaculoid = 1;
         Gxm3espectaculo_lugarsector = new SdtEspectaculo_LugarSector(context);
         Gxm1espectaculo.gxTpr_Lugarsector.Add(Gxm3espectaculo_lugarsector, 0);
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorid = 1;
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorestadosector = true;
         Gxm3espectaculo_lugarsector = new SdtEspectaculo_LugarSector(context);
         Gxm1espectaculo.gxTpr_Lugarsector.Add(Gxm3espectaculo_lugarsector, 0);
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorid = 2;
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorestadosector = true;
         Gxm4espectaculo_espectaculofuncion = new SdtEspectaculo_EspectaculoFuncion(context);
         Gxm1espectaculo.gxTpr_Espectaculofuncion.Add(Gxm4espectaculo_espectaculofuncion, 0);
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionname = "TINI";
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionprecio = 3000;
         Gxm4espectaculo_espectaculofuncion = new SdtEspectaculo_EspectaculoFuncion(context);
         Gxm1espectaculo.gxTpr_Espectaculofuncion.Add(Gxm4espectaculo_espectaculofuncion, 0);
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionname = "La Renga";
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionprecio = 2000;
         Gxm1espectaculo = new SdtEspectaculo(context);
         Gxm2rootcol.Add(Gxm1espectaculo, 0);
         Gxm1espectaculo.gxTpr_Espectaculoname = "Mundial 2022";
         Gxm1espectaculo.gxTpr_Espectaculofecha = Gx_date;
         Gxm1espectaculo.gxTpr_Lugarid = 1;
         Gxm1espectaculo.gxTpr_Tipoespectaculoid = 4;
         Gxm3espectaculo_lugarsector = new SdtEspectaculo_LugarSector(context);
         Gxm1espectaculo.gxTpr_Lugarsector.Add(Gxm3espectaculo_lugarsector, 0);
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorid = 1;
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorestadosector = true;
         Gxm3espectaculo_lugarsector = new SdtEspectaculo_LugarSector(context);
         Gxm1espectaculo.gxTpr_Lugarsector.Add(Gxm3espectaculo_lugarsector, 0);
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorid = 2;
         Gxm3espectaculo_lugarsector.gxTpr_Lugarsectorestadosector = true;
         Gxm4espectaculo_espectaculofuncion = new SdtEspectaculo_EspectaculoFuncion(context);
         Gxm1espectaculo.gxTpr_Espectaculofuncion.Add(Gxm4espectaculo_espectaculofuncion, 0);
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionname = "Uruguay vs Argentina";
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionprecio = 5000;
         Gxm4espectaculo_espectaculofuncion = new SdtEspectaculo_EspectaculoFuncion(context);
         Gxm1espectaculo.gxTpr_Espectaculofuncion.Add(Gxm4espectaculo_espectaculofuncion, 0);
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionname = "Brazil vs Alemania";
         Gxm4espectaculo_espectaculofuncion.gxTpr_Espectaculofuncionprecio = 6000;
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
         Gxm1espectaculo = new SdtEspectaculo(context);
         Gx_date = DateTime.MinValue;
         Gxm3espectaculo_lugarsector = new SdtEspectaculo_LugarSector(context);
         Gxm4espectaculo_espectaculofuncion = new SdtEspectaculo_EspectaculoFuncion(context);
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private DateTime Gx_date ;
      private GXBCCollection<SdtEspectaculo> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtEspectaculo> Gxm2rootcol ;
      private SdtEspectaculo Gxm1espectaculo ;
      private SdtEspectaculo_LugarSector Gxm3espectaculo_lugarsector ;
      private SdtEspectaculo_EspectaculoFuncion Gxm4espectaculo_espectaculofuncion ;
   }

}
