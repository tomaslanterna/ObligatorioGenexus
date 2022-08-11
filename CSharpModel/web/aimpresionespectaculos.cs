using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
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
   public class aimpresionespectaculos : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public aimpresionespectaculos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aimpresionespectaculos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aimpresionespectaculos objaimpresionespectaculos;
         objaimpresionespectaculos = new aimpresionespectaculos();
         objaimpresionespectaculos.context.SetSubmitInitialConfig(context);
         objaimpresionespectaculos.initialize();
         Submit( executePrivateCatch,objaimpresionespectaculos);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aimpresionespectaculos)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV4GXLvl5 = 0;
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A3PaisId = P000H2_A3PaisId[0];
               A7TipoEspectaculoId = P000H2_A7TipoEspectaculoId[0];
               A1EspectaculoId = P000H2_A1EspectaculoId[0];
               A4LugarId = P000H2_A4LugarId[0];
               A6PaisName = P000H2_A6PaisName[0];
               A5LugarName = P000H2_A5LugarName[0];
               A8TipoEspectaculoName = P000H2_A8TipoEspectaculoName[0];
               A16EspectaculoFecha = P000H2_A16EspectaculoFecha[0];
               A2EspectaculoName = P000H2_A2EspectaculoName[0];
               A8TipoEspectaculoName = P000H2_A8TipoEspectaculoName[0];
               A3PaisId = P000H2_A3PaisId[0];
               A5LugarName = P000H2_A5LugarName[0];
               A6PaisName = P000H2_A6PaisName[0];
               AV4GXLvl5 = 1;
               H0H0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id", 128, Gx_line+44, 195, Gx_line+67, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre", 244, Gx_line+33, 322, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 389, Gx_line+33, 445, Gx_line+60, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 522, Gx_line+33, 566, Gx_line+56, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Lugar", 644, Gx_line+33, 694, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Pais", 744, Gx_line+33, 805, Gx_line+55, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               H0H0( false, 59) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")), 122, Gx_line+44, 194, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), 233, Gx_line+44, 338, Gx_line+59, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), 361, Gx_line+44, 467, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), 489, Gx_line+44, 611, Gx_line+59, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), 639, Gx_line+44, 717, Gx_line+59, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), 750, Gx_line+44, 822, Gx_line+59, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+59);
               H0H0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sectores Disponibles", 306, Gx_line+22, 484, Gx_line+55, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               H0H0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id", 122, Gx_line+33, 189, Gx_line+56, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre", 244, Gx_line+33, 322, Gx_line+66, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 400, Gx_line+33, 456, Gx_line+60, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Lugares Disponibles", 517, Gx_line+33, 678, Gx_line+56, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               AV5GXLvl10 = 0;
               /* Using cursor P000H4 */
               pr_default.execute(1, new Object[] {A4LugarId, A1EspectaculoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A30LugarSectorPrecio = P000H4_A30LugarSectorPrecio[0];
                  A28LugarSectorName = P000H4_A28LugarSectorName[0];
                  A27LugarSectorId = P000H4_A27LugarSectorId[0];
                  A29LugarSectorCantidad = P000H4_A29LugarSectorCantidad[0];
                  A37LugarSectorVendidas = P000H4_A37LugarSectorVendidas[0];
                  n37LugarSectorVendidas = P000H4_n37LugarSectorVendidas[0];
                  A37LugarSectorVendidas = P000H4_A37LugarSectorVendidas[0];
                  n37LugarSectorVendidas = P000H4_n37LugarSectorVendidas[0];
                  A30LugarSectorPrecio = P000H4_A30LugarSectorPrecio[0];
                  A28LugarSectorName = P000H4_A28LugarSectorName[0];
                  A29LugarSectorCantidad = P000H4_A29LugarSectorCantidad[0];
                  A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
                  AV5GXLvl10 = 1;
                  H0H0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9")), 106, Gx_line+44, 184, Gx_line+59, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28LugarSectorName, "")), 233, Gx_line+44, 339, Gx_line+59, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9")), 378, Gx_line+44, 473, Gx_line+59, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9")), 539, Gx_line+44, 667, Gx_line+59, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( AV5GXLvl10 == 0 )
               {
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV4GXLvl5 == 0 )
            {
               H0H0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("No hay Espectaculos", 322, Gx_line+33, 500, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0H0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Listado de Espectaculos", 306, Gx_line+33, 583, Gx_line+66, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+96);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000H2_A3PaisId = new short[1] ;
         P000H2_A7TipoEspectaculoId = new short[1] ;
         P000H2_A1EspectaculoId = new short[1] ;
         P000H2_A4LugarId = new short[1] ;
         P000H2_A6PaisName = new string[] {""} ;
         P000H2_A5LugarName = new string[] {""} ;
         P000H2_A8TipoEspectaculoName = new string[] {""} ;
         P000H2_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         P000H2_A2EspectaculoName = new string[] {""} ;
         A6PaisName = "";
         A5LugarName = "";
         A8TipoEspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A2EspectaculoName = "";
         P000H4_A4LugarId = new short[1] ;
         P000H4_A1EspectaculoId = new short[1] ;
         P000H4_A30LugarSectorPrecio = new short[1] ;
         P000H4_A28LugarSectorName = new string[] {""} ;
         P000H4_A27LugarSectorId = new short[1] ;
         P000H4_A29LugarSectorCantidad = new short[1] ;
         P000H4_A37LugarSectorVendidas = new short[1] ;
         P000H4_n37LugarSectorVendidas = new bool[] {false} ;
         A28LugarSectorName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aimpresionespectaculos__default(),
            new Object[][] {
                new Object[] {
               P000H2_A3PaisId, P000H2_A7TipoEspectaculoId, P000H2_A1EspectaculoId, P000H2_A4LugarId, P000H2_A6PaisName, P000H2_A5LugarName, P000H2_A8TipoEspectaculoName, P000H2_A16EspectaculoFecha, P000H2_A2EspectaculoName
               }
               , new Object[] {
               P000H4_A4LugarId, P000H4_A1EspectaculoId, P000H4_A30LugarSectorPrecio, P000H4_A28LugarSectorName, P000H4_A27LugarSectorId, P000H4_A29LugarSectorCantidad, P000H4_A37LugarSectorVendidas, P000H4_n37LugarSectorVendidas
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV4GXLvl5 ;
      private short A3PaisId ;
      private short A7TipoEspectaculoId ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short AV5GXLvl10 ;
      private short A30LugarSectorPrecio ;
      private short A27LugarSectorId ;
      private short A29LugarSectorCantidad ;
      private short A37LugarSectorVendidas ;
      private short A38LugarSectorDisponibles ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n37LugarSectorVendidas ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A8TipoEspectaculoName ;
      private string A2EspectaculoName ;
      private string A28LugarSectorName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000H2_A3PaisId ;
      private short[] P000H2_A7TipoEspectaculoId ;
      private short[] P000H2_A1EspectaculoId ;
      private short[] P000H2_A4LugarId ;
      private string[] P000H2_A6PaisName ;
      private string[] P000H2_A5LugarName ;
      private string[] P000H2_A8TipoEspectaculoName ;
      private DateTime[] P000H2_A16EspectaculoFecha ;
      private string[] P000H2_A2EspectaculoName ;
      private short[] P000H4_A4LugarId ;
      private short[] P000H4_A1EspectaculoId ;
      private short[] P000H4_A30LugarSectorPrecio ;
      private string[] P000H4_A28LugarSectorName ;
      private short[] P000H4_A27LugarSectorId ;
      private short[] P000H4_A29LugarSectorCantidad ;
      private short[] P000H4_A37LugarSectorVendidas ;
      private bool[] P000H4_n37LugarSectorVendidas ;
   }

   public class aimpresionespectaculos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          Object[] prmP000H4;
          prmP000H4 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT T3.[PaisId], T1.[TipoEspectaculoId], T1.[EspectaculoId], T1.[LugarId], T4.[PaisName], T3.[LugarName], T2.[TipoEspectaculoName], T1.[EspectaculoFecha], T1.[EspectaculoName] FROM ((([Espectaculo] T1 INNER JOIN [TipoEspectaculo] T2 ON T2.[TipoEspectaculoId] = T1.[TipoEspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T1.[LugarId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisId]) ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000H4", "SELECT T3.[LugarId], T1.[EspectaculoId], T3.[LugarSectorPrecio], T3.[LugarSectorName], T1.[LugarSectorId], T3.[LugarSectorCantidad], COALESCE( T2.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (([EspectaculoLugarSector] T1 LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T2 ON T2.[EspectaculoId] = T1.[EspectaculoId] AND T2.[LugarSectorId] = T1.[LugarSectorId]) LEFT JOIN [LugarSector] T3 ON T3.[LugarId] = @LugarId AND T3.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId ORDER BY T1.[EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H4,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
