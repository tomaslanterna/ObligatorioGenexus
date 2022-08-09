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
   public class atipoespectaculo_dataprovider : GXProcedure
   {
      public atipoespectaculo_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public atipoespectaculo_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTipoEspectaculo> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol )
      {
         atipoespectaculo_dataprovider objatipoespectaculo_dataprovider;
         objatipoespectaculo_dataprovider = new atipoespectaculo_dataprovider();
         objatipoespectaculo_dataprovider.Gxm2rootcol = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "Obligatorio1v2") ;
         objatipoespectaculo_dataprovider.context.SetSubmitInitialConfig(context);
         objatipoespectaculo_dataprovider.initialize();
         Submit( executePrivateCatch,objatipoespectaculo_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((atipoespectaculo_dataprovider)stateInfo).executePrivate();
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
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculoname = "Obra de teatro";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculoname = "Concierto";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculoname = "Circo";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculoname = "Deporte";
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
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtTipoEspectaculo> Gxm2rootcol ;
      private SdtTipoEspectaculo Gxm1tipoespectaculo ;
   }

}
