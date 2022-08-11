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
   public class alugar_dataprovider : GXProcedure
   {
      public alugar_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public alugar_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtLugar> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtLugar> aP0_Gxm2rootcol )
      {
         alugar_dataprovider objalugar_dataprovider;
         objalugar_dataprovider = new alugar_dataprovider();
         objalugar_dataprovider.Gxm2rootcol = new GXBCCollection<SdtLugar>( context, "Lugar", "Obligatorio1v2") ;
         objalugar_dataprovider.context.SetSubmitInitialConfig(context);
         objalugar_dataprovider.initialize();
         Submit( executePrivateCatch,objalugar_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alugar_dataprovider)stateInfo).executePrivate();
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
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Estadio Centenario";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Colombes";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Amsterdam";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "America";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 6000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Luna Park";
         Gxm1lugar.gxTpr_Paisid = 2;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Norte";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sur";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Este";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 6000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 200;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Estadio Nacional";
         Gxm1lugar.gxTpr_Paisid = 5;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna 1";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 2400;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 400;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna 2";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 2500;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 500;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna 3";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 2600;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 600;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Sodre";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Platea baja";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3500;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 500;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Platea media";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3600;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 600;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Teatro Solis";
         Gxm1lugar.gxTpr_Paisid = 1;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sala 1";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3600;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 600;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sala 2";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3700;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 700;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sala 3";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3800;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 800;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Teatro Colon";
         Gxm1lugar.gxTpr_Paisid = 2;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sector A";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3700;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 700;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sector B";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3800;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 800;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Sector C";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3900;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 900;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Auditorio Nacional";
         Gxm1lugar.gxTpr_Paisid = 4;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Seccion 1";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 3900;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 900;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Seccion 2";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4000;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 1100;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Seccion 3";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4100;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 2000;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Teatro Sao Pedro";
         Gxm1lugar.gxTpr_Paisid = 3;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Patron A";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4300;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 300;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Patron B";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4400;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 400;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Patron C";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4500;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 2300;
         Gxm1lugar = new SdtLugar(context);
         Gxm2rootcol.Add(Gxm1lugar, 0);
         Gxm1lugar.gxTpr_Lugarname = "Municipal de Santiago";
         Gxm1lugar.gxTpr_Paisid = 5;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 1;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna A";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4600;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 2500;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 2;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna B";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4700;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 2600;
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         Gxm1lugar.gxTpr_Sector.Add(Gxm3lugar_sector, 0);
         Gxm3lugar_sector.gxTpr_Lugarsectorid = 3;
         Gxm3lugar_sector.gxTpr_Lugarsectorname = "Tribuna C";
         Gxm3lugar_sector.gxTpr_Lugarsectorcantidad = 4800;
         Gxm3lugar_sector.gxTpr_Lugarsectorprecio = 2700;
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
         Gxm1lugar = new SdtLugar(context);
         Gxm3lugar_sector = new SdtLugar_Sector(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtLugar> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtLugar> Gxm2rootcol ;
      private SdtLugar Gxm1lugar ;
      private SdtLugar_Sector Gxm3lugar_sector ;
   }

}
