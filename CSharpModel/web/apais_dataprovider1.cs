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
   public class apais_dataprovider1 : GXProcedure
   {
      public apais_dataprovider1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public apais_dataprovider1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         apais_dataprovider1 objapais_dataprovider1;
         objapais_dataprovider1 = new apais_dataprovider1();
         objapais_dataprovider1.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2") ;
         objapais_dataprovider1.context.SetSubmitInitialConfig(context);
         objapais_dataprovider1.initialize();
         Submit( executePrivateCatch,objapais_dataprovider1);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apais_dataprovider1)stateInfo).executePrivate();
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
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "URUGUAY";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "ARGENTINA";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "BRASIL";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "CHILE";
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
         Gxm1pais = new SdtPais(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtPais> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtPais> Gxm2rootcol ;
      private SdtPais Gxm1pais ;
   }

}
