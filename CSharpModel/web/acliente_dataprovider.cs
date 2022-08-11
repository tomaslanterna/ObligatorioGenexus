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
   public class acliente_dataprovider : GXProcedure
   {
      public acliente_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acliente_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCliente> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCliente>( context, "Cliente", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCliente> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCliente> aP0_Gxm2rootcol )
      {
         acliente_dataprovider objacliente_dataprovider;
         objacliente_dataprovider = new acliente_dataprovider();
         objacliente_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCliente>( context, "Cliente", "Obligatorio1v2") ;
         objacliente_dataprovider.context.SetSubmitInitialConfig(context);
         objacliente_dataprovider.initialize();
         Submit( executePrivateCatch,objacliente_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acliente_dataprovider)stateInfo).executePrivate();
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
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Tomas Lanterna";
         Gxm1cliente.gxTpr_Paisid = 1;
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Agustin Piriz";
         Gxm1cliente.gxTpr_Paisid = 2;
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Luis Suarez";
         Gxm1cliente.gxTpr_Paisid = 1;
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Leonel Messi";
         Gxm1cliente.gxTpr_Paisid = 2;
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Edison Cavani";
         Gxm1cliente.gxTpr_Paisid = 3;
         Gxm1cliente = new SdtCliente(context);
         Gxm2rootcol.Add(Gxm1cliente, 0);
         Gxm1cliente.gxTpr_Clientename = "Darwin Nuniez";
         Gxm1cliente.gxTpr_Paisid = 4;
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
         Gxm1cliente = new SdtCliente(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtCliente> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCliente> Gxm2rootcol ;
      private SdtCliente Gxm1cliente ;
   }

}
