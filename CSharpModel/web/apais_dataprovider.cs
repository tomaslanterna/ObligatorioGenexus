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
   public class apais_dataprovider : GXProcedure
   {
      public apais_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public apais_dataprovider( IGxContext context )
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
         apais_dataprovider objapais_dataprovider;
         objapais_dataprovider = new apais_dataprovider();
         objapais_dataprovider.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "Obligatorio1v2") ;
         objapais_dataprovider.context.SetSubmitInitialConfig(context);
         objapais_dataprovider.initialize();
         Submit( executePrivateCatch,objapais_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apais_dataprovider)stateInfo).executePrivate();
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
         Gxm1pais.gxTpr_Paisflag = context.convertURL( (string)(context.GetImagePath( "517b3558-b7ae-4e50-ae1a-16b8b0606a27", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "ARGENTINA";
         Gxm1pais.gxTpr_Paisflag = context.convertURL( (string)(context.GetImagePath( "62f48ed1-e238-437e-894f-eeb96f708d5c", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "BRASIL";
         Gxm1pais.gxTpr_Paisflag = context.convertURL( (string)(context.GetImagePath( "bb0201da-9886-4eb6-971b-2f167e23139b", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisname = "CHILE";
         Gxm1pais.gxTpr_Paisflag = context.convertURL( (string)(context.GetImagePath( "aed57f5c-1ff4-40f4-87e6-ed4ae51eb19c", "", context.GetTheme( ))));
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
